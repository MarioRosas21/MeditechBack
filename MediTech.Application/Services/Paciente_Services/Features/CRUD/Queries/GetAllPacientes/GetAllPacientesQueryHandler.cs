namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Queries.GetAllPacientes
{
    /// <summary>
    /// Este Handler es el responsable de ejecutar la lógica asociada al Query GetAllPacientesQuery.
    /// Utiliza el repositorio de pacientes para acceder a la base de datos y AutoMapper para convertir las entidades en ViewModels.
    /// </summary>
    public class GetAllPacientesQueryHandler : IRequestHandler<GetAllPacientesQuery, List<PacienteVM>>
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public GetAllPacientesQueryHandler( IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<List<PacienteVM>> Handle(GetAllPacientesQuery request, CancellationToken cancellationToken)
        {
            // Obtiene todos los registros desde la base de datos mediante el repositorio.
            var pacientes = await _pacienteRepository.GetAllAsync();

            // Si no hay pacientes registrados, devuelve una lista vacía (evita null reference).
            if (pacientes == null || !pacientes.Any())
                return new List<PacienteVM>();

            // Convierte las entidades Paciente a su representación de vista (PacienteVM).
            var pacientesVm = _mapper.Map<List<PacienteVM>>(pacientes);

            return pacientesVm;
        }
    }
}
