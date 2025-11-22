namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Commands.RecoverPasswordByTelefono;

/// <summary>
/// Comando para iniciar el proceso de recuperación de contraseña mediante el teléfono.
/// </summary>
public class RecoverPasswordByTelefonoCommand : IRequest<string> // Devuelve un código temporal
{
    /// <summary>
    /// Número de teléfono registrado del paciente.
    /// </summary>
    /// <example>+52 5512345678</example>
    public string Telefono { get; set; }
}
