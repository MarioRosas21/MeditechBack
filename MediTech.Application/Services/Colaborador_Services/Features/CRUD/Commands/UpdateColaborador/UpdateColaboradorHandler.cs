using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Commands.UpdateColaborador
{
    /// <summary>
    /// El Handler procesa el comando UpdateColaboradorCommand.
    /// Contiene la lógica de negocio necesaria para actualizar un colaborador existente.
    /// </summary>
    public class UpdateColaboradorHandler : IRequestHandler<UpdateColaboradorCommand, bool>
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateColaboradorHandler> _logger;

        public UpdateColaboradorHandler(
            IColaboradorRepository colaboradorRepository,
            IMapper mapper,
            ILogger<UpdateColaboradorHandler> logger)
        {
            _colaboradorRepository = colaboradorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateColaboradorCommand request, CancellationToken cancellationToken)
        {
            // Buscar el colaborador por ID antes de actualizar
            var colaboradorExistente = await _colaboradorRepository.GetByIdAsync(request.Id);
            if (colaboradorExistente == null)
            {
                _logger.LogWarning($"No se encontró el colaborador con ID {request.Id} para actualizar.");
                return false;
            }

            // Mapear los nuevos valores del DTO al colaborador existente
            _mapper.Map(request.Dto, colaboradorExistente);

            // Actualizar la fecha de modificación
            colaboradorExistente.FechaActualizacion = DateTime.UtcNow;

            // Guardar los cambios en la base de datos
            await _colaboradorRepository.UpdateAsync(colaboradorExistente);

            _logger.LogInformation($"Colaborador con ID {request.Id} actualizado correctamente.");

            return true;
        }
    }
}
