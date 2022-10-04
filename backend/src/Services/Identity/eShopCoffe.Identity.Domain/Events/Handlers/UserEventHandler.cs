using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Identity.Domain.Events.UserEvents;
using eShopCoffe.Identity.Domain.Repositories;

namespace eShopCoffe.Identity.Domain.Events.Handlers
{
    public class UserEventHandler : IEventHandler<UserSignedInEvent>
    {
        private readonly IUserRepository _userRepository;

        public UserEventHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task Handle(UserSignedInEvent @event, CancellationToken cancellationToken = default)
        {
            _userRepository.UpdateLastAccess(@event.UserId);
            _userRepository.UnitOfWork.Complete();
            return Task.CompletedTask;
        }
    }
}
