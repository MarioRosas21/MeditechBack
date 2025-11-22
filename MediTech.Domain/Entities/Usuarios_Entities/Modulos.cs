namespace MediTech.Domain.Entities.Usuarios_Entities
{
    public class Modulos
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool EsActivo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public ICollection<DetalleModulo> Detalles { get; set; }
    }
}
