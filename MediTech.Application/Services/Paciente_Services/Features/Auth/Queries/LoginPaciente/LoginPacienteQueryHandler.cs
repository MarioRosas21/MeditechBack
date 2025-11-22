namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Queries.LoginPaciente;
public class LoginPacienteQueryHandler : IRequestHandler<LoginPacienteQuery, string>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly JwtService _jwtService;

    public LoginPacienteQueryHandler(IPacienteRepository pacienteRepository, JwtService jwtService)
    {
        _pacienteRepository = pacienteRepository;
        _jwtService = jwtService;
    }

    public async Task<string> Handle(LoginPacienteQuery request, CancellationToken cancellationToken)
    {
        // Buscar paciente por Email o CURP
        Paciente paciente = null;

        if (!string.IsNullOrEmpty(request.Email))
            paciente = await _pacienteRepository.GetPacienteByEmailAsync(request.Email);
        else if (!string.IsNullOrEmpty(request.CURP))
            paciente = await _pacienteRepository.GetPacienteByCURPAsync(request.CURP);

        if (paciente == null)
            return null;

        // Validacion email no verificado
        if (!paciente.EmailVerificado)
            return "EMAIL_NO_VERIFICADO";

        // Verificar contraseña (nota: usar hashing en producción)
        if (paciente.Contrasenia != request.Contrasenia)
            return null;

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, $"{paciente.Nombre} {paciente.ApellidoPaterno}"),
            new Claim(ClaimTypes.Role, "Paciente")
        };

        // Generar token usando JwtService con los claims
        var token = _jwtService.GenerateToken(paciente.ID.ToString(), claims);

        return token;
    }
}
