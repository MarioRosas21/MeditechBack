namespace MediTech.Domain.Entities.Especialidad_Entities;
public class Especialidad
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    public bool EsActivo { get; set; } = true;
}
