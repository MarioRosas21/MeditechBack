namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Queries.GetPacienteByEmail;
public class GetPacienteByEmailQueryHandler : IRequestHandler<GetPacienteByEmailQuery, PacienteVM>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMapper _mapper;

    public GetPacienteByEmailQueryHandler(IPacienteRepository pacienteRepository, IMapper mapper)
    {
        _pacienteRepository = pacienteRepository ?? throw new ArgumentNullException(nameof(pacienteRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<PacienteVM> Handle(GetPacienteByEmailQuery request, CancellationToken cancellationToken)
    {
        var paciente = await _pacienteRepository.GetPacienteByEmailAsync(request.Email);
        if (paciente == null)
            return null;

        return _mapper.Map<PacienteVM>(paciente);
    }
}
