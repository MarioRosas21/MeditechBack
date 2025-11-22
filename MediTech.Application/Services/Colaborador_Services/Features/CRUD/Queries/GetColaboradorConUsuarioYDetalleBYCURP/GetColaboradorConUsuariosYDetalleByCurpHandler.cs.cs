using MediTech.Application.Colaboradores.Queries;
using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Queries.GetColaboradorConUsuarioYDetalleBYCURP
{
    public class GetColaboradorConUsuariosYDetalleByCurpHandler
        : IRequestHandler<GetColaboradorConUsuariosYDetalleByCurpQuery, ColaboradorConUsuarioYDetalleDto?>
    {
        private readonly IColaboradorRepository _repository;

        public GetColaboradorConUsuariosYDetalleByCurpHandler(IColaboradorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ColaboradorConUsuarioYDetalleDto?> Handle(
            GetColaboradorConUsuariosYDetalleByCurpQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetByCurpConUsuariosYDetalleAsync(request.Curp);
        }
    }
}
