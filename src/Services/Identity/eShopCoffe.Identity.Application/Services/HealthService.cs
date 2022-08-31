using eShopCoffe.Core.Data;
using eShopCoffe.Identity.Application.Services.Interfaces;

namespace eShopCoffe.Identity.Application.Services
{
    public class HealthService : IHealthService
    {
        private readonly IBaseContext _context;

        public HealthService(IBaseContext context)
        {
            _context = context;
        }

        public bool IsHealthy()
        {
            return _context.IsAvailable();
        }
    }
}
