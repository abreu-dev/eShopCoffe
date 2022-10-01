namespace eShopCoffe.Core.Email.Interfaces
{
    public interface IEmailSettings
    {
        string Host { get; set; }
        int Port { get; set; }
        string Address { get; set; }
        string Password { get; set; }
    }
}
