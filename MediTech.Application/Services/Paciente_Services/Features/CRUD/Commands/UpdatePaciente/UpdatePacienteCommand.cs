namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Commands.UpdatePaciente
{
    /// <summary>
    /// Este comando representa la acción de actualizar la información de un paciente existente.
    /// </summary>
    public class UpdatePacienteCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string CURP { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }

        public UpdatePacienteCommand() { }

        public UpdatePacienteCommand(
            int id,
            string nombre,
            string apellidoPaterno,
            string apellidoMaterno,
            int edad,
            DateTime? fechaNacimiento,
            string curp,
            string email,
            string telefono,
            string genero)
        {
            Id = id;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Edad = edad;
            FechaNacimiento = fechaNacimiento;
            CURP = curp;
            Email = email;
            Telefono = telefono;
            Genero = genero;
        }
    }
}
