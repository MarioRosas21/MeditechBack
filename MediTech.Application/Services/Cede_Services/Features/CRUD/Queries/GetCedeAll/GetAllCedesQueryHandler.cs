

namespace MediTech.Application.Services.Cede_Services.Features.CRUD.Queries.GetAllCedes
{
    public class GetAllCedesQueryHandler : IRequestHandler<GetAllCedesQuery, List<CedeVM>>
    {
        private readonly ICedeRepository _cedeRepository;
        private readonly IMapper _mapper;

        public GetAllCedesQueryHandler(ICedeRepository cedeRepository, IMapper mapper)
        {
            _cedeRepository = cedeRepository;
            _mapper = mapper;
        }

        public async Task<List<CedeVM>> Handle(GetAllCedesQuery request, CancellationToken cancellationToken)
        {
            var cedes = await _cedeRepository.GetAllAsync();

            if (cedes == null || !cedes.Any())
                return new List<CedeVM>();

            var cedesVm = _mapper.Map<List<CedeVM>>(cedes);
            return cedesVm;
        }
    }
}
