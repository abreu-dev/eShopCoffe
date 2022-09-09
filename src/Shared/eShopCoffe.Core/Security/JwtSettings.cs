using eShopCoffe.Core.Security.Interfaces;

namespace eShopCoffe.Core.Security
{
    public class JwtSettings : IJwtSettings
    {
        public string Secret { get; set; }
        public int Expires { get; set; }

        public JwtSettings()
        {
            var secret = Environment.GetEnvironmentVariable("JWT_SECRET");
            var expires = Environment.GetEnvironmentVariable("JWT_EXPIRES");

            if (string.IsNullOrEmpty(secret))
            {
                throw new ArgumentNullException(secret);
            }

            if (string.IsNullOrEmpty(expires))
            {
                throw new ArgumentNullException(expires);
            }

            Secret = secret;
            Expires = Convert.ToInt32(expires);
        }
    }
}
