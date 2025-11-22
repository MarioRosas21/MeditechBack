namespace MediTech.Application.Services.Usuario_Services
{
    public class VerificarRolService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public VerificarRolService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<object?> ObtenerRolYModulosDeUsuario(int usuarioId)
        {
            var rol = await _usuarioRepository.GetTipoColaboradorByUserIdAsync(usuarioId);
            if (rol == null)
                return null;

            var modulos = await _usuarioRepository.GetModulosPorRolAsync(usuarioId);

            return new
            {
                UsuarioId = usuarioId,
                Rol = rol,
                ModulosDisponibles = modulos.Select(m => new
                {
                    m.ID,
                    m.Nombre,
                    m.Codigo
                })
            };
        }
    }

}
