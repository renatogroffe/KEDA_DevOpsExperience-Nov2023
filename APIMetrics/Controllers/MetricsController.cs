using APIMetrics.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIMetrics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetricsController : ControllerBase
    {
        private readonly ILogger<MetricsController> _logger;
        private readonly MetricsDefinitions _metricsDefinitions;

        public MetricsController(ILogger<MetricsController> logger,
            MetricsDefinitions metricsDefinitions)
        {
            _logger = logger;
            _metricsDefinitions = metricsDefinitions;
        }

        [HttpGet]
        public MetricsDefinitions Get()
        {
            _logger.LogInformation(
                $"Status atual = {JsonSerializer.Serialize(_metricsDefinitions)}");
            return _metricsDefinitions;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(TargetValue targetValue)
        {
            _metricsDefinitions.Counter.TargetValue = targetValue.NewTargetValue;
            _metricsDefinitions.Counter.LastUpdate = DateTime.Now;
            _logger.LogInformation(
                $"Status novo = {JsonSerializer.Serialize(_metricsDefinitions)}");
            return Accepted();
        }
    }
}