namespace MediTech.Domain.Entities.Citas_Entities;
public class CitasEstadoDetalle
{
    [Key]
    public int ID { get; set; }

    // FK hacia EstatusCita
    public int ID_Estatus { get; set; }
    [ForeignKey(nameof(ID_Estatus))]
    public EstatusCita EstatusCita { get; set; }

    // FK hacia Cita
    public int ID_Cita { get; set; }
    [ForeignKey(nameof(ID_Cita))]
    public Cita Cita { get; set; }

    public DateTime FechaCambio { get; set; } = DateTime.Now;
    public string Observacion { get; set; }
}
