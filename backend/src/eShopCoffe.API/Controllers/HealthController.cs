using eShopCoffe.API.Scope.Handlers;
using eShopCoffe.Identity.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers
{
    [Route("health")]
    [IgnoreAuthenticationTokenFilter]
    public class HealthController : BaseController
    {
        private readonly IHealthService _healthService;

        public HealthController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        [HttpGet]
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
