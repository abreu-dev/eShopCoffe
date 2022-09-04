using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Identity.Domain.Commands.UserCommands;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;

namespace eShopCoffe.Identity.Domain.Commands.Handlers
{
    public class UserCommandHandler :
        ICommandHandler<AddUserCommand>,
        ICommandHandler<UpdateUserCommand>,
        ICommandHandler<RemoveUserCommand>
    {
        private readonly IBus _bus;
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IBus bus,
                                  IUserRepository userRepository)
        {
            _bus = bus;
            _userRepository = userRepository;
        }

        public async Task Handle(AddUserCommand command, CancellationToken cancellationToken = default)
        {
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    await _bus.Notification(new Notification(error.ErrorCode, error.ErrorMessage), cancellationToken);
                }
                return;
            }

            var user = new UserDomain(command.Login, command.Password);

            _userRepository.Add(user);
            _userRepository.UnitOfWork.Complete();
        }

        public async Task Handle(UpdateUserCommand command, CancellationToken cancellationToken = default)
        {
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    await _bus.Notification(new Notification(error.ErrorCode, error.ErrorMessage), cancellationToken);
                }
                return;
            }

            var user = new UserDomain(command.Id, command.Login, command.Password);

            _userRepository.Update(user);
            _userRepository.UnitOfWork.Complete();
        }

        public async Task Handle(RemoveUserCommand command, CancellationToken cancellationToken = default)
        {
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    await _bus.Notification(new Notification(error.ErrorCode, error.ErrorMessage), cancellationToken);
                }
                return;
            }

            _userRepository.Delete(command.Id);
            _userRepository.UnitOfWork.Complete();
        }
    }
}
