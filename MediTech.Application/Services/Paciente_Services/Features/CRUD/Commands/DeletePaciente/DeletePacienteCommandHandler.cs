namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Commands.DeletePaciente;

/// <summary>
/// Contiene la lógica de negocio necesaria para eliminar un paciente del sistema.
/// Interactúa con el repositorio ("IPacienteRepository"/>) para realizar la operación
/// sobre la base de datos, y usa el logger para registrar el resultado.
/// </summary>
public class DeletePacienteCommandHandler : IRequestHandler<DeletePacienteCommand, bool>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly ILogger<DeletePacienteCommandHandler> _logger;

    public DeletePacienteCommandHandler(IPacienteRepository pacienteRepository, ILogger<DeletePacienteCommandHandler> logger)
    {
        _pacienteRepository = pacienteRepository;
        _logger = logger;
    }

    public async Task<bool> Handle(DeletePacienteCommand request, CancellationToken cancellationToken)
    {
        // Buscar el paciente por ID antes de eliminar
        Paciente? paciente = await _pacienteRepository.GetPacienteByIdAsync(request.Id);
        if (paciente == null)
        {
            _logger.LogWarning($"No se encontró el paciente con ID {request.Id} para eliminar.");
            return false;
        }

        // Eliminar el registro del paciente
        bool eliminado = await _pacienteRepository.DeleteAsync(paciente);

        if (eliminado)
            _logger.LogInformation($"Paciente con ID {request.Id} eliminado correctamente.");
        else
            _logger.LogError($"Error al intentar eliminar el paciente con ID {request.Id}.");

        return eliminado;
    }
}
