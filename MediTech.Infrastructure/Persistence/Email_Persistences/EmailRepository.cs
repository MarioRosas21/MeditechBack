using MediTech.Domain.Interfaces.Repositories.Email_Repositories;
using MimeKit;

namespace MediTech.Infrastructure.Persistence.Email_Persistences;

public class EmailRepository : IEmailRepository
{
    private readonly IConfiguration _configuration;

    public EmailRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task EnviarCorreoVerificacionAsync(string emailDestino, string tokenVerificacion)
    {
        var smtpHost = _configuration["Email:Host"];
        var smtpPortStr = _configuration["Email:Port"];
        var smtpUser = _configuration["Email:User"];
        var smtpPass = _configuration["Email:Password"];

        if (string.IsNullOrWhiteSpace(smtpHost) ||
            string.IsNullOrWhiteSpace(smtpPortStr) ||
            string.IsNullOrWhiteSpace(smtpUser) ||
            string.IsNullOrWhiteSpace(smtpPass))
        {
            throw new Exception("Configuración SMTP incompleta en appsettings.json");
        }

        var smtpPort = int.Parse(smtpPortStr);

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("MediTech", smtpUser));
        message.To.Add(MailboxAddress.Parse(emailDestino)); // ✔ FIX
        message.Subject = "Verificación de Cuenta";

        message.Body = new TextPart("html")
        {
            Text = $@"
            <h2>Verifica tu cuenta</h2>
            <p>Haz clic en el siguiente enlace para verificar tu correo:</p>
            <a href='https://localhost:7042/api/paciente/verificar-email?token={tokenVerificacion}'>
                Verificar correo
            </a>"
        };

        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        await smtp.ConnectAsync(smtpHost, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(smtpUser, smtpPass);
        await smtp.SendAsync(message);
        await smtp.DisconnectAsync(true);
    }

}
