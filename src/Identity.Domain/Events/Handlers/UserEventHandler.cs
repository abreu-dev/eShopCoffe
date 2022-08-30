using Framework.Core.Messaging.Handlers.Interfaces;
using Identity.Domain.Events.UserEvents;
using Identity.Domain.Repositories;

namespace Identity.Domain.Events.Handlers
{
    public class UserEventHandler : IEventHandler<UserLoggedInEvent>
    {
        private readonly IUserRepository _userRepository;

        public UserEventHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task Handle(UserLoggedInEvent @event, CancellationToken cancellationToken = default)
        {
            _userRepository.UpdateLastAccess(@event.UserId);
            _userRepository.UnitOfWork.Complete();
            return Task.CompletedTask;
        }
    }
}
