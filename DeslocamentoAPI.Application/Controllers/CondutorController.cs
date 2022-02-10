using DeslocamentoAPI.Application.Documentos.Commands.CriarCondutor;
using DeslocamentoAPI.Application.Documentos.Queries;
using Microsoft.AspNetCore.Mvc;


namespace DeslocamentoAPI.WebApi.Controllers
{
    public class CondutorController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetCondutoresQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarCondutorCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
