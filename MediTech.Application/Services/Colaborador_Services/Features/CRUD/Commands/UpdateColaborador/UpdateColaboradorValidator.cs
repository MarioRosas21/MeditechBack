using FluentValidation;
using MediTech.Domain.Dtos.Colaboradores;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Commands.UpdateColaborador
{
    public class UpdateColaboradorValidator : AbstractValidator<UpdateColaboradorCommand>
    {
        public UpdateColaboradorValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("El ID del colaborador debe ser mayor a 0.");
            RuleFor(x => x.Dto.Nombre).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Dto.ApellidoPaterno).NotEmpty().WithMessage("El apellido paterno es obligatorio.");
            RuleFor(x => x.Dto.NombreUsuario).NotEmpty().WithMessage("El nombre de usuario es obligatorio.");
            RuleFor(x => x.Dto.Contrasenia).NotEmpty().WithMessage("La contraseña es obligatoria.");
            // Puedes agregar más reglas según los campos del DTO
        }
    }
}
