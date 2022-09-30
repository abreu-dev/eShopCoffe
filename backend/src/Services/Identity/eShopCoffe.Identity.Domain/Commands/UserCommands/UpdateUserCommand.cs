using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Validators;
using eShopCoffe.Identity.Domain.Validators.UserValidators;

namespace eShopCoffe.Identity.Domain.Commands.UserCommands
{
    public class UpdateUserCommand : ValidatableCommand<UpdateUserCommand>
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public UpdateUserCommand(Guid id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }

        protected override CommandValidator<UpdateUserCommand> GetValidator()
        {
            return new UpdateUserCommandValidator();
        }
    }
}
