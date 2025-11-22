namespace MediTech.Domain.Dtos.SignosVitales
{
    public class SignosVitalesDto
    {
        // ==============================
        // SIGNOS VITALES
        // ==============================
        public int IdSignosVitales { get; set; }
        public double Temperatura { get; set; }
        public double Presion { get; set; }
        public double Estatura { get; set; }
        public string Alergias { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // ==============================
        // COLABORADOR (quien registró)
        // ==============================
        public int ID_Colaborador { get; set; }
        public string ColaboradorNombre { get; set; }
        public string ColaboradorApellidoPaterno { get; set; }
        public string ColaboradorApellidoMaterno { get; set; }
        public int ColaboradorEdad { get; set; }
        public string ColaboradorTelefono { get; set; }
        public string ColaboradorEmail { get; set; }
        public string MatriculaProfesional { get; set; }

        // ==============================
        // PACIENTE
        // ==============================
        public int ID_Paciente { get; set; }
        public string PacienteNombre { get; set; }
        public string PacienteApellidoPaterno { get; set; }
        public string PacienteApellidoMaterno { get; set; }
        public int PacienteEdad { get; set; }
        public DateTime? PacienteFechaNacimiento { get; set; }
        public string PacienteTelefono { get; set; }
    }
}
