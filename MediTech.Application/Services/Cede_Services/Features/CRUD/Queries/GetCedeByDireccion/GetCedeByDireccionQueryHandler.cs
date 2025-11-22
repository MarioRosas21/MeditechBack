namespace MediTech.Application.Services.Cede_Services.Features.CRUD.Queries.GetCedeByDireccion;
public class GetCedeByDireccionQueryHandler : IRequestHandler<GetCedeByDireccionQuery, CedeVM>
{
    private readonly ICedeRepository _cedeRepository;
    private readonly IMapper _mapper;

    public GetCedeByDireccionQueryHandler(ICedeRepository cedeRepository, IMapper mapper)
    {
        _cedeRepository = cedeRepository;
        _mapper = mapper;
    }

    public async Task<CedeVM> Handle(GetCedeByDireccionQuery request, CancellationToken cancellationToken)
    {
        var cede = await _cedeRepository.GetByDireccionAsync(request.Direccion);

        if (cede == null)
            return null;

        var cedeVm = _mapper.Map<CedeVM>(cede);
        return cedeVm;
    }
}
