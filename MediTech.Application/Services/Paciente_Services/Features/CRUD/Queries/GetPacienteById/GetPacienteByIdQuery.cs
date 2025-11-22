namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Queries.GetPacienteById;
/// <summary>
/// Este Query representa una solicitud para obtener la información de un solo paciente
/// usando su identificador único (Id).
/// IRequest<PacienteVM> indica que el Handler devolverá un objeto de tipo PacienteVM.
/// </summary>
public class GetPacienteByIdQuery : IRequest<PacienteVM>
{
    // Identificador del paciente que se desea consultar.
    public int Id { get; set; }

    // Constructor que permite inicializar el Query con el Id directamente.
    public GetPacienteByIdQuery(int id)
    {
        Id = id;
    }

    // Constructor vacío requerido para serialización/deserialización automática.
    public GetPacienteByIdQuery() { }
}
