namespace MediTech.Infrastructure.Persistence.Citas_Persistences;

/// <summary>
/// Maneja las operaciones CRUD para la entidad <see cref="Cita"/>.
/// </summary>
public class CitaRepository : ICitaRepository
{
    private readonly string _connectionString;
    private readonly AppDbContext _context;

    public CitaRepository(IConfiguration configuration, AppDbContext context)
    {
        _context = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException(nameof(configuration));
    }

    /// <summary>
    /// Obtiene todas las citas registradas.
    /// </summary>
    public async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _context.Citas
            .Include(c => c.Paciente)
            .Include(c => c.Cede)
            .Include(c => c.Disponibilidad)
                .ThenInclude(d => d.Colaborador)
                    .ThenInclude(col => col.Especialidad)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Obtiene una cita específica por su ID.
    /// </summary>
    public async Task<Cita?> GetByIdAsync(int citaId)
    {
        return await _context.Citas
            .Include(c => c.Paciente)
            .Include(c => c.Cede)
            .Include(c => c.Disponibilidad)
                .ThenInclude(d => d.Colaborador)
                    .ThenInclude(col => col.Especialidad)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ID == citaId);
    }

    /// <summary>
    /// Agrega una nueva cita a la base de datos.
    /// </summary>
    public async Task<Cita> AddAsync(Cita cita)
    {
        // Si no se especifica motivo, asigna el valor por defecto
        if (string.IsNullOrWhiteSpace(cita.Motivo))
            cita.Motivo = "sin motivo";

        var nuevaCita = await _context.Citas.AddAsync(cita);
        await _context.SaveChangesAsync();
        return nuevaCita.Entity;
    }

    /// <summary>
    /// Actualiza los datos de una cita existente.
    /// </summary>
    public async Task<bool> UpdateAsync(Cita cita)
    {
        _context.Entry(cita).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Elimina una cita de la base de datos.
    /// </summary>
    public async Task<bool> DeleteAsync(Cita cita)
    {
        _context.Citas.Remove(cita);
        return await _context.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Trae las cita de la base de datos que son las que estan asiganadas a un colaborador (Doctor).
    /// </summary>
    public async Task<IEnumerable<Cita>> GetCitasByColaboradorAsync(int colaboradorId)
    {
        return await _context.Citas
            .Include(c => c.Paciente)
            .Include(c => c.Cede)
            .Include(c => c.Disponibilidad)
                .ThenInclude(d => d.Colaborador)
                    .ThenInclude(col => col.Especialidad)
            .Where(c => c.Disponibilidad.ID_Colaborador == colaboradorId)
            .OrderBy(c => c.FechaCita)
            .AsNoTracking()
            .ToListAsync();
    }

}
