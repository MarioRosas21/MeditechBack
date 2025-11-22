namespace MediTech.Domain.Dtos.Recetas
{
    public class UpdateRecetaDto
    {
        public int ID { get; set; } // Este es el ID de la receta que quieres actualizar
        public int ID_Paciente { get; set; }
        public int ID_Doctor { get; set; }
        public int ID_SignosVitales { get; set; }
        public string Tratamientos { get; set; }
    }
}
