using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChurrasTrinca.Api
{
    [ApiController]
    [Route("[controller]")]
    public class ChurrascoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ChurrascoController> _logger;

        public ChurrascoController(ILogger<ChurrascoController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Cria um Churrasco.
        /// </summary>
        /// <returns>Churrasco Criado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateAsync()
        {
            var result = Summaries;
            return Ok(result);
        }

        /// <summary>
        /// Obtém um Churrasco.
        /// </summary>
        /// <returns>Objeto Churrasco</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = Summaries;
            return Ok(result);
        }
    }
}
