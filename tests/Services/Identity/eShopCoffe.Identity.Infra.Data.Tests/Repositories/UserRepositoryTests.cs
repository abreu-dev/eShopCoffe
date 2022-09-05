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
        private readonly UserRepository _userRepository;

        public UserRepositoryTests()
        {
            _context = Substitute.For<IBaseContext>();
            _adapter = Substitute.For<IUserDataAdapter>();
            _userRepository = new UserRepository(_context, _adapter);
        }

        [Fact]
        public void Update_WhenAdapterReturnsNull_ShouldNotUpdate()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Login", "Password");
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
            var userDomain = new UserDomain(Guid.NewGuid(), "Login", "Password");
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
            var userDomain = new UserDomain(Guid.NewGuid(), "Login", "Password");
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
        public void GetByLoginAndPassword_WhenFound_ShouldReturnDomain()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var dataList = new List<UserData>() {
                new UserData()
                {
                    Id = userId,
                    Login = "Login1",
                    Password = "Password1"
                },
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    Login = "Login2",
                    Password = "Password2"
                }
            };
            _context.Query<UserData>().Returns(dataList.AsQueryable());

            var domain = new UserDomain(dataList.ElementAt(0).Id, dataList.ElementAt(0).Login, dataList.ElementAt(0).Password);
            _adapter.Transform(dataList.ElementAt(0)).Returns(domain);

            // Act
            var result = _userRepository.GetByLoginAndPassword(dataList.ElementAt(0).Login, dataList.ElementAt(0).Password);

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(domain);
        }

        [Theory]
        [InlineData("Login1", "Password2")]
        [InlineData("Login2", "Password1")]
        public void GetByLoginAndPassword_WhenNotFound_ShouldReturnNull(string login, string password)
        {
            // Arrange
            var userId = Guid.NewGuid();
            var dataList = new List<UserData>() {
                new UserData()
                {
                    Id = userId,
                    Login = "Login1",
                    Password = "Password1"
                },
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    Login = "Login2",
                    Password = "Password2"
                }
            };
            _context.Query<UserData>().Returns(dataList.AsQueryable());

            // Act
            var result = _userRepository.GetByLoginAndPassword(login, password);

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
    }
}
