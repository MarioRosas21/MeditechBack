using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Entities.Colaboradores_Entities;

namespace MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories
{
    /// <summary>
    /// Define los contratos que debe implementar cualquier repositorio de colaboradores.
    /// Contiene operaciones CRUD, validaciones y consultas extendidas con usuarios y detalles.
    /// </summary>
    public interface IColaboradorRepository
    {
        /// <summary>
        /// Obtiene todos los colaboradores registrados.
        /// </summary>
        Task<IEnumerable<Colaborador>> GetAllAsync();

        /// <summary>
        /// Obtiene un colaborador por su ID (solo si está activo).
        /// </summary>
        Task<Colaborador?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega un nuevo colaborador a la base de datos.
        /// </summary>
        Task AddAsync(Colaborador colaborador);

        /// <summary>
        /// Actualiza los datos de un colaborador existente.
        /// </summary>
        Task UpdateAsync(Colaborador colaborador);

        /// <summary>
        /// Realiza un borrado lógico (desactiva al colaborador).
        /// </summary>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Obtiene una lista de colaboradores filtrados por estado activo/inactivo.
        /// </summary>
        Task<IEnumerable<Colaborador>> GetAllWithFilterAsync(bool? activo = null);

        /// <summary>
        /// Registra un colaborador junto con su usuario y detalle profesional.
        /// </summary>
        Task<RegistroResultadoDto> RegistrarUsuarioCompletoAsync(CrearUsuarioDto dto);

        /// <summary>
        /// Devuelve todos los colaboradores incluyendo sus usuarios, roles y sede.
        /// </summary>
        Task<IEnumerable<ColaboradorConUsuarioYDetalleDto>> GetAllConUsuariosYDetalleAsync();

        /// <summary>
        /// Devuelve un colaborador específico por ID con su usuario, rol y sede.
        /// </summary>
        Task<ColaboradorConUsuarioYDetalleDto?> GetByIdConUsuariosYDetalleAsync(int id);

        /// <summary>
        /// Devuelve un colaborador específico por CURP con su usuario, rol y sede.
        /// </summary>
        Task<ColaboradorConUsuarioYDetalleDto?> GetByCurpConUsuariosYDetalleAsync(string curp);

        /// <summary>
        /// Devuelve todos los colaboradores activos asociados a una especialidad específica.
        /// </summary>
        Task<IEnumerable<ColaboradorConUsuarioYDetalleDto>> GetColaboradoresPorEspecialidadAsync(int idEspecialidad);

        /// <summary>
        /// Verifica si ya existe un colaborador o usuario con datos duplicados.
        /// </summary>
        Task<bool> ExisteUsuarioAsync(string nombreUsuario, string email, string telefono, string curp);

        /// <summary>
        /// Valida si existen registros duplicados (email, teléfono o usuario) antes de registrar un nuevo colaborador.
        /// </summary>
        Task<string?> ValidarDuplicadosAsync(string email, string telefono, string nombreUsuario);

        Task<bool> ReactivarColaboradorYUsuarioAsync(int id);
    }
}
