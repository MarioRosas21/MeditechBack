using MediTech.Application.Features.Colaboradores.Commands;
using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;
using MediatR;

namespace MediTech.Application.Features.Colaboradores.Handlers
{
    public class GetAllTipoColaboradoresHandler : IRequestHandler<GetAllTipoColaboradoresCommand, IEnumerable<TipoColaboradorDto>>
    {
        private readonly ITipoColaboradorRepository _repository;

        public GetAllTipoColaboradoresHandler(ITipoColaboradorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoColaboradorDto>> Handle(GetAllTipoColaboradoresCommand request, CancellationToken cancellationToken)
        {
            var tipos = await _repository.GetAllAsync();
            return tipos;
        }
    }
}
