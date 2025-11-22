using System.Text.Json.Serialization;

namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Commands.CreateCita;
public class CreateCitaCommand : IRequest<int> // Devuelve el ID de la nueva cita
{
    [JsonIgnore] // Ignora en el JSON del cliente
    public int ID_Paciente { get; set; }
    public string Nombre { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public string CURP { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string HoraCita { get; set; }
    public string Especialidad { get; set; }
    public string Medico { get; set; }
    public string Sede { get; set; }
    public string Motivo { get; set; }
    public DateTime FechaCita { get; set; }

}
