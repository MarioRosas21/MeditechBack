namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Commands.RecoverPasswordByTelefono;
public class RecoverPasswordByTelefonoCommandValidator : AbstractValidator<RecoverPasswordByTelefonoCommand>
{
    public RecoverPasswordByTelefonoCommandValidator()
    {
        RuleFor(x => x.Telefono)
            .NotEmpty().WithMessage("El teléfono es requerido.")
            .MaximumLength(20).WithMessage("El teléfono no debe exceder 20 caracteres.");
    }
}
