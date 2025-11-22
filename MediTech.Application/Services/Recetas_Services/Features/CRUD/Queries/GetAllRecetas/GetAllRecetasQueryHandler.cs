using MediatR;
using MediTech.Application.Common.Interfaces.Repositories;
using MediTech.Domain.Dtos.Recetas;
using MediTech.Infrastructure.Persistence.Recetas_Persistences;

namespace MediTech.Application.Services.Recetas_Services.Features.CRUD.Queries.GetAllRecetas
{
    public class GetAllRecetasQueryHandler
        : IRequestHandler<GetAllRecetasQuery, IEnumerable<RecetasDto>>
    {
        private readonly IRecetasRepository _repository;

        public GetAllRecetasQueryHandler(IRecetasRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RecetasDto>> Handle(
            GetAllRecetasQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
