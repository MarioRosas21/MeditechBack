using MediatR;
using MediTech.Application.Recetas.Queries;

using AutoMapper;
using MediTech.Domain.Dtos.SignosVitales;

namespace MediTech.Application.Recetas.Handlers
{
    public class GetAllSignosVitalesQueryHandler
        : IRequestHandler<GetAllSignosVitalesQuery, IEnumerable<SignosVitalesDto>>
    {
        private readonly ISignosVitalesRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSignosVitalesQueryHandler(
            ISignosVitalesRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SignosVitalesDto>> Handle(
            GetAllSignosVitalesQuery request,
            CancellationToken cancellationToken)
        {
            var signos = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<SignosVitalesDto>>(signos);
        }
    }
}
