using eShopCoffe.Core.Domain.Repositories.Interfaces;
using eShopCoffe.Identity.Infra.Data.Entities;

namespace eShopCoffe.Identity.Infra.Data.Seed
{
    public static class UserSeed
    {
        public static string AdministratorLogin => "admin";
        public static string AdministratorPassword => "admin@123";

        public static void SeedData(IRepository repository)
        {
            var existingUser = repository.Query<UserData>()
                .FirstOrDefault(x => x.Login == AdministratorLogin);

            if (existingUser == null)
            {
                var newUser = new UserData()
                {
                    Login = AdministratorLogin,
                    Password = AdministratorPassword,
                    IsAdmin = true
                };

                repository.Add(newUser);
                repository.UnitOfWork.Complete();
            }
        }
    }
}
