using MediTech.Domain.Entities.Colaboradores_Entities;

namespace MediTech.Domain.Entities.Citas_Entities;
public class Disponibilidad
{
    [Key]
    public int ID { get; set; }

    // FK explícita
    public int ID_Colaborador { get; set; }
    public Colaborador Colaborador { get; set; }

    public int ID_Paciente { get; set; }
    public Paciente Paciente { get; set; }

    public string HoraInicio { get; set; }
    public string HoraFin { get; set; }
}

