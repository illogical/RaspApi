using Microsoft.AspNetCore.Mvc;
using RaspApi.Services;


namespace RaspApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivateController : ControllerBase
    {
        private PiService _piService;
        private readonly ILogger<ActivateController> _logger;

        public ActivateController(ILogger<ActivateController> logger)
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
