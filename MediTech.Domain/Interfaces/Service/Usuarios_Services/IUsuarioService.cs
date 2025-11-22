namespace MediTech.Domain.Interfaces.Service.Usuarios_Services;
public interface IUsuarioService
{
     Task<IEnumerable<Usuarios>> GetAllAsync();
     Task<LoginDto> LoginAsync(string Nombre, string Contrasenia);
}
