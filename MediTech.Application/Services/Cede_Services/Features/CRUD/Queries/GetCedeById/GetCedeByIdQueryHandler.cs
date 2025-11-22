namespace MediTech.Application.Services.Cede_Services.Features.CRUD.Queries.GetCedeById;

public class GetCedeByIdQueryHandler : IRequestHandler<GetCedeByIdQuery, CedeVM>
{
    private readonly ICedeRepository _cedeRepository;
    private readonly IMapper _mapper;

    public GetCedeByIdQueryHandler(ICedeRepository cedeRepository, IMapper mapper)
    {
        _cedeRepository = cedeRepository;
        _mapper = mapper;
    }

    public async Task<CedeVM> Handle(GetCedeByIdQuery request, CancellationToken cancellationToken)
    {
        var cede = await _cedeRepository.GetByIdAsync(request.Id);

        if (cede == null)
            return null;

        var cedeVm = _mapper.Map<CedeVM>(cede);
        return cedeVm;
    }
}
