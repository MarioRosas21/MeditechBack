
[ApiController]
[Route("api/[controller]")]
[Authorize] // Solo pacientes autenticados pueden crear citas
public class CitaController : ControllerBase
{
    private readonly IMediator _mediator;

    public CitaController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateCita([FromBody] CreateCitaCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Buscar el ID del paciente en los claims (puede estar en NameIdentifier o sub)
        var pacienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                              ?? User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        if (string.IsNullOrEmpty(pacienteIdClaim))
            return Unauthorized("Paciente no autenticado.");

        // Convertir el ID de string a int
        if (!int.TryParse(pacienteIdClaim, out var pacienteId))
            return BadRequest("El token no contiene un ID de paciente válido.");

        command.ID_Paciente = pacienteId;

        var citaId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetCitaById), new { id = citaId }, new { ID = citaId });
    }


    [HttpGet("mis-citas")]
    public async Task<IActionResult> GetMisCitas()
    {
        var pacienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(pacienteIdClaim))
            return Unauthorized("Paciente no autenticado.");

        var query = new GetCitasByPacienteQuery(int.Parse(pacienteIdClaim));
        var citas = await _mediator.Send(query);

        return Ok(citas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCitaById(int id)
    {
        var cita = await _mediator.Send(new GetCitaByIdQuery(id));
        if (cita == null)
            return NotFound();

        return Ok(cita);
    }
}
