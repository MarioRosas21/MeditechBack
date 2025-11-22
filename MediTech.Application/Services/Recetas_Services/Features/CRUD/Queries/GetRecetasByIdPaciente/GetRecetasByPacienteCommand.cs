using MediatR;
using MediTech.Domain.Dtos.Recetas;

namespace MediTech.Application.Services.Recetas_Services.Features.CRUD.Queries.GetRecetasByIdPaciente
{
    // Lo llamamos Query porque es una consulta, no una acción que modifica
    public class GetRecetasByPacienteQuery : IRequest<IEnumerable<RecetasDto>>
    {
        public int ID_Paciente { get; set; }

        public GetRecetasByPacienteQuery(int idPaciente)
        {
            ID_Paciente = idPaciente;
        }
    }
}
