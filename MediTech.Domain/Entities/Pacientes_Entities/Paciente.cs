using System.Data;

namespace MediTech.Domain.Entities.Pacientes_Entities
{
    /// <summary>
    /// Estos son los campos de la tabla "Pacientes" de la base de datos
    /// </summary>
    public class Paciente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad {  get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string CURP { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }
        public DateTime? FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaActualizacion { get; set; } = DateTime.UtcNow;
        public bool EsActivo { get; set; }
        public string Contrasenia { get; set; }

        // === Nuevos campos para verificación de email ===
        public string? TokenVerificacionEmail { get; set; }
        public bool EmailVerificado { get; set; } = false;
    }
}
