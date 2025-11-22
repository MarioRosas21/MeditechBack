using MediatR;
using MediTech.Domain.Dtos.Colaboradores;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Queries.GetColaboradoresByEspecialidad
{
    /// <summary>
    /// Query para obtener todos los colaboradores (doctores/enfermeros) por especialidad.
    /// </summary>
    public class GetColaboradoresByEspecialidadQuery : IRequest<IEnumerable<ColaboradorConUsuarioYDetalleDto>>
    {
        public int IdEspecialidad { get; set; }

        public GetColaboradoresByEspecialidadQuery(int idEspecialidad)
        {
            IdEspecialidad = idEspecialidad;
        }
    }
}
