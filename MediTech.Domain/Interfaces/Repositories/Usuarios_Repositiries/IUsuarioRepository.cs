using System.Threading.Tasks;

namespace MediTech.Domain.Interfaces.Repositories.Usuarios_Repositiries;
public interface IUsuarioRepository
{
    Task<IEnumerable<Usuarios>> GetAllAsync();
    Task<Usuarios?> LoginAsync(string nombre, string contrasenia);
    Task<Usuarios?> GetByNombreAsync(string nombre);
    Task<IEnumerable<Modulos>> GetModulosPorRolAsync(int usuarioId);

    // ✅ Ajustado al tipo que devuelves en tu repositorio (solo string)
    Task<string?> GetTipoColaboradorByUserIdAsync(int usuarioId);
}
