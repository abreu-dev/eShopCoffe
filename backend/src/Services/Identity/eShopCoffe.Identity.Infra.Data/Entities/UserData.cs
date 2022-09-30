using eShopCoffe.Core.Data.Entities;

namespace eShopCoffe.Identity.Infra.Data.Entities
{
    public class UserData : EntityData
    {
        public static string TableName => "User";

        public string Username { get; set; } = string.Empty;
        public static int UsernameMaxLength => 100;

        public string Email { get; set; } = string.Empty;
        public static int EmailMaxLength => 100;

        public string HashedPassword { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }

        public DateTime? LastAccess { get; set; }
    }
}
