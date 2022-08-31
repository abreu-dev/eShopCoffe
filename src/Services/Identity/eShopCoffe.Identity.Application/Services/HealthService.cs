using eShopCoffe.Identity.Application.Services.Interfaces;
using eShopCoffe.Identity.Infra.Data.Context;

namespace eShopCoffe.Identity.Application.Services
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
