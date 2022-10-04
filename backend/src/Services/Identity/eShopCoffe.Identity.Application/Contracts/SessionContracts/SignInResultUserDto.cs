namespace eShopCoffe.Identity.Application.Contracts.SessionContracts
{
    public class SignInResultUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
