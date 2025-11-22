using System.ComponentModel.DataAnnotations.Schema;
using MediTech.Domain.Entities.Colaboradores_Entities;

namespace MediTech.Domain.Entities
{
    public class SignosVitales
    {
        public int ID { get; set; }
        public double Temperatura { get; set; }
        public double Presion { get; set; }
        public double Estatura { get; set; }
        public string Alergias { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [ForeignKey("ID_Colaborador")]
        public Colaborador Colaborador { get; set; }
        public int ID_Colaborador { get; set; }

        [ForeignKey("ID_Paciente")]
        public Paciente Paciente { get; set; }
        public int ID_Paciente { get; set; }
    }
}
