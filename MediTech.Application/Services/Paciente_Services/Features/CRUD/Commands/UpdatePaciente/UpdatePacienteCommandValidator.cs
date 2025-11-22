namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Commands.UpdatePaciente;
/// <summary>
/// Este validador usa FluentValidation para asegurar que los datos del comando sean válidos
/// antes de que lleguen al Handler. Si algún campo no cumple con las reglas, se lanza una excepción.
/// </summary>
public class UpdatePacienteCommandValidator : AbstractValidator<UpdatePacienteCommand>
{
    public UpdatePacienteCommandValidator()
    {
        // El ID debe ser mayor a 0
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .WithMessage("El ID del paciente debe ser mayor a cero.");

        // El nombre es obligatorio y no debe ser vacío
        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre no debe superar los 100 caracteres.");

        // El apellido paterno también es obligatorio
        RuleFor(p => p.ApellidoPaterno)
            .NotEmpty().WithMessage("El apellido paterno es obligatorio.")
            .MaximumLength(100).WithMessage("El apellido paterno no debe superar los 100 caracteres.");

        // La edad debe ser positiva y menor que 120 (validación básica)
        RuleFor(p => p.Edad)
            .GreaterThan(0).WithMessage("La edad debe ser mayor que cero.")
            .LessThan(120).WithMessage("La edad no puede superar los 120 años.");

        // Si se proporciona una fecha de nacimiento, debe ser razonable (no futura)
        RuleFor(p => p.FechaNacimiento)
            .LessThanOrEqualTo(DateTime.Now).When(p => p.FechaNacimiento.HasValue)
            .WithMessage("La fecha de nacimiento no puede ser futura.");

        // Validación opcional para el formato del correo electrónico
        RuleFor(p => p.Email)
            .EmailAddress().When(p => !string.IsNullOrEmpty(p.Email))
            .WithMessage("El correo electrónico no tiene un formato válido.");

        // El teléfono debe tener al menos 8 caracteres
        RuleFor(p => p.Telefono)
            .MinimumLength(8).When(p => !string.IsNullOrEmpty(p.Telefono))
            .WithMessage("El teléfono debe tener al menos 8 caracteres.");

        // El género solo puede ser M o F (validación simple)
        RuleFor(p => p.Genero)
            .Must(g => g == "M" || g == "F")
            .WithMessage("El género debe ser 'M' (masculino) o 'F' (femenino).");
    }
}
