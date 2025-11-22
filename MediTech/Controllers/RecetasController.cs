using MediatR;
using Microsoft.AspNetCore.Mvc;
using MediTech.Application.Services.Recetas_Services.Features.CRUD.Queries.GetAllRecetas;
using MediTech.Application.Recetas.Commands.CreateReceta;
using MediTech.Domain.Dtos.Recetas;
using MediTech.Application.Recetas.Commands.UpdateReceta;
using MediTech.Application.Services.Recetas_Services.Features.CRUD.Queries.GetRecetasByIdPaciente;

namespace MediTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecetasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecetasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("recetas")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRecetasQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearReceta([FromBody] CreateRecetaDto dto)
        {
            var command = new CreateRecetaCommand(dto);
            var resultado = await _mediator.Send(command);

            if (resultado)
                return Ok(new { mensaje = "Receta creada correctamente" });
            else
                return BadRequest(new { mensaje = "No se pudo crear la receta" });
        }

        // PUT api/recetas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceta(int id, [FromBody] UpdateRecetaDto dto)
        {
            if (id != dto.ID)
                return BadRequest("El ID de la URL no coincide con el ID del cuerpo de la solicitud.");

            var command = new UpdateRecetaCommand(dto);
            var resultado = await _mediator.Send(command);

            if (!resultado)
                return NotFound("No se encontró la receta a actualizar.");

            return Ok("Receta actualizada correctamente.");
        }

        // GET: api/recetas/paciente/5
        [HttpGet("paciente/{idPaciente}")]
        public async Task<ActionResult<IEnumerable<RecetasDto>>> GetRecetasByPaciente(int idPaciente)
        {
            var query = new GetRecetasByPacienteQuery(idPaciente);
            var recetas = await _mediator.Send(query);

            if (recetas == null)
                return NotFound();

            return Ok(recetas);
        }

    }
}
