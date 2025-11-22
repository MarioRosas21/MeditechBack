using FluentValidation;

namespace MediTech.Application.Features.Colaboradores.Commands.ReactivarColaborador
{
    public class ReactivarColaboradorCommandValidator : AbstractValidator<ReactivarColaboradorCommand>
    {
        public ReactivarColaboradorCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El ID debe ser mayor a 0.");
        }
    }
}
