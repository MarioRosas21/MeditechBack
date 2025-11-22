using MediTech.Application.Services.Cede_Services.Features.CRUD.Queries.GetCedeByDireccion;

namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Commands.CreateCita;
public class CreateCitaCommandHandler : IRequestHandler<CreateCitaCommand, int>
{
    private readonly ICitaRepository _citaRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCitaCommandHandler> _logger;
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;

    public CreateCitaCommandHandler(
        ICitaRepository citaRepository,
        IPacienteRepository pacienteRepository,
        IMapper mapper,
        ILogger<CreateCitaCommandHandler> logger,
        AppDbContext context,
        IMediator mediator)
    {
        _citaRepository = citaRepository;
        _pacienteRepository = pacienteRepository;
        _mapper = mapper;
        _logger = logger;
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateCitaCommand request, CancellationToken cancellationToken)
    {
        // Buscar paciente
        var paciente = await _pacienteRepository.GetPacienteByCURPAsync(request.CURP);
        if (paciente == null)
            throw new Exception($"Paciente con CURP {request.CURP} no encontrado.");

        // Obtener la cede usando Mediator
        var cedeVm = await _mediator.Send(new GetCedeByDireccionQuery(request.Sede));
        if (cedeVm == null)
            throw new Exception($"No se encontró la sede con dirección '{request.Sede}'.");

        var cede = _mapper.Map<Cede>(cedeVm);

        // Buscar el colaborador
        var colaborador = await _context.Colaboradores
            .Include(c => c.Especialidad)
            .FirstOrDefaultAsync(c => c.Nombre == request.Medico, cancellationToken);
        if (colaborador == null)
            throw new Exception($"No se encontró el médico '{request.Medico}'.");

        // Crear disponibilidad
        var disponibilidad = new Disponibilidad
        {
            ID_Colaborador = colaborador.ID,
            ID_Paciente = paciente.ID,
            HoraInicio = request.HoraCita,
            HoraFin = request.HoraCita
        };
        _context.Disponibilidad.Add(disponibilidad);
        await _context.SaveChangesAsync(cancellationToken);

        // Crear cita
        var cita = new Cita
        {
            ID_Paciente = paciente.ID, // usar FK directamente
            ID_Cede = cede.ID,
            ID_Disponible = disponibilidad.ID,
            FechaCreacion = DateTime.UtcNow,
            Motivo = request.Motivo ?? "sin motivo",
            FechaCita = request.FechaCita,
        };

        var nuevaCita = await _citaRepository.AddAsync(cita);

        // Asignar estado inicial
        var estatus = await _context.EstatusCitas.FirstOrDefaultAsync(e => e.Nombre == "Programada", cancellationToken);
        if (estatus != null)
        {
            _context.CitasEstadoDetalles.Add(new CitasEstadoDetalle
            {
                ID_Cita = nuevaCita.ID,
                ID_Estatus = estatus.ID
            });
            await _context.SaveChangesAsync(cancellationToken);
        }

        _logger.LogInformation($"Cita {nuevaCita.ID} creada correctamente.");
        return nuevaCita.ID;
    }
}