using System.Runtime.CompilerServices;
using MediTech.Domain.Interfaces.Repositories.Email_Repositories;

namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Commands.CreatePaciente;
public class CreatePacienteCommandHandler : IRequestHandler<CreatePacienteCommand, int>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IEmailRepository _emailRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreatePacienteCommandHandler> _logger;

    public CreatePacienteCommandHandler(IPacienteRepository pacienteRepository,IEmailRepository emailRepository , IMapper mapper, ILogger<CreatePacienteCommandHandler> logger)
    {
        _pacienteRepository = pacienteRepository;
        _emailRepository = emailRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<int> Handle(CreatePacienteCommand request, CancellationToken cancellationToken)
    {
        // Validación de duplicados
        var existe = await _pacienteRepository.ExistePacienteAsync(request.CURP, request.Email);
        if (existe)
            throw new ValidationException("Ya existe un paciente con este CURP o Email.");

        // Mapeo a entidad
        var pacienteEntity = _mapper.Map<Paciente>(request);
        pacienteEntity.FechaCreacion = DateTime.UtcNow;
        pacienteEntity.EsActivo = true;

        // Generación de token de verificación
        pacienteEntity.TokenVerificacionEmail = Guid.NewGuid().ToString();
        pacienteEntity.EmailVerificado = false;

        // Guardar paciente
        var nuevoPaciente = await _pacienteRepository.AddAsync(pacienteEntity);

        // Enviar correo de verificación
        await _emailRepository.EnviarCorreoVerificacionAsync(
            nuevoPaciente.Email,
            pacienteEntity.TokenVerificacionEmail!
        );

        _logger.LogInformation($"Paciente {nuevoPaciente.ID} creado correctamente, correo de verificación enviado.");

        return nuevoPaciente.ID;
    }

}
