namespace MediTech.Domain.Dtos.Recetas
{
    public class SignosVitalesUpdateDto
    {
        public int ID { get; set; }
        public double Temperatura { get; set; }
        public double Presion { get; set; }
        public double Estatura { get; set; }
        public string Alergias { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public int ID_Colaborador { get; set; }
        public int ID_Paciente { get; set; }
    }
}
