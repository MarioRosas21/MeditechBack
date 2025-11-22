using MediatR;
using MediTech.Domain.Entities.Colaboradores_Entities;
using System.Collections.Generic;

namespace MediTech.Application.Queries.Colaboradores
{
    /// <summary>
    /// Query para obtener todos los colaboradores activos
    /// </summary>
    public class GetAllColaboradoresQuery : IRequest<IEnumerable<Colaborador>>
    {
        // Si se desea agregar filtros en el futuro, se pueden incluir aquí
    }
}
