using MediTech.Application.Services.Usuario_Services;

namespace MediTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly VerificarRolService _rolService;

        public RolController(VerificarRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet("verificar/{usuarioId}")]
        public async Task<IActionResult> VerificarRol(int usuarioId)
        {
            var resultado = await _rolService.ObtenerRolYModulosDeUsuario(usuarioId);

            if (resultado == null)
                return NotFound(new { mensaje = "Usuario no encontrado o sin rol asignado" });

            return Ok(resultado);
        }
    }
}
