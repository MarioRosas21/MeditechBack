using MediTech.Domain.Dtos.Colaboradores;
using MediatR;
using System.Collections.Generic;

namespace MediTech.Application.Features.Colaboradores.Commands
{
    // ✅ Comando sin parámetros, solo solicita la lista
    public class GetAllTipoColaboradoresCommand : IRequest<IEnumerable<TipoColaboradorDto>>
    {
    }
}
