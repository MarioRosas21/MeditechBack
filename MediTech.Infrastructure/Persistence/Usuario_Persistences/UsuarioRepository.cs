namespace MediTech.Infrastructure.Persistence.Usuario_Persistences;

/// <summary>
/// Esta clase se encarga de leer los datos de la base de datos
/// </summary>
public class UsuarioRepository : IUsuarioRepository
{
    private readonly string _connectionString;               //esta variable es para almacenar la cadena de coneccion de la base de datos.
    private readonly AppDbContext _context;                  //esta variable hace referencia al contexto de la tabla de base de datos.

    //Constructor
    public UsuarioRepository(IConfiguration configuration, AppDbContext context)
    {
        _context = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")          //instanciamos las variables
            ?? throw new InvalidOperationException("Connection string not found.");
    }

    //metodo que nos traera todos los usuarios de la base de datos
    public async Task<IEnumerable<Usuarios>> GetAllAsync()
    {
        return await _context.Usuarios.ToListAsync();      //aqui retorna la vista
    }
    /*
    public async Task<Usuarios?> LoginAsync(string nombre, string contrasenia)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Nombre == nombre && u.Contrasenia == contrasenia && u.EsActivo);
    }
    */
    //Obtiene el nombre del rol del usuario
    /*public async Task<string?> GetRolByUserIdAsync(int usuarioId)
    {
        var rol = await (
            from usuario in _context.Usuarios
            join modulo in _context.Modulos on usuario.ID_Modulo equals modulo.ID
            join detalle in _context.DetalleModulo on modulo.ID equals detalle.ID_Modulo
            join r in _context.Roles on detalle.ID_Rol equals r.ID
            where usuario.ID == usuarioId
            select r.Nombre
        ).FirstOrDefaultAsync();

        return rol;
    }
    */
    //Obtiene todos los módulos accesibles para el usuario según su rol
    public async Task<IEnumerable<Modulos>> GetModulosPorRolAsync(int usuarioId)
    {
        var modulos = await (
            from usuario in _context.Usuarios
            join moduloUsuario in _context.Modulos on usuario.ID_Modulo equals moduloUsuario.ID
            join detalle in _context.DetalleModulo on moduloUsuario.ID equals detalle.ID_Modulo
            join rol in _context.Roles on detalle.ID_Rol equals rol.ID
            join modulo in _context.Modulos on detalle.ID_Modulo equals modulo.ID
            where usuario.ID == usuarioId && detalle.Leer == true
            select modulo
        ).Distinct().ToListAsync();

        return modulos;
    }



    public async Task<Usuarios?> LoginAsync(string nombre, string contrasenia)
    {
        // Buscar al usuario por nombre y activo
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Nombre == nombre && u.EsActivo);

        if (usuario == null)
        {
            Console.WriteLine($"Usuario '{nombre}' no existe o está inactivo.");
            return null;
        }

        // Verificar la contraseña hasheada
        bool contraseniaValida = BCrypt.Net.BCrypt.Verify(contrasenia, usuario.Contrasenia);

        if (!contraseniaValida)
        {
            Console.WriteLine($"Contraseña incorrecta para usuario '{nombre}'.");
            return null;
        }

        Console.WriteLine($"Usuario '{nombre}' autenticado correctamente.");
        return usuario;
    }




    public async Task<string?> GetTipoColaboradorByUserIdAsync(int usuarioId)
    {
        var tipoColaborador = await (
            from usuario in _context.Usuarios
            join colaborador in _context.Colaboradores on usuario.ID_Persona equals colaborador.ID
            join detalle in _context.ColaboradorDetalle on colaborador.ID equals detalle.ID_Colaborador
            join tipo in _context.TipoColaboradores on detalle.ID_TipoColaborador equals tipo.ID
            where usuario.ID == usuarioId
            select tipo.Tipo
        ).FirstOrDefaultAsync();

        return tipoColaborador;
    }





    public async Task<Usuarios?> GetByNombreAsync(string nombre)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Nombre == nombre);
    }


}