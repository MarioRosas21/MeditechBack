namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Queries.GetPacienteById;
/// <summary>
/// Este Handler maneja la solicitud del Query GetPacienteByIdQuery.
/// Se encarga de buscar el paciente por Id en la base de datos y mapearlo al modelo de vista (PacienteVM).
/// </summary>
public class GetPacienteByIdQueryHandler : IRequestHandler<GetPacienteByIdQuery, PacienteVM>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMapper _mapper;

    public GetPacienteByIdQueryHandler(IPacienteRepository pacienteRepository, IMapper mapper)
    {
        _pacienteRepository = pacienteRepository;
        _mapper = mapper;
    }

    public async Task<PacienteVM> Handle(GetPacienteByIdQuery request, CancellationToken cancellationToken)
    {
        // Buscar el paciente por su Id
        var paciente = await _pacienteRepository.GetPacienteByIdAsync(request.Id);

        // Si no se encuentra el paciente, se puede devolver null o lanzar una excepción controlada,
        // dependiendo del diseño de tu aplicación.
        if (paciente == null)
            return null;

        // Convertir la entidad de dominio a su ViewModel correspondiente
        var pacienteVm = _mapper.Map<PacienteVM>(paciente);

        return pacienteVm; // Retorna el (PacienteVM).
    }
}
