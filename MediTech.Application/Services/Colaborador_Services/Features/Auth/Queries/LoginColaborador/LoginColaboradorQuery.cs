// LoginColaboradorQuery.cs

namespace MediTech.Application.Services.Colaborador_Services.Features.Auth.Queries.LoginColaborador;

public class LoginColaboradorQuery : IRequest<LoginDto>
{
    public string Nombre { get; set; } = string.Empty;
    public string Contrasenia { get; set; } = string.Empty;
}
