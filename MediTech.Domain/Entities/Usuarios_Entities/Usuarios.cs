using MediTech.Domain.Entities.Colaboradores_Entities;

namespace MediTech.Domain.Entities.Usuarios_Entities
{
    /// <summary>
    /// Esta es la tabla que esta en la base de datos de los Usuarios
    /// </summary>
    public class Usuarios
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaActualizacion { get; set; } = DateTime.Now;
        public bool EsActivo { get; set; }
        public DateTime? UltimoLogin { get; set; }
        public string Telefono { get; set; }

        // Relación con Colaborador (antes "Persona")
        public int? ID_Persona { get; set; } // FK opcional
        public Colaborador Persona { get; set; }

        // Relación con Módulo
        public int ID_Modulo { get; set; }
        public Modulos Modulo { get; set; }
    }
}
