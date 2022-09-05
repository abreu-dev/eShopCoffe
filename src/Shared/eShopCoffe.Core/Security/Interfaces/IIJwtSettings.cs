namespace eShopCoffe.Core.Security.Interfaces
{
    public interface IJwtSettings
    {
        string Secret { get; set; }
        int Expires { get; set; }
    }
}
