namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Queries.LoginPaciente;

public class LoginPacienteQueryValidator : AbstractValidator<LoginPacienteQuery>
{
    public LoginPacienteQueryValidator()
    {
        // Al menos uno debe estar presente: CURP o Email
        RuleFor(x => x)
            .Must(x => !string.IsNullOrEmpty(x.Email) || !string.IsNullOrEmpty(x.CURP))
            .WithMessage("Debe proporcionar CURP o Email.");

        // CURP válido si se proporciona
        When(x => !string.IsNullOrEmpty(x.CURP), () =>
        {
            RuleFor(x => x.CURP)
                .Length(18).WithMessage("La CURP debe tener 18 caracteres.");
        });

        // Email válido si se proporciona
        When(x => !string.IsNullOrEmpty(x.Email), () =>
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email inválido.");
        });

        // Contraseña siempre requerida
        RuleFor(x => x.Contrasenia)
            .NotEmpty().WithMessage("La contraseña es obligatoria.");
    }
}