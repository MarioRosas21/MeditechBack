using MediatR;
using MediTech.Domain.Entities.Colaboradores_Entities;

namespace MediTech.Application.Queries.Colaboradores
{
    /// <summary>
    /// Query para obtener un colaborador por su ID
    /// </summary>
    public class GetColaboradorByIdQuery : IRequest<Colaborador>
    {
        public int Id { get; set; }

        public GetColaboradorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
