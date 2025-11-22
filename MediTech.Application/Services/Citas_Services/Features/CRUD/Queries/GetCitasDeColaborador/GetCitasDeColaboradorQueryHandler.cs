namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetCitasDeColaborador;
public class GetCitasDeColaboradorQueryHandler
    : IRequestHandler<GetCitasDeColaboradorQuery, List<CitaVM>>
{
    private readonly ICitaRepository _citaRepository;
    private readonly IMapper _mapper;

    public GetCitasDeColaboradorQueryHandler(ICitaRepository citaRepository, IMapper mapper)
    {
        _citaRepository = citaRepository;
        _mapper = mapper;
    }

    public async Task<List<CitaVM>> Handle(GetCitasDeColaboradorQuery request, CancellationToken cancellationToken)
    {
        var citas = await _citaRepository.GetCitasByColaboradorAsync(request.ColaboradorId);

        if (!citas.Any())
            return new List<CitaVM>();

        return _mapper.Map<List<CitaVM>>(citas);
    }
}
