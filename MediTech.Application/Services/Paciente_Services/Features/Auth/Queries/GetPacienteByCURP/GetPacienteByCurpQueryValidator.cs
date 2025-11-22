namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Queries.GetPacienteByCURP;
public class GetPacienteByCurpQueryValidator : AbstractValidator<GetPacienteByCurpQuery>
{
    public GetPacienteByCurpQueryValidator()
    {
        // CURP es obligatorio
        RuleFor(x => x.CURP)
            .NotEmpty().WithMessage("La CURP es obligatoria")
            .Length(18).WithMessage("La CURP debe tener 18 caracteres");
    }
}
