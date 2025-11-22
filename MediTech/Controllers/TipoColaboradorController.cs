using MediTech.Application.Features.Colaboradores.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediTech.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoColaboradorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TipoColaboradorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ✅ GET api/tipocolaborador
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllTipoColaboradoresCommand();
            var tipos = await _mediator.Send(command);

            if (tipos == null || !tipos.Any())
                return NotFound(new { mensaje = "No hay tipos de colaboradores registrados." });

            return Ok(tipos);
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> ObtenerTipoColaborador(int usuarioId)
        {
            var query = new ObtenerTipoColaboradorQuery(usuarioId);
            var resultado = await _mediator.Send(query);

            if (resultado == null)
                return NotFound("Colaborador no encontrado");

            return Ok(resultado);
        }

    }
}
