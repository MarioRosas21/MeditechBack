namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetCitaDePacienteByCurpOEmail;
/// <summary>
/// Handler para obtener las citas de un paciente usando CURP o Email.
/// </summary>
public class GetCitaDePacienteByCurpOEmailQueryHandler
    : IRequestHandler<GetCitaDePacienteByCurpOEmailQuery, List<CitaVM>>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly ICitaRepository _citaRepository;
    private readonly IMapper _mapper;

    public GetCitaDePacienteByCurpOEmailQueryHandler(
        IPacienteRepository pacienteRepository,
        ICitaRepository citaRepository,
        IMapper mapper)
    {
        _pacienteRepository = pacienteRepository;
        _citaRepository = citaRepository;
        _mapper = mapper;
    }

    public async Task<List<CitaVM>> Handle(
        GetCitaDePacienteByCurpOEmailQuery request,
        CancellationToken cancellationToken)
    {
        // Buscar paciente por CURP o Email
        var paciente = !string.IsNullOrWhiteSpace(request.CURP)
            ? await _pacienteRepository.GetPacienteByCURPAsync(request.CURP)
            : await _pacienteRepository.GetPacienteByEmailAsync(request.Email);

        if (paciente is null)
            return new List<CitaVM>(); // No existe el paciente

        // Traer todas las citas (el ICitaRepository no tiene filtros)
        var citas = await _citaRepository.GetAllAsync();

        // Filtrar por ID del paciente
        var citasPaciente = citas
            .Where(c => c.ID_Paciente == paciente.ID)
            .ToList();

        return _mapper.Map<List<CitaVM>>(citasPaciente);
    }
}
