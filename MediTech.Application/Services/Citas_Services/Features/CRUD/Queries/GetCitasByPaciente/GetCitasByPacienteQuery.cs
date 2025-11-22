namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetCitasByPaciente;

/// <summary>
/// Query para obtener todas las citas de un paciente por su ID
/// </summary>
public class GetCitasByPacienteQuery : IRequest<List<CitaVM>>
{
    public int ID_Paciente { get; set; }

    public GetCitasByPacienteQuery(int idPaciente)
    {
        ID_Paciente = idPaciente;
    }
}
