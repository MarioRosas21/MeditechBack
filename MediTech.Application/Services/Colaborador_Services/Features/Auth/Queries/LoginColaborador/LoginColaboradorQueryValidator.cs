// LoginColaboradorQueryValidator.cs

namespace MediTech.Application.Services.Colaborador_Services.Features.Auth.Queries.LoginColaborador;

public class LoginColaboradorQueryValidator : AbstractValidator<LoginColaboradorQuery>
{
    public LoginColaboradorQueryValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre de usuario es obligatorio.");

        RuleFor(x => x.Contrasenia)
            .NotEmpty().WithMessage("La contraseña es obligatoria.");
    }
}
