using DeslocamentoAPI.Application.Documentos.Commands.CriarCarro;
using DeslocamentoAPI.Application.Documentos.Queries;
using DeslocamentoAPI.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApi.WebApi.Controllers
{
    public class CarroController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetCarrosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarCarroCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
