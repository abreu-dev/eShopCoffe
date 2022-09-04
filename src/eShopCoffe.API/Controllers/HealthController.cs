using eShopCoffe.API.Scope.Handlers;
using eShopCoffe.Identity.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers
{
    [IgnoreAuthenticationTokenFilter]
    public class HealthController : BaseController
    {
        private readonly IHealthService _healthService;

        public HealthController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        [HttpGet]
        [Route("health")]
        public IActionResult Get()
        {
            if (_healthService.IsHealthy())
            {
                return Ok();
            }

            return ServiceUnavailable();
        }
    }
}
