using FluentValidation;
using MediTech.Domain.Dtos.Colaboradores;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Commands.CreateColaborador
{
    /// <summary>
    /// Valida los datos del DTO para crear un colaborador completo
    /// </summary>
    public class CreateColaboradorValidator : AbstractValidator<CrearUsuarioDto>
    {
        public CreateColaboradorValidator()
        {
            RuleFor(x => x.NombreUsuario)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio")
                .MinimumLength(4).WithMessage("Debe tener al menos 4 caracteres");

            RuleFor(x => x.Contrasenia)
                .NotEmpty().WithMessage("La contraseña es obligatoria")
                .MinimumLength(6).WithMessage("Debe tener al menos 6 caracteres");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del colaborador es obligatorio");

            RuleFor(x => x.ApellidoPaterno)
                .NotEmpty().WithMessage("El apellido paterno es obligatorio");

            RuleFor(x => x.CURP)
                .NotEmpty().WithMessage("La CURP es obligatoria");

            RuleFor(x => x.ID_TipoColaborador)
                .GreaterThan(0).WithMessage("Debe seleccionar un tipo de colaborador válido");

            RuleFor(x => x.ID_Cede)
                .GreaterThan(0).WithMessage("Debe seleccionar una cede válida");
        }
    }
}
