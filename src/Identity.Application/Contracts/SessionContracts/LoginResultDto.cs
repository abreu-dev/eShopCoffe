namespace Identity.Application.Contracts.SessionContracts
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public LoginResultUserDto User { get; set; }
    }
}
