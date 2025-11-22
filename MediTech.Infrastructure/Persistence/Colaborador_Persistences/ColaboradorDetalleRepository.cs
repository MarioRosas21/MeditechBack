using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;

namespace MediTech.Infrastructure.Persistence.Colaborador_Persistences
{
    public class ColaboradorDetalleRepository : IColaboradorDetalleRepository
    {
        private readonly AppDbContext _context;

        public ColaboradorDetalleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ColaboradorDetalle detalle)
        {
            _context.ColaboradorDetalle.Add(detalle);
            await _context.SaveChangesAsync();
        }

        public async Task<ColaboradorDetalle?> GetByIdAsync(int id)
        {
            return await _context.ColaboradorDetalle
                .Include(d => d.Colaborador)
                .Include(d => d.TipoColaborador)
                .FirstOrDefaultAsync(d => d.ID == id);
        }

        public async Task<IEnumerable<ColaboradorDetalle>> GetByColaboradorIdAsync(int colaboradorId)
        {
            return await _context.ColaboradorDetalle
                .Include(d => d.TipoColaborador)
                .Where(d => d.ID_Colaborador == colaboradorId)
                .ToListAsync();
        }

        public async Task UpdateAsync(ColaboradorDetalle detalle)
        {
            _context.ColaboradorDetalle.Update(detalle);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var detalle = await _context.ColaboradorDetalle.FindAsync(id);
            if (detalle == null) return false;
            _context.ColaboradorDetalle.Remove(detalle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
