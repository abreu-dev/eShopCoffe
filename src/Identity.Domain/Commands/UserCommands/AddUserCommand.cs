using Framework.Core.Messaging.Requests;
using Framework.Core.Validators;
using Identity.Domain.Validators.UserValidators;

namespace Identity.Domain.Commands.UserCommands
{
    public class AddUserCommand : ValidatableCommand<AddUserCommand>
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public AddUserCommand(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public override CommandValidator<AddUserCommand> GetValidator()
        {
            return new AddUserCommandValidator();
        }
    }
}
