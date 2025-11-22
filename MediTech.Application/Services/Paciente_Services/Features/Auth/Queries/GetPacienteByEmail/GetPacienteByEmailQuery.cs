namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Queries.GetPacienteByEmail;
// Query para obtener un paciente por su Email
public class GetPacienteByEmailQuery : IRequest<PacienteVM>
{
    public string Email { get; set; }

    public GetPacienteByEmailQuery(string email)
    {
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }
}
