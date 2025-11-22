namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetCitasByPaciente;
public class CitaVM
{
    public int ID { get; set; }
    public string PacienteNombre { get; set; } = string.Empty;
    public string PacienteApellidoPaterno { get; set; } = string.Empty;
    public string PacienteApellidoMaterno { get; set; } = string.Empty;
    public string CURP { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public string Sede { get; set; } = string.Empty;
    public string HoraCita { get; set; } = string.Empty;
    public string Medico { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
    public string Motivo { get; set; } = string.Empty;
    public DateTime FechaCita { get; set; }
}
