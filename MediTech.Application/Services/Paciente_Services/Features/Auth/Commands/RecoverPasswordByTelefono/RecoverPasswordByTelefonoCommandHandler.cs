namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Commands.RecoverPasswordByTelefono;

public class RecoverPasswordByTelefonoCommandHandler : IRequestHandler<RecoverPasswordByTelefonoCommand, string>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly ILogger<RecoverPasswordByTelefonoCommandHandler> _logger;

    public RecoverPasswordByTelefonoCommandHandler(IPacienteRepository pacienteRepository, ILogger<RecoverPasswordByTelefonoCommandHandler> logger)
    {
        _pacienteRepository = pacienteRepository;
        _logger = logger;
    }

    public async Task<string> Handle(RecoverPasswordByTelefonoCommand request, CancellationToken cancellationToken)
    {
        var paciente = await _pacienteRepository.GetPacienteByTelefonoAsync(request.Telefono);

        if (paciente == null)
        {
            _logger.LogWarning($"Intento de recuperación de contraseña fallido. No se encontró paciente con teléfono {request.Telefono}.");
            throw new KeyNotFoundException("No se encontró un paciente con ese teléfono.");
        }

        // Generar un código temporal de 6 dígitos
        var codigoTemporal = new Random().Next(100000, 999999).ToString();

        // Aquí normalmente se enviaría el código por SMS o email
        _logger.LogInformation($"Código temporal para paciente {paciente.ID} generado: {codigoTemporal}");

        // Podrías almacenar el código en la base de datos con fecha de expiración para validación posterior
        return codigoTemporal;
    }
}
