using MediTech.Application.Services.Paciente_Services.Features.Auth.Commands.RecoverPasswordByTelefono;
using MediTech.Application.Services.Paciente_Services.Features.Auth.Commands.VerificarEmailPaciente;
using MediTech.Application.Services.Paciente_Services.Features.Auth.Queries.LoginPaciente;

namespace MediTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PacienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /api/paciente/{id} - Obtener un paciente por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteVM>> GetPacienteByIdAsync(int id)
        {
            var pacienteVm = await _mediator.Send(new GetPacienteByIdQuery(id));
            if (pacienteVm == null)
                return NotFound("Paciente no encontrado");
            return Ok(pacienteVm);
        }

        // GET /api/paciente/all - Obtener todos los pacientes
        [HttpGet("all")]
        public async Task<ActionResult<List<PacienteVM>>> GetAllAsync()
        {
            var lista = await _mediator.Send(new GetAllPacientesQuery());
            return Ok(lista);
        }

        // POST /api/paciente/agregar - Crear un nuevo paciente
        [HttpPost("agregar")]
        public async Task<ActionResult<int>> AddAsync([FromBody] CreatePacienteCommand command)
        {
            if (command == null)
                return BadRequest("Los datos del paciente no pueden ser nulos");

            var nuevoId = await _mediator.Send(command);
            return Ok(nuevoId); // Devuelve el Id del nuevo paciente
        }

        // PUT /api/paciente/actualizar/{id} - Actualizar un paciente existente
        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] UpdatePacienteCommand command)
        {
            if (command == null)
                return BadRequest("Los datos del paciente no pueden ser nulos");

            // Aseguramos que el Id del comando coincide con el parámetro de la ruta
            command.Id = id;

            var actualizado = await _mediator.Send(command);
            if (!actualizado)
                return NotFound("No se pudo actualizar el paciente.");

            return NoContent(); // HTTP 204: operación exitosa sin contenido
        }

        // DELETE /api/paciente/eliminar/{id} - Eliminar un paciente
        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var eliminado = await _mediator.Send(new DeletePacienteCommand(id));
            if (!eliminado)
                return NotFound("No se pudo eliminar el paciente.");

            return NoContent(); // HTTP 204: operación exitosa
        }



        // POST /api/authpaciente/login - Login con CURP o Email
        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginAsync([FromBody] LoginPacienteQuery query)
        {
            if (query == null)
                return BadRequest("Datos de login no proporcionados");

            var token = await _mediator.Send(query);

            if (token == null)
                return Unauthorized("CURP/Email o contraseña incorrectos");

            return Ok(token); // Devuelve el token JWT
        }

        // POST /api/paciente/recuperar-contrasenia
        [HttpPost("recuperar-contrasenia")]
        public async Task<ActionResult<string>> RecuperarContraseniaPorTelefono([FromBody] RecoverPasswordByTelefonoCommand command)
        {
            if (command == null || string.IsNullOrEmpty(command.Telefono))
                return BadRequest("Debe proporcionar un número de teléfono válido.");

            try
            {
                var codigoTemporal = await _mediator.Send(command);
                // Aquí se podría enviar el código vía SMS/Email
                return Ok(new { Mensaje = "Código temporal generado correctamente.", CodigoTemporal = codigoTemporal });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error interno del servidor.", Detalle = ex.Message });
            }
        }

        // GET /api/paciente/verificar-email?token=XYZ
        [HttpGet("verificar-email")]
        public async Task<IActionResult> VerificarEmail([FromQuery] string token)
        {
            if (string.IsNullOrEmpty(token))
                return BadRequest("Token no proporcionado.");

            var paciente = await _mediator.Send(new VerificarEmailPacienteCommand(token));

            if (paciente == null)
                return BadRequest("Token inválido o expirado.");

            return Ok("Correo verificado correctamente.");
        }

    }
}
