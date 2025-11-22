namespace MediTech.Domain.Entities.Colaboradores_Entities;
public class TipoColaboradores
{
    public int ID { get; set; }
    public string Tipo { get; set; }

    public ICollection<ColaboradorDetalle> ColaboradorDetalles { get; set; }
}
