namespace eShopCoffe.Core.Security
{
    public class AppSettings
    {
        public string Secret { get; set; } = string.Empty;
        public int Expires { get; set; }
    }
}
