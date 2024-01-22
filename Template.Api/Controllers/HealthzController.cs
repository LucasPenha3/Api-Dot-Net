using Microsoft.AspNetCore.Mvc;
using Template.Domain.Interfaces.Queries;

namespace template.Api.Controllers
{
    [ApiController]
    [Route("v1/healthz")]
    public class HealthzController : ControllerBase
    {

        private readonly IHealthzQuery _healthzQuery;

        public HealthzController(IHealthzQuery healthzQuery)
        {
            _healthzQuery = healthzQuery;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return await _healthzQuery.Get()
                ? Ok("Conectado com sucesso")
                : BadRequest("Falha na conexão");
        }
    }
}
