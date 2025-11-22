namespace MediTech.Infrastructure.Persistence.Cede_Persistences;

/// <summary>
/// Esta clase se encarga de leer y manipular los datos de la tabla Cedes en la base de datos.
/// </summary>
public class CedeRepository : ICedeRepository
{
    private readonly string _connectionString;  // Almacena la cadena de conexión
    private readonly AppDbContext _context;     // Referencia al contexto de EF Core

    // Constructor
    public CedeRepository(IConfiguration configuration, AppDbContext context)
    {
        _context = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException(nameof(configuration));
    }

    /// <summary>
    /// Obtiene un registro de Cede por su ID
    /// </summary>
    public async Task<Cede?> GetByIdAsync(int id)
    {
        return await _context.Cedes
            .FirstOrDefaultAsync(c => c.ID == id);
    }

    /// <summary>
    /// Obtiene un registro de Cede por su Dirección
    /// </summary>
    public async Task<Cede?> GetByDireccionAsync(string direccion)
    {
        return await _context.Cedes
            .FirstOrDefaultAsync(c => c.Direccion == direccion);
    }

    /// <summary>
    /// Obtiene todos los Cedes
    /// </summary>
    public async Task<IEnumerable<Cede>> GetAllAsync()
    {
        return await _context.Cedes.ToListAsync();
    }

    /// <summary>
    /// Agrega un nuevo Cede
    /// </summary>
    public async Task<Cede> AddAsync(Cede cede)
    {
        var nuevoCede = await _context.Cedes.AddAsync(cede);
        await _context.SaveChangesAsync();
        return nuevoCede.Entity;
    }

    /// <summary>
    /// Actualiza un Cede existente
    /// </summary>
    public async Task<bool> UpdateAsync(Cede cede)
    {
        _context.Entry(cede).State = EntityState.Modified;
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    /// <summary>
    /// Elimina un Cede
    /// </summary>
    public async Task<bool> DeleteAsync(Cede cede)
    {
        _context.Cedes.Remove(cede);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}
