namespace eShopCoffe.Identity.Application.Contracts.UserContracts
{
    public class UserCreationDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
