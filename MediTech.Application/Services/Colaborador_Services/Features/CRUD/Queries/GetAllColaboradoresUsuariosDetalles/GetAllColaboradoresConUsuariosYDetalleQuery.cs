using MediatR;
using MediTech.Domain.Dtos.Colaboradores;
using System.Collections.Generic;

namespace MediTech.Application.Services.Colaborador_Services.Features.Queries
{
    /// <summary>
    /// Query para obtener todos los colaboradores con usuario y detalle
    /// </summary>
    public class GetAllColaboradoresConUsuariosYDetalleQuery : IRequest<IEnumerable<ColaboradorConUsuarioYDetalleDto>>
    {
        // No necesita parámetros por ahora
    }
}
