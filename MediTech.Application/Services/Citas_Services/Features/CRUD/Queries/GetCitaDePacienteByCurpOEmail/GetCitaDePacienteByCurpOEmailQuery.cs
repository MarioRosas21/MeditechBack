namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetCitaDePacienteByCurpOEmail;
/// <summary>
/// Query para obtener todas las citas de un paciente por CURP o Email.
/// </summary>
public class GetCitaDePacienteByCurpOEmailQuery : IRequest<List<CitaVM>>
{
    public string? CURP { get; set; }
    public string? Email { get; set; }

    public GetCitaDePacienteByCurpOEmailQuery(string? curp, string? email)
    {
        CURP = curp;
        Email = email;
    }
}
