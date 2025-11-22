namespace MediTech.Domain.Dtos.Colaboradores
{
    public class ColaboradorDto
    {
        public int ID { get; set; }

        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string CURP { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }

        public string MatriculaProfesional { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime FechaContrato { get; set; }
        public string Licencia { get; set; }
        public bool EsActivo { get; set; }

        // Estas solo llevan el ID, NO la entidad completa
        public int ID_Cede { get; set; }
        public int ID_Especialidad { get; set; }
    }
}
