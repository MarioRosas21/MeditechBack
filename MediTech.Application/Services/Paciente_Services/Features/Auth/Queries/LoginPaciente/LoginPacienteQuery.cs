using System.ComponentModel.DataAnnotations;

namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Queries.LoginPaciente;

/// <summary>
/// Query para autenticar un paciente usando CURP o Email + contraseña
/// </summary>
public class LoginPacienteQuery : IRequest<string>
{
    // Puede autenticarse con CURP o Email, pero solo uno de los dos
    public string? CURP { get; set; } // opcional
    public string? Email { get; set; } // opcional
    [Required]
    public string Contrasenia { get; set; } // obligatorio
}
