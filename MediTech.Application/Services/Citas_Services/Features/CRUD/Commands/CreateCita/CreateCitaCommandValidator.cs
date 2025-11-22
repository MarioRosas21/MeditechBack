namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Commands.CreateCita
{
    public class CreateCitaCommandValidator : AbstractValidator<CreateCitaCommand>
    {
        public CreateCitaCommandValidator()
        {
            // Datos del paciente
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del paciente es obligatorio.")
                .MaximumLength(50);

            RuleFor(x => x.ApellidoPaterno)
                .NotEmpty().WithMessage("El apellido paterno es obligatorio.")
                .MaximumLength(50);

            RuleFor(x => x.ApellidoMaterno)
                .NotEmpty().WithMessage("El apellido materno es obligatorio.")
                .MaximumLength(50);

            RuleFor(x => x.CURP)
                .NotEmpty().WithMessage("La CURP es obligatoria.")
                .Length(18).WithMessage("La CURP debe tener 18 caracteres.");

            RuleFor(x => x.FechaNacimiento)
                .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.")
                .LessThan(DateTime.Today).WithMessage("La fecha de nacimiento no puede ser futura.");

            // Datos de la cita
            RuleFor(x => x.HoraCita)
                .NotEmpty().WithMessage("La hora de la cita es obligatoria.");

            RuleFor(x => x.Especialidad)
                .NotEmpty().WithMessage("La especialidad es obligatoria.");

            RuleFor(x => x.Medico)
                .NotEmpty().WithMessage("El médico asignado es obligatorio.");

            RuleFor(x => x.Sede)
                .NotEmpty().WithMessage("La sede o clínica es obligatoria.");
        }
    }
}
