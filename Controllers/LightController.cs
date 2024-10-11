using Microsoft.AspNetCore.Mvc;
using RaspApi.Services;


namespace RaspApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LightController : ControllerBase
    {
        private PiService _piService;
        private readonly ILogger<LightController> _logger;

        public LightController(ILogger<LightController> logger)
        {
            _piService = new PiService();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet(Name = "On")]
        [Route("On")]
        public IActionResult On()
        {
            try
            {
                _piService.EnableLED();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                return StatusCode(500, new { ex.Message });
            }

            return Ok();
        }

        [HttpGet(Name = "Off")]
        [Route("Off")]
        public IActionResult Off()
        {
            try
            {
                _piService.DisableLED();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                return StatusCode(500, new { ex.Message });
            }

            return Ok();
        }
    }
}
