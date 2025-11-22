using MediatR;
using MediTech.Application.Common.Interfaces.Repositories;
using MediTech.Domain.Dtos.Recetas;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediTech.Application.Services.Recetas_Services.Features.CRUD.Queries.GetRecetasByIdPaciente
{
    public class GetRecetasByPacienteHandler : IRequestHandler<GetRecetasByPacienteQuery, IEnumerable<RecetasDto>>
    {
        private readonly IRecetasRepository _recetasRepository;

        public GetRecetasByPacienteHandler(IRecetasRepository recetasRepository)
        {
            _recetasRepository = recetasRepository;
        }

        public async Task<IEnumerable<RecetasDto>> Handle(GetRecetasByPacienteQuery request, CancellationToken cancellationToken)
        {
            // Llamamos al repositorio que ya tienes implementado
            return await _recetasRepository.GetByPacienteIdAsync(request.ID_Paciente);
        }
    }
}
