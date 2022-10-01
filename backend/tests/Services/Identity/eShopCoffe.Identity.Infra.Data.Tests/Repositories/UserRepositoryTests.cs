using eShopCoffe.Core.Cryptography.Interfaces;
using eShopCoffe.Core.Data;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Identity.Infra.Data.Entities;
using eShopCoffe.Identity.Infra.Data.Repositories;

namespace eShopCoffe.Identity.Infra.Data.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly IBaseContext _context;
        private readonly IUserDataAdapter _adapter;
        private readonly IPasswordHash _passwordHash;
        private readonly UserRepository _userRepository;

        public UserRepositoryTests()
        { 
            _context = Substitute.For<IBaseContext>();
            _adapter = Substitute.For<IUserDataAdapter>();
            _passwordHash = Substitute.For<IPasswordHash>();
            _userRepository = new UserRepository(_context, _adapter, _passwordHash);
        }

        [Fact]
        public void Update_WhenAdapterReturnsNull_ShouldNotUpdate()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Username", "Email");
            _adapter.Transform(userDomain).ReturnsNull();

            // Act
            _userRepository.Update(userDomain);

            // Assert
            _context.DidNotReceive().UpdateData(Arg.Any<UserData>());
            _context.Received(1).GetDbSet<UserData>();
            _context.DidNotReceive().GetDbEntry(Arg.Any<UserData>());
        }

        [Fact]
        public void Update_WhenExistingDataIsNull_ShouldUpdate()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Username", "Email");
            var userData = new UserData()
            {
                Id = userDomain.Id
            };
            _adapter.Transform(userDomain).Returns(userData);

            var mockDbSet = new List<UserData>()
            {
                new UserData()
                {
                    Id = Guid.NewGuid()
                }
            }.AsQueryable().BuildMockDbSet();
            _context.GetDbSet<UserData>().Returns(mockDbSet);

            // Act
            _userRepository.Update(userDomain);

            // Assert
            _context.Received(1).UpdateData(Arg.Any<UserData>());
            _context.Received(1).UpdateData(userData);
            _context.Received(2).GetDbSet<UserData>();
            _context.DidNotReceive().GetDbEntry(Arg.Any<UserData>());
        }

        [Fact]
        public void Update_WhenEntryIsNull_ShouldUpdate()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Username", "Email");
            var userData = new UserData()
            {
                Id = userDomain.Id
            };
            _adapter.Transform(userDomain).Returns(userData);

            var mockDbSet = new List<UserData>()
            {
                new UserData()
                {
                    Id = Guid.NewGuid()
                },
                userData
            }.AsQueryable().BuildMockDbSet();
            _context.GetDbSet<UserData>().Returns(mockDbSet);
            _context.GetDbEntry(userData).ReturnsNull();

            // Act
            _userRepository.Update(userDomain);

            // Assert
            _context.Received(1).UpdateData(Arg.Any<UserData>());
            _context.Received(1).UpdateData(userData);
            _context.Received(2).GetDbSet<UserData>();
            _context.Received(1).GetDbEntry(userData);
        }

        [Fact]
        public void GetByUsernameAndPassword_WhenFound_ShouldReturnDomain()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var dataList = new List<UserData>() {
                new UserData()
                {
                    Id = userId,
                    Username = "Username1",
                    HashedPassword = "Password1"
                },
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    Username = "Username2",
                    HashedPassword = "Password2"
                }
            };
            _context.Query<UserData>().Returns(dataList.AsQueryable());

            _passwordHash.Verify("Password1", dataList.ElementAt(0).HashedPassword).Returns(true);

            var domain = new UserDomain(dataList.ElementAt(0).Id, dataList.ElementAt(0).Username, dataList.ElementAt(0).HashedPassword);
            _adapter.Transform(dataList.ElementAt(0)).Returns(domain);

            // Act
            var result = _userRepository.GetByUsernameAndPassword("Username1", "Password1");

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(domain);
        }

        [Theory]
        [InlineData("Username1", "Password2")]
        [InlineData("Username2", "Password1")]
        public void GetByUsernameAndPassword_WhenNotFound_ShouldReturnNull(string username, string password)
        {
            // Arrange
            var userId = Guid.NewGuid();
            var dataList = new List<UserData>() {
                new UserData()
                {
                    Id = userId,
                    Username = "Username1",
                    HashedPassword = "Password1"
                },
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    Username = "Username2",
                    HashedPassword = "Password2"
                }
            };
            _context.Query<UserData>().Returns(dataList.AsQueryable());

            // Act
            var result = _userRepository.GetByUsernameAndPassword(username, password);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void UpdateLastAccess_WhenFound_ShouldSetLastAccess()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var dataList = new List<UserData>() {
                new UserData()
                {
                    Id = userId,
                    LastAccess = null
                },
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    LastAccess = null
                }
            };
            _context.Query<UserData>().Returns(dataList.AsQueryable());

            // Act
            _userRepository.UpdateLastAccess(userId);

            // Assert
            dataList.ElementAt(0).LastAccess.Should().NotBeNull();
            dataList.ElementAt(1).LastAccess.Should().BeNull();
        }

        [Fact]
        public void UpdateLastAccess_WhenNotFound_ShouldDoNothing()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var dataList = new List<UserData>() {
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    LastAccess = null
                },
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    LastAccess = null
                }
            };
            _context.Query<UserData>().Returns(dataList.AsQueryable());

            // Act
            _userRepository.UpdateLastAccess(userId);

            // Assert
            dataList.ElementAt(0).LastAccess.Should().BeNull();
            dataList.ElementAt(1).LastAccess.Should().BeNull();
        }

        [Fact]
        public void ChangeTemporaryPasswordResetCode_WhenFound_ShouldPasswordResetInfos()
        {
            // Arrange
            var dataList = new List<UserData>() {
                new UserData()
                {
                    Username = "Username1",
                    HashedTemporaryPasswordResetCode = null,
                    ExpireTemporaryPasswordResetCode = null
                },
                new UserData()
                {
                    Username = "Username2",
                    HashedTemporaryPasswordResetCode = "654321",
                    ExpireTemporaryPasswordResetCode = new DateTime(2022, 10, 02)
                }
            };
            _context.Query<UserData>().Returns(dataList.AsQueryable());

            var temporaryPasswordResetCode = "PasswordCode";
            var hashedTemporaryPasswordResetCode = "HashedPasswordCode";
            _passwordHash.Hash(temporaryPasswordResetCode).Returns(hashedTemporaryPasswordResetCode);

            // Act
            _userRepository.ChangeTemporaryPasswordResetCode(dataList.ElementAt(0).Username, temporaryPasswordResetCode);

            // Assert
            dataList.ElementAt(0).HashedTemporaryPasswordResetCode.Should().Be(hashedTemporaryPasswordResetCode);
            dataList.ElementAt(0).ExpireTemporaryPasswordResetCode.Should().NotBeNull();

            dataList.ElementAt(1).HashedTemporaryPasswordResetCode.Should().Be("654321");
            dataList.ElementAt(1).ExpireTemporaryPasswordResetCode.Should().Be(new DateTime(2022, 10, 02));

            _passwordHash.Received(1).Hash(Arg.Any<string>());
            _passwordHash.Received(1).Hash(temporaryPasswordResetCode);
        }

        [Fact]
        public void ChangeTemporaryPasswordResetCode_WhenNotFound_ShouldDoNothing()
        {
            // Arrange
            var dataList = new List<UserData>() {
                new UserData()
                {
                    Username = "Username1",
                    HashedTemporaryPasswordResetCode = null,
                    ExpireTemporaryPasswordResetCode = null
                },
                new UserData()
                {
                    Username = "Username2",
                    HashedTemporaryPasswordResetCode = "654321",
                    ExpireTemporaryPasswordResetCode = new DateTime(2022, 10, 02)
                }
            };
            _context.Query<UserData>().Returns(dataList.AsQueryable());

            var temporaryPasswordResetCode = "PasswordCode";

            // Act
            _userRepository.ChangeTemporaryPasswordResetCode("Username3", temporaryPasswordResetCode);

            // Assert
            dataList.ElementAt(0).HashedTemporaryPasswordResetCode.Should().BeNull();
            dataList.ElementAt(0).ExpireTemporaryPasswordResetCode.Should().BeNull();

            dataList.ElementAt(1).HashedTemporaryPasswordResetCode.Should().Be("654321");
            dataList.ElementAt(1).ExpireTemporaryPasswordResetCode.Should().Be(new DateTime(2022, 10, 02));

            _passwordHash.DidNotReceive().Hash(Arg.Any<string>());
        }

        [Fact]
        public void ChangePassword_WhenFound_ShouldSetHashedPassword()
        {
            // Arrange
            var dataList = new List<UserData>() {
                new UserData()
                {
                    Username = "Username1",
                    HashedPassword = "HashedPassword1",
                    HashedTemporaryPasswordResetCode = "123456",
                    ExpireTemporaryPasswordResetCode = new DateTime(2022, 10, 01)
                },
                new UserData()
                {
                    Username = "Username2",
                    HashedPassword = "HashedPassword2",
                    HashedTemporaryPasswordResetCode = "654321",
                    ExpireTemporaryPasswordResetCode = new DateTime(2022, 10, 02)
                }
            };
            _context.Query<UserData>().Returns(dataList.AsQueryable());

            var newPassword = "NewPassword";
            var newHashedPassword = "NewHashedPassword";
            _passwordHash.Hash(newPassword).Returns(newHashedPassword);

            // Act
            _userRepository.ChangePassword(dataList.ElementAt(0).Username, newPassword);

            // Assert
            dataList.ElementAt(0).HashedPassword.Should().Be(newHashedPassword);
            dataList.ElementAt(0).HashedTemporaryPasswordResetCode.Should().BeNull();
            dataList.ElementAt(0).ExpireTemporaryPasswordResetCode.Should().BeNull();

            dataList.ElementAt(1).HashedPassword.Should().Be("HashedPassword2");
            dataList.ElementAt(1).HashedTemporaryPasswordResetCode.Should().Be("654321");
            dataList.ElementAt(1).ExpireTemporaryPasswordResetCode.Should().Be(new DateTime(2022, 10, 02));

            _passwordHash.Received(1).Hash(Arg.Any<string>());
            _passwordHash.Received(1).Hash(newPassword);
        }

        [Fact]
        public void ChangePassword_WhenNotFound_ShouldDoNothing()
        {
            // Arrange
            var dataList = new List<UserData>() {
                new UserData()
                {
                    Username = "Username1",
                    HashedPassword = "HashedPassword1",
                    HashedTemporaryPasswordResetCode = "123456",
                    ExpireTemporaryPasswordResetCode = new DateTime(2022, 10, 01)
                },
                new UserData()
                {
                    Username = "Username2",
                    HashedPassword = "HashedPassword2",
                    HashedTemporaryPasswordResetCode = "654321",
                    ExpireTemporaryPasswordResetCode = new DateTime(2022, 10, 02)
                }
            };
            _context.Query<UserData>().Returns(dataList.AsQueryable());

            var newPassword = "NewPassword";

            // Act
            _userRepository.ChangePassword("Username3", newPassword);

            // Assert
            dataList.ElementAt(0).HashedPassword.Should().Be("HashedPassword1");
            dataList.ElementAt(0).HashedTemporaryPasswordResetCode.Should().Be("123456");
            dataList.ElementAt(0).ExpireTemporaryPasswordResetCode.Should().Be(new DateTime(2022, 10, 01));

            dataList.ElementAt(1).HashedPassword.Should().Be("HashedPassword2");
            dataList.ElementAt(1).HashedTemporaryPasswordResetCode.Should().Be("654321");
            dataList.ElementAt(1).ExpireTemporaryPasswordResetCode.Should().Be(new DateTime(2022, 10, 02));

            _passwordHash.DidNotReceive().Hash(Arg.Any<string>());
        }
    }
}
