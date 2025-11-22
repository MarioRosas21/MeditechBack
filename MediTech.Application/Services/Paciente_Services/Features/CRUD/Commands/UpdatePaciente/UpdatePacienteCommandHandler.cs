namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Commands.UpdatePaciente;

/// <summary>
/// El Handler procesa el comando UpdatePacienteCommand.
/// Contiene la lógica de negocio necesaria para actualizar un paciente existente.
/// </summary>

public class UpdatePacienteCommandHandler : IRequestHandler<UpdatePacienteCommand, bool>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdatePacienteCommandHandler> _logger;

    public UpdatePacienteCommandHandler(IPacienteRepository pacienteRepository, IMapper mapper, ILogger<UpdatePacienteCommandHandler> logger)
    {
        _pacienteRepository = pacienteRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdatePacienteCommand request, CancellationToken cancellationToken)
    {
        // Buscar el paciente por ID antes de actualizar
        var pacienteExistente = await _pacienteRepository.GetPacienteByIdAsync(request.Id);
        if (pacienteExistente == null)
        {
            _logger.LogWarning($"No se encontró el paciente con ID {request.Id} para actualizar.");
            return false;
        }

        // Mapear los nuevos valores del comando al paciente existente
        _mapper.Map(request, pacienteExistente);

        // Actualizar la fecha de modificación
        pacienteExistente.FechaActualizacion = DateTime.UtcNow;

        // Guardar los cambios en la base de datos
        bool actualizado = await _pacienteRepository.UpdateAsync(pacienteExistente);

        if (actualizado)
            _logger.LogInformation($"Paciente con ID {request.Id} actualizado correctamente.");
        else
            _logger.LogError($"Error al intentar actualizar el paciente con ID {request.Id}.");

        return actualizado;
    }
}
