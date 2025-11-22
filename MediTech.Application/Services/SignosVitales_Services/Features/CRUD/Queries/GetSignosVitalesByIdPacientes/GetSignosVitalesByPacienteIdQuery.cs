using MediatR;
using MediTech.Domain.Dtos.SignosVitales;

namespace MediTech.Application.SignosVitales.Queries
{
    public class GetSignosVitalesByPacienteIdQuery : IRequest<IEnumerable<SignosVitalesDto>>
    {
        public int PacienteId { get; set; }

        public GetSignosVitalesByPacienteIdQuery(int pacienteId)
        {
            PacienteId = pacienteId;
        }
    }
}
