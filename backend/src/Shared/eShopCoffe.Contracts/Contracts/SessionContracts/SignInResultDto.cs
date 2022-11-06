namespace eShopCoffe.Contracts.Contracts.SessionContracts
{
    public class SignInResultDto
    {
        public string Token { get; set; } = string.Empty;
        public SignInResultUserDto User { get; set; } = null!;
    }
}
