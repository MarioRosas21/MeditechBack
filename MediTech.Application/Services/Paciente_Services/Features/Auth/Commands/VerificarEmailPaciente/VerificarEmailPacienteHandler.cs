namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Commands.VerificarEmailPaciente;
public class VerificarEmailPacienteHandler : IRequestHandler<VerificarEmailPacienteCommand, bool>
{
    private readonly IPacienteRepository _repo;

    public VerificarEmailPacienteHandler(IPacienteRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(VerificarEmailPacienteCommand request, CancellationToken cancellationToken)
    {
        var paciente = await _repo.GetPacienteByTokenAsync(request.Token);

        if (paciente == null)
            return false;

        paciente.EmailVerificado = true;
        paciente.TokenVerificacionEmail = null; // opcional, pero recomendado

        await _repo.UpdateAsync(paciente);
        return true;
    }
}
