using eShopCoffe.Core.Email.Interfaces;

namespace eShopCoffe.Core.Email
{
    public class EmailSettings : IEmailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        public EmailSettings()
        {
            var host = Environment.GetEnvironmentVariable("EMAIL_HOST");
            var port = Environment.GetEnvironmentVariable("EMAIL_PORT");
            var address = Environment.GetEnvironmentVariable("EMAIL_ADDRESS");
            var password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");

            if (string.IsNullOrEmpty(host))
            {
                throw new ArgumentNullException(host);
            }

            if (string.IsNullOrEmpty(port))
            {
                throw new ArgumentNullException(port);
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(address);
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(password);
            }

            Host = host;
            Port = Convert.ToInt32(port);
            Address = address;
            Password = password;
        }
    }
}
