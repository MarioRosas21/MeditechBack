using MediTech.Domain.Dtos.Colaboradores;


namespace MediTech.Application.Interfaces.Services.Especialidad_Services
{
    public interface IEspecialidadService
    {
        /// <summary>
        /// Obtiene todos los doctores que pertenecen a una especialidad específica.
        /// </summary>
        /// <param name="idEspecialidad">ID de la especialidad.</param>
        /// <returns>Lista de doctores con su información detallada.</returns>
        Task<IEnumerable<ColaboradorConUsuarioYDetalleDto>> ObtenerDoctoresPorEspecialidadAsync(int idEspecialidad);
    }
}
