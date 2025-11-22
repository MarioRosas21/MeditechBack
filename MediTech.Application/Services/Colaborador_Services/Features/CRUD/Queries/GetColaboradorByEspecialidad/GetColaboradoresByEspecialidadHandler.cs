using MediatR;
using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Queries.GetColaboradoresByEspecialidad
{
    /// <summary>
    /// Handler que procesa la consulta para obtener colaboradores por especialidad.
    /// </summary>
    public class GetColaboradoresByEspecialidadHandler
        : IRequestHandler<GetColaboradoresByEspecialidadQuery, IEnumerable<ColaboradorConUsuarioYDetalleDto>>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public GetColaboradoresByEspecialidadHandler(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<IEnumerable<ColaboradorConUsuarioYDetalleDto>> Handle(
            GetColaboradoresByEspecialidadQuery request,
            CancellationToken cancellationToken)
        {
            // 🔍 Llama al repositorio para traer los colaboradores por ID de especialidad
            var colaboradores = await _colaboradorRepository.GetColaboradoresPorEspecialidadAsync(request.IdEspecialidad);

            return colaboradores;
        }
    }
}
