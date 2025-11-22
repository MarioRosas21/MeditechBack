namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Commands.CreatePaciente
{
    public class CreatePacienteCommandValidator : AbstractValidator<CreatePacienteCommand>
    {
        private readonly IPacienteRepository _pacienteRepository;

        public CreatePacienteCommandValidator(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;

            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(100);

            RuleFor(p => p.Contrasenia)
                .NotEmpty().WithMessage("La contraseña es requerida.")
                .MaximumLength(100);

            RuleFor(p => p.ApellidoPaterno)
                .NotEmpty().WithMessage("El apellido paterno es requerido.")
                .MaximumLength(100);

            RuleFor(p => p.CURP)
                .NotEmpty().WithMessage("La CURP es requerida.")
                .Length(18).WithMessage("La CURP debe tener 18 caracteres.")
                .MustAsync(async (curp, _) =>
                {
                    var existente = await _pacienteRepository.GetPacienteByCURPAsync(curp);
                    return existente == null;
                })
                .WithMessage("El CURP ya está registrado en el sistema.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("El correo electrónico es requerido.")
                .EmailAddress().WithMessage("Debe ingresar un correo electrónico válido.")
                .MustAsync(async (email, _) =>
                {
                    var existente = await _pacienteRepository.GetPacienteByEmailAsync(email);
                    return existente == null;
                })
                .WithMessage("El correo electrónico ya está registrado en el sistema.");

            RuleFor(p => p.Genero)
                .NotEmpty().WithMessage("El género es requerido.")
                .Must(g => g == "M" || g == "F")
                .WithMessage("El género debe ser 'M' o 'F'.");

            RuleFor(p => p.Edad)
                .GreaterThan(0).WithMessage("La edad debe ser mayor que cero.");
        }
    }
}
