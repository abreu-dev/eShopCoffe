using eShopCoffe.Core.Domain.Repositories.Interfaces;
using eShopCoffe.Identity.Infra.Data.Entities;

namespace eShopCoffe.Identity.Infra.Data.Seed
{
    public static class UserSeed
    {
        public static Guid AdministratorId => Guid.Parse("7f30727b-2048-4de5-8aff-447a2db58805");
        public static string AdministratorUsername => "admin";
        public static string AdministratorEmail => "admin@fake.com";
        public static string AdministratorHashedPassword => "$2a$11$fAYcGlWs5EJoybC.hcyQn.Fi8a9g.mlT6bZnLUhFP5JsLXMK3LflS";

        public static void SeedData(IRepository repository)
        {
            var existingUser = repository.Query<UserData>()
                .FirstOrDefault(x => x.Id == AdministratorId);

            if (existingUser == null)
            {
                var newUser = new UserData()
                {
                    Id = AdministratorId,
                    Username = AdministratorUsername,
                    Email = AdministratorEmail,
                    HashedPassword = AdministratorHashedPassword,
                    IsAdmin = true
                };

                repository.Add(newUser);
                repository.UnitOfWork.Complete();
            }
        }
    }
}
