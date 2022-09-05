﻿using eShopCoffe.Core.Domain.Repositories.Interfaces;
using eShopCoffe.Identity.Infra.Data.Entities;
using eShopCoffe.Identity.Infra.Data.Seed;

namespace eShopCoffe.Identity.Infra.Data.Tests.Seed
{
    public class UserSeedTests
    {
        [Fact]
        public void UserSeed_WhenUserFound_ShouldNotCreate()
        {
            // Arrange
            var repository = Substitute.For<IRepository>();
            repository.Query<UserData>().Returns(new List<UserData>()
            {
                new UserData()
                {
                    Login = UserSeed.AdministratorLogin
                }
            }.AsQueryable());

            // Act
            UserSeed.SeedData(repository);

            // Assert
            repository.Received(1).Query<UserData>();
            repository.DidNotReceive().Add(Arg.Any<UserData>());
            repository.UnitOfWork.DidNotReceive().Complete();
        }

        [Fact]
        public void UserSeed_WhenUserNotFound_ShouldCreate()
        {
            // Arrange
            var repository = Substitute.For<IRepository>();
            repository.Query<UserData>().Returns(new List<UserData>()
            {
                new UserData()
                {
                    Login = "Login"
                }
            }.AsQueryable());

            // Act
            UserSeed.SeedData(repository);

            // Assert
            repository.Received(1).Query<UserData>();
            repository.Received(1).Add(Arg.Any<UserData>());
            repository.Received(1).Add(Arg.Is<UserData>(x => x.Login == UserSeed.AdministratorLogin 
                && x.Password == UserSeed.AdministratorPassword && x.IsAdmin));
            repository.UnitOfWork.Received(1).Complete();
        }
    }
}
