namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetPacienteDeCita;

/// <summary>
/// Este Handler ejecuta la lógica del Query GetPacienteDeCitaQuery.
/// Utiliza el repositorio de citas para acceder a la base de datos y AutoMapper para convertir la entidad Paciente en PacienteVM.
/// </summary>
public class GetPacienteDeCitaQueryHandler : IRequestHandler<GetPacienteDeCitaQuery, PacienteVM>
{
    private readonly ICitaRepository _citaRepository;
    private readonly IMapper _mapper;

    public GetPacienteDeCitaQueryHandler(ICitaRepository citaRepository, IMapper mapper)
    {
        _citaRepository = citaRepository;
        _mapper = mapper;
    }

    public async Task<PacienteVM> Handle(GetPacienteDeCitaQuery request, CancellationToken cancellationToken)
    {
        // Obtiene la cita desde el repositorio
        var cita = await _citaRepository.GetByIdAsync(request.IDCita);
        if (cita == null || cita.ID_Paciente == null)
            return null;

        // Convierte la entidad Paciente a su ViewModel
        var pacienteVm = _mapper.Map<PacienteVM>(cita.ID_Paciente);

        return pacienteVm;
    }
}
