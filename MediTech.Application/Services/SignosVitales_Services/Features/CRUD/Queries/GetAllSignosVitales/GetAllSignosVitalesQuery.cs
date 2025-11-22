using MediatR;
using MediTech.Domain.Dtos.SignosVitales;

namespace MediTech.Application.Recetas.Queries
{
    public class GetAllSignosVitalesQuery : IRequest<IEnumerable<SignosVitalesDto>>
    {
    }
}
