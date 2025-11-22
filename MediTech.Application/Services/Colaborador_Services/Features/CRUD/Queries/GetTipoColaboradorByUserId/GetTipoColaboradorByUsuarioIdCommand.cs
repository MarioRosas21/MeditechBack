using MediatR;

public class ObtenerTipoColaboradorQuery : IRequest<ColaboradorTipoDto>
{
    public int UsuarioId { get; set; }

    public ObtenerTipoColaboradorQuery(int usuarioId)
    {
        UsuarioId = usuarioId;
    }
}
