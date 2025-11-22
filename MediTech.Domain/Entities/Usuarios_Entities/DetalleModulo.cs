namespace MediTech.Domain.Entities.Usuarios_Entities
{
    public class DetalleModulo
    {
        public int ID { get; set; }
        public int ID_Modulo { get; set; }
        public int ID_Rol { get; set; }
        public bool Crear { get; set; }
        public bool Leer { get; set; }
        public bool Eliminar { get; set; }
        public bool Actualizar { get; set; }

        public Modulos Modulo { get; set; }
        public Roles Rol { get; set; }

    }
}
