namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetPacienteDeCita;

// Esta query recibe el ID de la cita y devuelve un paciente
public class GetPacienteDeCitaQuery : IRequest<PacienteVM>
{
    public int IDCita { get; set; }

    public GetPacienteDeCitaQuery(int idCita)
    {
        IDCita = idCita;
    }
}
