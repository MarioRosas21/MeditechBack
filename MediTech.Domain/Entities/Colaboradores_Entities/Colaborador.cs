using MediTech.Domain.Entities.Especialidad_Entities;

namespace MediTech.Domain.Entities.Colaboradores_Entities
{
    /// <summary>
    /// Entidad que representa a los colaboradores del sistema.
    /// Contiene información personal, laboral y sus relaciones con otras entidades.
    /// </summary>
    public class Colaborador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        // ==============================
        // Datos personales
        // ==============================
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
        public string Direccion { get; set; }
        public string CURP { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }

        // ==============================
        // Datos laborales
        // ==============================
        public string MatriculaProfesional { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaActualizacion { get; set; } = DateTime.Now;
        public DateTime FechaContrato { get; set; } = DateTime.Now;
        public string Licencia { get; set; }
        public bool EsActivo { get; set; } = true;

        // ==============================
        // Relaciones y claves foráneas
        // ==============================

        // FK hacia la cede
        public int ID_Cede { get; set; }
        public Cede Cede { get; set; }

        // FK hacia la especialidad
        public int ID_Especialidad { get; set; }
        public Especialidad Especialidad { get; set; }

        // Relación uno a muchos con detalles del colaborador
        public ICollection<ColaboradorDetalle> ColaboradorDetalles { get; set; }

        // Relación uno a muchos con usuarios (un colaborador puede tener varios accesos)
        public ICollection<Usuarios> Usuarios { get; set; }

    }
}
