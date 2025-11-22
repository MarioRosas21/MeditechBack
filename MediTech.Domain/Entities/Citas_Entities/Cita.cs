namespace MediTech.Domain.Entities.Citas_Entities;
public class Cita
{
    [Key]
    public int ID { get; set; }

    public int ID_Paciente { get; set; }  // FK explícita
    public Paciente Paciente { get; set; }

    public int ID_Cede { get; set; }      // FK explícita
    public Cede Cede { get; set; }

    public int ID_Disponible { get; set; } // FK explícita
    public Disponibilidad Disponibilidad { get; set; }
    public DateTime FechaCita { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public string Motivo { get; set; }
}
