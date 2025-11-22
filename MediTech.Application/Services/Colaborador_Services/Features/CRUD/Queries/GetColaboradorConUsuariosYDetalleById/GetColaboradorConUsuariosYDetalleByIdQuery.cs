using MediatR;
using MediTech.Domain.Dtos.Colaboradores;

namespace MediTech.Application.Services.Colaborador_Services.Features.Queries
{
    public class GetColaboradorConUsuariosYDetalleByIdQuery : IRequest<ColaboradorConUsuarioYDetalleDto?>
    {
        public int Id { get; set; }

        public GetColaboradorConUsuariosYDetalleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
