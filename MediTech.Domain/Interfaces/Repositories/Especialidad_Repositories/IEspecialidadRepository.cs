using MediTech.Domain.Entities.Especialidad_Entities;


namespace MediTech.Domain.Interfaces.Repositories.Especialidad_Repositories
{
    public interface IEspecialidadRepository
    {
        /// <summary>
        /// Obtiene todas las especialidades activas.
        /// </summary>
        Task<IEnumerable<Especialidad>> GetAllActivasAsync();
    }
}
