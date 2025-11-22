using MediatR;
using MediTech.Application.Common.Interfaces.Repositories;
using MediTech.Domain.Dtos.Recetas;
using MediTech.Domain.Entities.Recetas_Entities;

namespace MediTech.Application.Recetas.Commands.CreateReceta
{
    public class CreateRecetaCommandHandler : IRequestHandler<CreateRecetaCommand, bool>
    {
        private readonly IRecetasRepository _recetasRepository;

        public CreateRecetaCommandHandler(IRecetasRepository recetasRepository)
        {
            _recetasRepository = recetasRepository;
        }

        public async Task<bool> Handle(CreateRecetaCommand request, CancellationToken cancellationToken)
        {
            var nuevaReceta = new MediTech.Domain.Entities.Recetas_Entities.Recetas

            {
                ID_Paciente = request.Data.ID_Paciente,
                ID_Doctor = request.Data.ID_Doctor,
                Tratamientos = request.Data.Tratamientos,
                ID_SignosVitales = request.Data.ID_SignosVitales ?? 0,
                FechaCreacion = DateTime.Now,
                FechaActualizacion = DateTime.Now
            };

            return await _recetasRepository.CreateAsync(nuevaReceta);
        }
    }
}
