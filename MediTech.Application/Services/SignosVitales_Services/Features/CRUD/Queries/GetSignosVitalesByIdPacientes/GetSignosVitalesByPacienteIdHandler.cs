using MediatR;
using MediTech.Application.SignosVitales.Queries;
using MediTech.Domain.Dtos.SignosVitales;
using MediTech.Infrastructure.Persistence.Recetas_Persistences;

namespace MediTech.Application.SignosVitales.Handlers
{
    public class GetSignosVitalesByPacienteIdHandler
        : IRequestHandler<GetSignosVitalesByPacienteIdQuery, IEnumerable<SignosVitalesDto>>
    {
        private readonly ISignosVitalesRepository _repository;

        public GetSignosVitalesByPacienteIdHandler(ISignosVitalesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SignosVitalesDto>> Handle(
            GetSignosVitalesByPacienteIdQuery request,
            CancellationToken cancellationToken)
        {
            var resultados = await _repository.GetByPacienteIdAsync(request.PacienteId);

            return resultados;
        }
    }
}
