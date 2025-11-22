


namespace MediTech.Infrastructure.Persistence.Especialidad_Persistences
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        private readonly AppDbContext _context;

        public EspecialidadRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todas las especialidades activas registradas en el sistema.
        /// </summary>
        public async Task<IEnumerable<Especialidad>> GetAllActivasAsync()
        {
            return await _context.Especialidades
                .Where(e => e.EsActivo)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

