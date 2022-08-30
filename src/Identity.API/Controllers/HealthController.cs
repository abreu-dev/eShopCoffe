using Identity.Api.Controllers;
using Identity.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    public class HealthController : BaseController
    {
        private readonly IHealthService _healthService;

        public HealthController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        [HttpGet]
        [Route("api/health")]
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
