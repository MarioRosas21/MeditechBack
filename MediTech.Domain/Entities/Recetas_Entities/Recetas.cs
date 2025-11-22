using System;
using System.ComponentModel.DataAnnotations.Schema;
using MediTech.Domain.Entities.Colaboradores_Entities;

namespace MediTech.Domain.Entities.Recetas_Entities
{
    public class Recetas
    {
        public int ID { get; set; }
        public string Tratamientos { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;

        [ForeignKey("ID_Paciente")]
        public Paciente Paciente { get; set; }
        public int ID_Paciente { get; set; }

        [ForeignKey("ID_Doctor")]   // aquí el nombre exacto de la columna en DB
        [Column("ID_Doctor")]       // importante
        public Colaborador Colaborador { get; set; }
        public int ID_Doctor { get; set; }  // coincide con la DB

        [ForeignKey("ID_SignosVitales")]
        public SignosVitales SignosVitales { get; set; }
        public int ID_SignosVitales { get; set; }
    }
}
