namespace MediTech.Domain.Interfaces.Repositories.Email_Repositories;

public interface IEmailRepository
{
    Task EnviarCorreoVerificacionAsync(string emailDestino, string tokenVerificacion);
}
