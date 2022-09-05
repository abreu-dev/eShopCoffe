namespace eShopCoffe.Identity.Application.Contracts.UserContracts
{
    public class UserCreationDto
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
