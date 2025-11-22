namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetCitaById;
/// <summary>
/// Handler para ejecutar la lógica de GetCitaByIdQuery
/// </summary>
public class GetCitaByIdQueryHandler : IRequestHandler<GetCitaByIdQuery, CitaVM>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetCitaByIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CitaVM> Handle(GetCitaByIdQuery request, CancellationToken cancellationToken)
    {
        var cita = await _context.Citas
            .Include(c => c.Paciente)
            .Include(c => c.Cede)
            .Include(c => c.Disponibilidad)
                .ThenInclude(d => d.Colaborador) // para obtener médico y especialidad
                    .ThenInclude(col => col.Especialidad)
            .FirstOrDefaultAsync(c => c.ID == request.ID, cancellationToken);

        if (cita == null)
            return null;

        // Mapear la cita a CitaVM
        var citaVm = _mapper.Map<CitaVM>(cita);

        // Rellenar campos adicionales manualmente si no los mapea AutoMapper
        citaVm.Medico = $"{cita.Disponibilidad.Colaborador.Nombre} {cita.Disponibilidad.Colaborador.ApellidoPaterno}";
        citaVm.Especialidad = cita.Disponibilidad.Colaborador.Especialidad?.Nombre ?? "Sin especificar";
        citaVm.HoraCita = cita.Disponibilidad.HoraInicio;
        citaVm.Sede = $"{cita.Cede.Ciudad} - {cita.Cede.Direccion}";


        return citaVm;
    }
}
