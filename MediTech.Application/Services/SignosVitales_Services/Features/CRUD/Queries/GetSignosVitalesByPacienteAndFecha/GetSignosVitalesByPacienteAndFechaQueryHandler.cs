using MediatR;
using MediTech.Application.SignosVitales.Queries;
using MediTech.Domain.Dtos.SignosVitales;


namespace MediTech.Application.SignosVitales.Handlers
{
    public class GetSignosVitalesByPacienteAndFechaQueryHandler
        : IRequestHandler<GetSignosVitalesByPacienteAndFechaQuery, SignosVitalesDto?>
    {
        private readonly ISignosVitalesRepository _repository;

        public GetSignosVitalesByPacienteAndFechaQueryHandler(ISignosVitalesRepository repository)
        {
            _repository = repository;
        }

        public async Task<SignosVitalesDto?> Handle(
            GetSignosVitalesByPacienteAndFechaQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetByPacienteAndFechaAsync(request.PacienteId, request.Fecha);
        }
    }
}
