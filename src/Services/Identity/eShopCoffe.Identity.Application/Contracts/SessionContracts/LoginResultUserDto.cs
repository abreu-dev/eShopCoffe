namespace eShopCoffe.Identity.Application.Contracts.SessionContracts
{
    public class LoginResultUserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public bool IsAdmin { get; set; }
    }
}
