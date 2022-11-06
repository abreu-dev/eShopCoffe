namespace eShopCoffe.Contracts.Contracts.SessionContracts
{
    public class ConfirmPasswordResetDto
    {
        public string Username { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string PasswordResetCode { get; set; } = string.Empty;
    }
}
