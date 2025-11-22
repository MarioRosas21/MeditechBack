namespace MediTech.Domain.Entities.Cede_Entities;
public class Cede
{
    public int ID { get; set; }
    public string Direccion { get; set; } 
    public string Ciudad { get; set; } 
    public string Estado { get; set; } 
    public string CodigoPostal { get; set; }
    public string Telefono { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime? FechaActualizacion { get; set; }
    public bool EsActivo { get; set; } = true;
}
