using MediTech.Application.Services.Cede_Services.Features.CRUD.Queries.GetAllCedes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediTech.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CedeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CedeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene todas las cedes registradas.
        /// </summary>
        /// <returns>Lista de cedes.</returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCedes()
        {
            var query = new GetAllCedesQuery();
            var cedes = await _mediator.Send(query);

            if (cedes == null || !cedes.Any())
                return NotFound("No se encontraron cedes registradas.");

            return Ok(cedes);
        }
    }
}
