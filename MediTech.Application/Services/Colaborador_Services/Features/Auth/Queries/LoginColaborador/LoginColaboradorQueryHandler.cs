namespace MediTech.Application.Services.Colaborador_Services.Features.Auth.Queries.LoginColaborador;
public class LoginColaboradorQueryHandler : IRequestHandler<LoginColaboradorQuery, LoginDto>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly JwtService _jwtService;

    public LoginColaboradorQueryHandler(IUsuarioRepository usuarioRepository, JwtService jwtService)
    {
        _usuarioRepository = usuarioRepository;
        _jwtService = jwtService;
    }

    public async Task<LoginDto> Handle(LoginColaboradorQuery request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Login] Intentando autenticar usuario: '{request.Nombre}'");

        // 1. Buscar usuario
        var usuarioExistente = await _usuarioRepository.GetByNombreAsync(request.Nombre);
        if (usuarioExistente == null)
        {
            Console.WriteLine($"[Login] Usuario '{request.Nombre}' no existe.");
            return new LoginDto
            {
                Exito = false,
                Mensaje = "El usuario no existe.",
                Token = null,
                TipoColaborador = null
            };
        }

        // 2. Verificar contraseña
        bool contraseniaValida = BCrypt.Net.BCrypt.Verify(request.Contrasenia, usuarioExistente.Contrasenia);
        if (!contraseniaValida)
        {
            Console.WriteLine($"[Login] Contraseña incorrecta para '{request.Nombre}'.");
            return new LoginDto
            {
                Exito = false,
                Mensaje = "Contraseña incorrecta.",
                Token = null,
                TipoColaborador = null
            };
        }

        // 3. Obtener rol del colaborador
        var tipoColaborador = await _usuarioRepository.GetTipoColaboradorByUserIdAsync(usuarioExistente.ID);
        if (string.IsNullOrWhiteSpace(tipoColaborador))
        {
            return new LoginDto
            {
                Exito = false,
                Mensaje = "El usuario no tiene un rol asignado.",
                Token = null,
                TipoColaborador = null
            };
        }

        // 4. Crear claims extra (incluye el rol)
        var claimsExtra = new[]
        {
            new Claim(ClaimTypes.Role, tipoColaborador)
        };

        // 5. Generar token
        var token = _jwtService.GenerateToken(usuarioExistente.Nombre, claimsExtra);

        Console.WriteLine($"[Login] Usuario '{request.Nombre}' autenticado. Rol: {tipoColaborador}");

        // 6. Retornar DTO
        return new LoginDto
        {
            Exito = true,
            Mensaje = "Inicio de sesión exitoso.",
            Token = token,
            TipoColaborador = tipoColaborador
        };
    }
}
