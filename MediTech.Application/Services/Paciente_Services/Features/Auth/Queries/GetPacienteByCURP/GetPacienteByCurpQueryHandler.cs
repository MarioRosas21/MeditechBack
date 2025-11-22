namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Queries.GetPacienteByCURP;
public class GetPacienteByCurpQueryHandler : IRequestHandler<GetPacienteByCurpQuery, PacienteVM>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMapper _mapper;

    public GetPacienteByCurpQueryHandler(IPacienteRepository pacienteRepository, IMapper mapper)
    {
        _pacienteRepository = pacienteRepository ?? throw new ArgumentNullException(nameof(pacienteRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<PacienteVM> Handle(GetPacienteByCurpQuery request, CancellationToken cancellationToken)
    {
        var paciente = await _pacienteRepository.GetPacienteByCURPAsync(request.CURP);
        if (paciente == null)
            return null;

        return _mapper.Map<PacienteVM>(paciente);
    }
}
