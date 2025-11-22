namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Queries.GetAllPacientes;
/// <summary>
/// Este ViewModel representa cómo se mostrarán los datos del paciente en la respuesta de la API.
/// Se usa para evitar exponer directamente las entidades de dominio, (es como un Dto)
/// </summary>
public class PacienteVM
{
    public string Nombre { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public int Edad { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string CURP { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Genero { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public bool EsActivo { get; set; }
}