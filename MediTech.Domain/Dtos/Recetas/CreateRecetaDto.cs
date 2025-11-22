namespace MediTech.Domain.Dtos.Recetas
{
    public class CreateRecetaDto
    {
        public int ID_Paciente { get; set; }
        public int ID_Doctor { get; set; }
        public string Tratamientos { get; set; }
        public int? ID_SignosVitales { get; set; } // opcional si aún no existe
    }
}
