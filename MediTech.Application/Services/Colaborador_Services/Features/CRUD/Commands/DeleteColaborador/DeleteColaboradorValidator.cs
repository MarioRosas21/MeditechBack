using FluentValidation;
using MediTech.Application.Usuarios.Commands;

namespace MediTech.Application.Usuarios.Validators
{
    public class DeleteColaboradorValidator : AbstractValidator<DeleteColaboradorCommand>
    {
        public DeleteColaboradorValidator()
        {
            RuleFor(x => x.ColaboradorId)
                .GreaterThan(0)
                .WithMessage("El ID del colaborador debe ser mayor a cero.");
        }
    }
}
