namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Queries.GetPacienteByEmail;
public class GetPacienteByEmailQueryValidator : AbstractValidator<GetPacienteByEmailQuery>
{
    public GetPacienteByEmailQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El Email es obligatorio")
            .EmailAddress().WithMessage("El Email debe tener un formato válido");
    }
}
