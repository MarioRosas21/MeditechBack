using MediTech.Application.Services.Colaborador_Services.Features.Auth.Queries.LoginColaborador;
using MediTech.Domain.Entities.Usuarios_Entities;
namespace MediTech.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly IMediator _mediator;
    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginDto>> Login([FromBody] LoginColaboradorQuery request)
    {
        var result = await _mediator.Send(request);
        if (!result.Exito)
            return Unauthorized(result);

        return Ok(result);
    }


}
