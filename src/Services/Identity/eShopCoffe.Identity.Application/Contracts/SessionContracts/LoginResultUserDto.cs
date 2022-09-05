namespace eShopCoffe.Identity.Application.Contracts.SessionContracts
{
    public class LoginResultUserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
