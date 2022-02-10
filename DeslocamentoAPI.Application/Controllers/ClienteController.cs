using DeslocamentoAPI.Application.Documentos.Commands.CriarCliente;
using DeslocamentoAPI.Application.Documentos.Queries;
using DeslocamentoAPI.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApp.WebAPI.Controllers
{
    public class ClienteController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetClientesQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarClienteCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
