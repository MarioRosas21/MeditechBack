using MediTech.Application.Queries.Colaboradores;
using MediTech.Domain.Entities.Colaboradores_Entities;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;


namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Queries.GetAllColaboradores
{
    /// <summary>
    /// Handler para procesar la consulta de obtener todos los colaboradores activos
    /// </summary>
    public class GetAllColaboradoresHandler : IRequestHandler<GetAllColaboradoresQuery, IEnumerable<Colaborador>>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public GetAllColaboradoresHandler(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<IEnumerable<Colaborador>> Handle(GetAllColaboradoresQuery request, CancellationToken cancellationToken)
        {
            // Llamada al repositorio para traer todos los colaboradores activos
            var colaboradores = await _colaboradorRepository.GetAllAsync();
            return colaboradores;
        }
    }
}
