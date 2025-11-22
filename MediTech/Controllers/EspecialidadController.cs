using MediatR;
using Microsoft.AspNetCore.Mvc;
using MediTech.Application.Services.Especialidad_Services.Features.Queries.GetAllEspecialidadesActivas;
using MediTech.Application.Services.Especialidad_Services.Features.Queries;

namespace MediTech.API.Controllers
{
    /// <summary>
    /// Controlador encargado de gestionar las operaciones relacionadas con las especialidades médicas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EspecialidadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene todas las especialidades activas del sistema.
        /// </summary>
        /// <returns>Lista de especialidades activas.</returns>
        [HttpGet("activas")]
        public async Task<IActionResult> GetEspecialidadesActivas()
        {
            var query = new GetAllEspecialidadesActivasQuery();
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound("No se encontraron especialidades activas.");

            return Ok(result);
        }
    }
}
