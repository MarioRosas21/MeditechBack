namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Commands.VerificarEmailPaciente;
public class VerificarEmailPacienteCommand : IRequest<bool>
{
    public string Token { get; }

    public VerificarEmailPacienteCommand(string token)
    {
        Token = token;
    }
}
