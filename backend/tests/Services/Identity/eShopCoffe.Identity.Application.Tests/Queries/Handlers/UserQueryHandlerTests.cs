using eShopCoffe.Core.Data;
using eShopCoffe.Identity.Application.Parameters.Interfaces;
using eShopCoffe.Identity.Application.Queries.Handlers;
using eShopCoffe.Identity.Application.Queries.UserQueries;
using eShopCoffe.Identity.Infra.Data.Entities;

namespace eShopCoffe.Identity.Application.Tests.Queries.Handlers
{
    public class UserQueryHandlerTests
    {
        private readonly IBaseContext _context;
        private readonly UserQueryHandler _userQueryHandler;

        public UserQueryHandlerTests()
        {
            _context = Substitute.For<IBaseContext>();
            _userQueryHandler = new UserQueryHandler(_context);
        }

        [Fact]
        public void Handle_PagedUsersQuery_ShouldReturnPagedList()
        {
            // Arrange
            var userParameters = Substitute.For<IUserParameters>();
            userParameters.Page.Returns(0);
            userParameters.Size.Returns(2);
            var pagedUsersQuery = new PagedUsersQuery(userParameters);

            var userDataList = new List<UserData>()
            {
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    Login = "1 - Login"
                },
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    Login = "5 - Login"
                },
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    Login = "3 - Login"
                },
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    Login = "2 - Login"
                },
                new UserData()
                {
                    Id = Guid.NewGuid(),
                    Login = "4 - Login"
                },
            };
            _context.Query<UserData>().Returns(userDataList.AsQueryable());

            // Act
            var result = _userQueryHandler.Handle(pagedUsersQuery).Result;

            // Assert
            result.TotalItems.Should().Be(5);
            result.Data.Should().HaveCount(2);

            result.Data.ElementAt(0).Id.Should().Be(userDataList.ElementAt(0).Id);
            result.Data.ElementAt(0).Login.Should().Be(userDataList.ElementAt(0).Login);

            result.Data.ElementAt(1).Id.Should().Be(userDataList.ElementAt(3).Id);
            result.Data.ElementAt(1).Login.Should().Be(userDataList.ElementAt(3).Login);
        }
    }
}
