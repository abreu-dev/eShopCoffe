using eShopCoffe.Core.Data.Entities;

namespace eShopCoffe.Identity.Infra.Data.Entities
{
    public class UserData : EntityData
    {
        public static string TableName => "User";

        public string Login { get; set; } = string.Empty;
        public static int LoginMaxLength => 100;

        public string Password { get; set; } = string.Empty;
        public static int PasswordMaxLength => 100;

        public bool IsAdmin { get; set; }

        public DateTime? LastAccess { get; set; }
    }
}
