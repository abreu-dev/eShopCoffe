namespace eShopCoffe.Identity.Application.Contracts.SessionContracts
{
    public class LoginResultDto
    {
        public string Token { get; set; } = string.Empty;
        public LoginResultUserDto User { get; set; } = null!;
    }
}
