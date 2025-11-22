
using MediTech.Domain.Entities.Especialidad_Entities;


namespace MediTech.Application.Services.Especialidad_Services.Features.Queries
{
    /// <summary>
    /// Query para obtener todas las especialidades activas.
    /// </summary>
    public class GetAllEspecialidadesActivasQuery : IRequest<IEnumerable<Especialidad>>
    {
    }
}
