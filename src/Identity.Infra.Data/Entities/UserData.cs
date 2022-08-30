using Framework.Core.Data.Entities;

namespace Identity.Infra.Data.Entities
{
    public class UserData : EntityData
    {
        public static string TableName => "User";

        public string Login { get; set; }
        public static int LoginMaxLength => 100;

        public string Password { get; set; }
        public static int PasswordMaxLength => 100;

        public bool IsAdmin { get; set; }

        public DateTime? LastAccess { get; set; }
    }
}
