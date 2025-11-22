using MediTech.Application.Services.Colaborador_Services.Features.Queries;
using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Queries.GetColaboradorConUsuariosYDetalleById
{
    public class GetColaboradorConUsuariosYDetalleByIdHandler : IRequestHandler<GetColaboradorConUsuariosYDetalleByIdQuery, ColaboradorConUsuarioYDetalleDto?>
    {
        private readonly IColaboradorRepository _repository;

        public GetColaboradorConUsuariosYDetalleByIdHandler(IColaboradorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ColaboradorConUsuarioYDetalleDto?> Handle(GetColaboradorConUsuariosYDetalleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdConUsuariosYDetalleAsync(request.Id);
        }
    }
}
