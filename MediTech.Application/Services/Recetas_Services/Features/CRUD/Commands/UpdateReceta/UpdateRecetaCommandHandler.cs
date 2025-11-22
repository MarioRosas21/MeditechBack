using MediatR;
using MediTech.Application.Common.Interfaces.Repositories;
using MediTech.Domain.Dtos.Recetas;
using MediTech.Domain.Entities.Recetas_Entities;

namespace MediTech.Application.Recetas.Commands.UpdateReceta
{
    public class UpdateRecetaCommandHandler : IRequestHandler<UpdateRecetaCommand, bool>
    {
        private readonly IRecetasRepository _recetasRepository;

        public UpdateRecetaCommandHandler(IRecetasRepository recetasRepository)
        {
            _recetasRepository = recetasRepository;
        }

        public async Task<bool> Handle(UpdateRecetaCommand request, CancellationToken cancellationToken)
        {
            var recetaActualizada = new MediTech.Domain.Entities.Recetas_Entities.Recetas
            {
                ID = request.Data.ID,
                ID_Paciente = request.Data.ID_Paciente,
                ID_Doctor = request.Data.ID_Doctor,
                ID_SignosVitales = request.Data.ID_SignosVitales,
                Tratamientos = request.Data.Tratamientos,
                FechaActualizacion = DateTime.Now
            };

            return await _recetasRepository.UpdateAsync(recetaActualizada);
        }
    }
}
