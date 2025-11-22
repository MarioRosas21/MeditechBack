namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetCitasByPaciente;
public class GetCitasByPacienteQueryHandler : IRequestHandler<GetCitasByPacienteQuery, List<CitaVM>>
{
    private readonly ICitaRepository _citaRepository;
    private readonly IMapper _mapper;

    public GetCitasByPacienteQueryHandler(ICitaRepository citaRepository, IMapper mapper)
    {
        _citaRepository = citaRepository;
        _mapper = mapper;
    }

    public async Task<List<CitaVM>> Handle(GetCitasByPacienteQuery request, CancellationToken cancellationToken)
    {
        var citas = await _citaRepository.GetAllAsync();
        var citasPaciente = citas.Where(c => c.ID_Paciente == request.ID_Paciente).ToList();

        if (!citasPaciente.Any())
            return new List<CitaVM>();

        return _mapper.Map<List<CitaVM>>(citasPaciente);
    }
}
