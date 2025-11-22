namespace MediTech.Domain.Dtos
{
    /// <summary>
    /// Este es el Dto (Data Transfer Object), nos ayuda a que en vez de mostrar solo lo necesario en el login
    /// </summary>
    public class LoginDto
    {
        public bool Exito { get; set; }       // Resultado del login
        public string Mensaje { get; set; }   // Mensaje al cliente
        public string? Token { get; set; }    // Token de autenticación
        public string? TipoColaborador { get; set; }  // 👈 Solo el nombre o rol del colaborador
    }

    /// <summary>
    /// Datos que el cliente envía para intentar iniciar sesión
    /// </summary>
    public class LoginCommandDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
    }
}
