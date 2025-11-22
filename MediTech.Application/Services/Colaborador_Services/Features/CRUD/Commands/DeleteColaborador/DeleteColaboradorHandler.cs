using MediTech.Application.Usuarios.Commands;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;

public class DeleteColaboradorHandler : IRequestHandler<DeleteColaboradorCommand, bool>
{
    private readonly IColaboradorRepository _colaboradorRepository;
    private readonly ILogger<DeleteColaboradorHandler> _logger;

    public DeleteColaboradorHandler(
        IColaboradorRepository colaboradorRepository,
        ILogger<DeleteColaboradorHandler> logger)
    {
        _colaboradorRepository = colaboradorRepository;
        _logger = logger;
    }

    public async Task<bool> Handle(DeleteColaboradorCommand request, CancellationToken cancellationToken)
    {
        // Reutilizamos el método existente DeleteAsync
        var eliminado = await _colaboradorRepository.DeleteAsync(request.ColaboradorId);

        if (eliminado)
            _logger.LogInformation($"Colaborador desactivado correctamente. ColaboradorID: {request.ColaboradorId}");
        else
            _logger.LogWarning($"No se encontró el colaborador para desactivar. ColaboradorID: {request.ColaboradorId}");

        return eliminado;
    }
}
