using MediatR;
using Microsoft.AspNetCore.Mvc;
using MediTech.Application.Recetas.Commands;
using MediTech.Application.Recetas.Queries;
using MediTech.Application.SignosVitales.Queries;
using MediTech.Domain.Dtos.Recetas;
using MediTech.Domain.Dtos.SignosVitales;

namespace MediTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignosVitalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SignosVitalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // =========================
        // GET: Obtener todos
        // =========================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSignosVitalesQuery());
            return Ok(result);
        }

        // =========================
        // POST: Crear registro
        // =========================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSignosVitalesDto dto)
        {
            var result = await _mediator.Send(new CreateSignosVitalesCommand(dto));
            return result ? Ok("Registro creado") : BadRequest("No se pudo crear");
        }

        // =========================
        // PUT: Actualizar registro
        // =========================
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SignosVitalesUpdateDto dto)
        {
            var result = await _mediator.Send(new UpdateSignosVitalesCommand(dto));

            if (!result)
                return NotFound("No se encontró el registro.");

            return Ok("Actualización exitosa");
        }

        // =========================
        // GET: Obtener por paciente
        // =========================
        [HttpGet("paciente/{pacienteId}")]
        public async Task<IActionResult> GetByPacienteId(int pacienteId)
        {
            var query = new GetSignosVitalesByPacienteIdQuery(pacienteId);
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound($"No hay signos vitales registrados para el paciente ID {pacienteId}");

            return Ok(result);
        }

        [HttpGet("paciente/{pacienteId}/fecha/{fecha}")]
        public async Task<IActionResult> GetByPacienteAndFecha(int pacienteId, DateTime fecha)
        {
            var query = new GetSignosVitalesByPacienteAndFechaQuery(pacienteId, fecha);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound($"No hay signos vitales del paciente {pacienteId} en la fecha {fecha.ToShortDateString()}");

            return Ok(result);
        }
    }
}
