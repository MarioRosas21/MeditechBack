using MediatR;
using Microsoft.EntityFrameworkCore;
using MediTech.Domain.Entities.Colaboradores_Entities;

public class ObtenerTipoColaboradorHandler : IRequestHandler<ObtenerTipoColaboradorQuery, ColaboradorTipoDto>
{
    private readonly AppDbContext _context;

    public ObtenerTipoColaboradorHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ColaboradorTipoDto> Handle(ObtenerTipoColaboradorQuery request, CancellationToken cancellationToken)
    {
        var detalle = await _context.ColaboradorDetalle
            .Include(cd => cd.Colaborador)
            .Include(cd => cd.TipoColaborador)
            .Where(cd => cd.ID_Colaborador == request.UsuarioId)
            .Select(cd => new ColaboradorTipoDto
            {
                NombreColaborador = cd.Colaborador.Nombre, // Ajusta según tu propiedad real
                TipoColaborador = cd.TipoColaborador.Tipo // Ajusta según tu propiedad real
            })
            .FirstOrDefaultAsync(cancellationToken);

        return detalle;
    }
}
