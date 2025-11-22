using MediatR;
using MediTech.Domain.Dtos.SignosVitales;

namespace MediTech.Application.SignosVitales.Queries
{
    public class GetSignosVitalesByPacienteAndFechaQuery
        : IRequest<SignosVitalesDto?>
    {
        public int PacienteId { get; }
        public DateTime Fecha { get; }

        public GetSignosVitalesByPacienteAndFechaQuery(int pacienteId, DateTime fecha)
        {
            PacienteId = pacienteId;
            Fecha = fecha;
        }
    }
}
