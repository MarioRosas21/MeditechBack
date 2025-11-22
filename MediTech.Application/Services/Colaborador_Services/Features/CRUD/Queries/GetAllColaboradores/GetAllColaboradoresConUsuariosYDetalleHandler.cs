using MediTech.Application.Services.Colaborador_Services.Features.Queries;
using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Queries.GetAllColaboradores
{
    public class GetAllColaboradoresConUsuariosYDetalleHandler
        : IRequestHandler<GetAllColaboradoresConUsuariosYDetalleQuery, IEnumerable<ColaboradorConUsuarioYDetalleDto>>
    {
        private readonly IColaboradorRepository _repository;

        public GetAllColaboradoresConUsuariosYDetalleHandler(IColaboradorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ColaboradorConUsuarioYDetalleDto>> Handle(
            GetAllColaboradoresConUsuariosYDetalleQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetAllConUsuariosYDetalleAsync();
        }
    }
}
