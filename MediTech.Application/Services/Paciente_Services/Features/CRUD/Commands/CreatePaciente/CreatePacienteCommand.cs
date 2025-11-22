namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Commands.CreatePaciente
{
    /// <summary>
    /// Representa el comando que se envía desde la capa de presentación (endpoint HTTP POST)
    /// para crear un nuevo registro de paciente en el sistema.
    /// </summary>
    public class CreatePacienteCommand : IRequest<int>
    {
        /// <summary>
        /// Nombre del paciente.
        /// </summary>
        /// <example>Juan</example>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido paterno del paciente.
        /// </summary>
        /// <example>Pérez</example>
        public string ApellidoPaterno { get; set; }

        /// <summary>
        /// Apellido materno del paciente.
        /// </summary>
        /// <example>Ramírez</example>
        public string ApellidoMaterno { get; set; }

        /// <summary>
        /// Edad actual del paciente.
        /// </summary>
        /// <example>35</example>
        public int Edad { get; set; }

        /// <summary>
        /// Fecha de nacimiento del paciente.
        /// </summary>
        /// <example>1989-07-22</example>
        public DateTime? FechaNacimiento { get; set; }

        /// <summary>
        /// Clave Única de Registro de Población (CURP).
        /// </summary>
        /// <example>PEMJ890722HDFRRN08</example>
        public string CURP { get; set; }

        /// <summary>
        /// Dirección de correo electrónico del paciente.
        /// </summary>
        /// <example>juan.perez@example.com</example>
        public string Email { get; set; }

        /// <summary>
        /// Número telefónico del paciente.
        /// </summary>
        /// <example>+52 5512345678</example>
        public string Telefono { get; set; }

        /// <summary>
        /// Género del paciente. 'M' o 'F'.
        /// </summary>
        /// <example>M</example>
        public string Genero { get; set; }

        /// <summary>
        /// Contraseña del paciente.
        /// </summary>
        /// <example>MiContraseniaSegura123</example>
        public string Contrasenia { get; set; }


    }
}
