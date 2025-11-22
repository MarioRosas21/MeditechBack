using MediatR;
using MediTech.Domain.Dtos.Colaboradores;

namespace MediTech.Application.Colaboradores.Queries
{
    public record GetColaboradorConUsuariosYDetalleByCurpQuery(string Curp)
        : IRequest<ColaboradorConUsuarioYDetalleDto?>;
}
