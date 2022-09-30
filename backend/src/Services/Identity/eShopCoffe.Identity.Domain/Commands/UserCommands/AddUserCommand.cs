using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Validators;
using eShopCoffe.Identity.Domain.Validators.UserValidators;

namespace eShopCoffe.Identity.Domain.Commands.UserCommands
{
    public class AddUserCommand : ValidatableCommand<AddUserCommand>
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public AddUserCommand(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        protected override CommandValidator<AddUserCommand> GetValidator()
        {
            return new AddUserCommandValidator();
        }
    }
}
