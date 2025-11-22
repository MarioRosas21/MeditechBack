using MediatR;
using MediTech.Domain.Dtos.Recetas;

namespace MediTech.Application.Services.Recetas_Services.Features.CRUD.Queries.GetAllRecetas
{
    public class GetAllRecetasQuery : IRequest<IEnumerable<RecetasDto>>
    {
    }
}
