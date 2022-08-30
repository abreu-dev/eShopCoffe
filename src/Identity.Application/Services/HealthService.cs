using Identity.Application.Services.Interfaces;
using Identity.Infra.Data.Context;

namespace Identity.Application.Services
{
    public class HealthService : IHealthService
    {
        private readonly IIdentityContext _identityContext;

        public HealthService(IIdentityContext identityContext)
        {
            _identityContext = identityContext;
        }

        public bool IsHealthy()
        {
            return _identityContext.IsAvailable();
        }
    }
}
