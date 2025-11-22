using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Entities.Colaboradores_Entities;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;

namespace MediTech.Infrastructure.Persistence.Colaborador_Persistences;


public class ColaboradorRepository : IColaboradorRepository
{
    private readonly AppDbContext _context;

    public ColaboradorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Colaborador>> GetAllAsync()
    {
        return await _context.Colaboradores.ToListAsync();
    }

    public async Task<Colaborador?> GetByIdAsync(int id)
    {
        return await _context.Colaboradores
            .FirstOrDefaultAsync(c => c.ID == id && c.EsActivo);
    }


    public async Task<IEnumerable<Colaborador>> GetAllWithFilterAsync(bool? activo = null)
    {
        var query = _context.Colaboradores.AsQueryable();

        if (activo.HasValue)
            query = query.Where(c => c.EsActivo == activo.Value);

        return await query.ToListAsync();
    }


    public async Task AddAsync(Colaborador colaborador)
    {
        _context.Colaboradores.Add(colaborador);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Colaborador colaborador)
    {
        colaborador.FechaActualizacion = DateTime.Now;
        _context.Colaboradores.Update(colaborador);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var colaborador = await _context.Colaboradores.FindAsync(id);
        if (colaborador == null)
            return false; // no existe

        colaborador.EsActivo = false;
        colaborador.FechaActualizacion = DateTime.Now;
        _context.Colaboradores.Update(colaborador);
        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<RegistroResultadoDto> RegistrarUsuarioCompletoAsync(CrearUsuarioDto dto)
    {
        // 🔹 1️⃣ Validar duplicados antes de crear nada
        var mensajeError = await ValidarDuplicadosAsync(dto.Email, dto.Telefono, dto.NombreUsuario);
        if (mensajeError != null)
        {
            Console.WriteLine($"❌ Registro detenido: {mensajeError}");
            return new RegistroResultadoDto
            {
                Exito = false,
                Mensaje = mensajeError
            };
        }

        // 🔹 2️⃣ Crear colaborador
        var colaborador = new Colaborador
        {
            Nombre = dto.Nombre,
            ApellidoPaterno = dto.ApellidoPaterno,
            ApellidoMaterno = dto.ApellidoMaterno,
            CURP = dto.CURP,
            Email = dto.Email,
            Edad = dto.Edad,
            FechaNacimiento = dto.FechaNacimiento,
            Direccion = dto.Direccion,
            Telefono = dto.Telefono,
            FechaContrato = dto.FechaContrato,
            Licencia = dto.Licencia,
            MatriculaProfesional = dto.MatriculaProfesional,
            ID_Cede = dto.ID_Cede,
            ID_Especialidad = dto.ID_Especialidad,
            Genero = dto.Genero,
            EsActivo = dto.EsActivo
        };

        await _context.Colaboradores.AddAsync(colaborador);
        await _context.SaveChangesAsync(); // ✅ Genera el ID del colaborador

        // 🔹 3️⃣ Crear detalle del colaborador
        var detalle = new ColaboradorDetalle
        {
            Colaborador = colaborador,
            ID_TipoColaborador = dto.ID_TipoColaborador
        };
        await _context.ColaboradorDetalle.AddAsync(detalle);

        // 🔹 4️⃣ Crear usuario vinculado
        var usuario = new Usuarios
        {
            Nombre = dto.NombreUsuario,
            Contrasenia = HashPassword(dto.Contrasenia),
            ID_Persona = colaborador.ID,
            Telefono = dto.Telefono,
            ID_Modulo = dto.ID_Modulo,
            EsActivo = dto.EsActivo,
            FechaCreacion = DateTime.Now,
            FechaActualizacion = DateTime.Now
        };

        await _context.Usuarios.AddAsync(usuario);

        // 🔹 5️⃣ Guardar todo
        await _context.SaveChangesAsync();

        Console.WriteLine($"✅ Usuario '{usuario.Nombre}' registrado correctamente con ID {usuario.ID}.");

        // 🔹 6️⃣ Retornar éxito
        return new RegistroResultadoDto
        {
            Exito = true,
            Mensaje = "Colaborador y usuario registrados correctamente.",
            UsuarioId = usuario.ID
        };
    }

    // ==========================================================
    // 🔹 MÉTODO PARA VALIDAR DUPLICADOS (EMAIL / TEL / USUARIO)
    // ==========================================================
    public async Task<string?> ValidarDuplicadosAsync(string email, string telefono, string nombreUsuario)
    {
        if (await _context.Colaboradores.AnyAsync(c => c.Email == email))
            return "El correo electrónico ya está registrado.";

        if (await _context.Colaboradores.AnyAsync(c => c.Telefono == telefono))
            return "El número de teléfono ya está registrado.";

        if (await _context.Usuarios.AnyAsync(u => u.Nombre == nombreUsuario))
            return "El nombre de usuario ya está en uso.";

        return null; // ✅ No hay duplicados
    }

    // ==========================================================
    // 🔹 HASH DE CONTRASEÑA SEGURO
    // ==========================================================
    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }






    public async Task<bool> ExisteUsuarioAsync(string nombreUsuario, string email, string telefono, string curp)
    {
        return await _context.Colaboradores.AnyAsync(c =>
            c.Nombre == nombreUsuario ||
            c.Email == email ||
            c.Telefono == telefono ||
            c.CURP==curp);
    }



    public async Task<IEnumerable<ColaboradorConUsuarioYDetalleDto>> GetAllConUsuariosYDetalleAsync()
    {
        return await _context.Colaboradores
            .Include(c => c.Usuarios)
            .Include(c => c.ColaboradorDetalles)
                .ThenInclude(d => d.TipoColaborador)
            .Include(c => c.Cede) // 👈 importante: incluir la sede
            .Select(c => new ColaboradorConUsuarioYDetalleDto
            {
                ID = c.ID,
                Nombre = c.Nombre,
                ApellidoPaterno = c.ApellidoPaterno,
                ApellidoMaterno = c.ApellidoMaterno,
                Edad = c.Edad,
                FechaNacimiento = c.FechaNacimiento,
                Direccion = c.Direccion,
                CURP = c.CURP,
                Email = c.Email,
                MatriculaProfesional = c.MatriculaProfesional,
                Telefono = c.Telefono,
                Genero = c.Genero,
                FechaCreacion = c.FechaCreacion,
                FechaActualizacion = c.FechaActualizacion,
                FechaContrato = c.FechaContrato,
                Licencia = c.Licencia,
                EsActivo = c.EsActivo,

                // ID de la sede
                ID_Cede = c.ID_Cede.ToString(),

                // ✅ Datos de la sede

                Estado = c.Cede != null ? c.Cede.Estado : "Desconocido",

                UsuarioNombre = c.Usuarios.FirstOrDefault() != null ? c.Usuarios.FirstOrDefault().Nombre : "Sin usuario",
                UsuarioContrasenia = c.Usuarios.FirstOrDefault() != null ? c.Usuarios.FirstOrDefault().Contrasenia : "",

                Rol = c.ColaboradorDetalles.FirstOrDefault() != null &&
                      c.ColaboradorDetalles.FirstOrDefault().TipoColaborador != null
                      ? c.ColaboradorDetalles.FirstOrDefault().TipoColaborador.Tipo
                      : "Sin rol"
            })
            .ToListAsync();
    }






    public async Task<ColaboradorConUsuarioYDetalleDto?> GetByIdConUsuariosYDetalleAsync(int id)
    {
        return await _context.Colaboradores
            .Include(c => c.Usuarios)
            .Include(c => c.ColaboradorDetalles)
                .ThenInclude(d => d.TipoColaborador)
            .Where(c => c.ID == id)
            .Select(c => new ColaboradorConUsuarioYDetalleDto
            {
                ID = c.ID,
                Nombre = c.Nombre,
                ApellidoPaterno = c.ApellidoPaterno,
                ApellidoMaterno = c.ApellidoMaterno,
                Edad = c.Edad,
                FechaNacimiento = c.FechaNacimiento,
                Direccion = c.Direccion,
                CURP = c.CURP,
                Email = c.Email,
                MatriculaProfesional = c.MatriculaProfesional,
                Telefono = c.Telefono,
                Genero = c.Genero,
                FechaCreacion = c.FechaCreacion,
                FechaActualizacion = c.FechaActualizacion,
                FechaContrato = c.FechaContrato,
                Licencia = c.Licencia,
                EsActivo = c.EsActivo,
                ID_Cede = c.ID_Cede.ToString(),
                Estado = c.Cede != null ? c.Cede.Estado : "Desconocido",
                UsuarioNombre = c.Usuarios.FirstOrDefault() != null ? c.Usuarios.FirstOrDefault().Nombre : "Sin usuario",
                UsuarioContrasenia = c.Usuarios.FirstOrDefault() != null ? c.Usuarios.FirstOrDefault().Contrasenia : "",
                Rol = c.ColaboradorDetalles.FirstOrDefault() != null && c.ColaboradorDetalles.FirstOrDefault().TipoColaborador != null
                      ? c.ColaboradorDetalles.FirstOrDefault().TipoColaborador.Tipo
                      : "Sin rol"
            })
            .FirstOrDefaultAsync();
    }



    public async Task<ColaboradorConUsuarioYDetalleDto?> GetByCurpConUsuariosYDetalleAsync(string curp)
    {
        return await _context.Colaboradores
            .Include(c => c.Usuarios)
            .Include(c => c.ColaboradorDetalles)
                .ThenInclude(d => d.TipoColaborador)
            .Where(c => c.CURP == curp)
            .Select(c => new ColaboradorConUsuarioYDetalleDto
            {
                ID = c.ID,
                Nombre = c.Nombre,
                ApellidoPaterno = c.ApellidoPaterno,
                ApellidoMaterno = c.ApellidoMaterno,
                Edad = c.Edad,
                FechaNacimiento = c.FechaNacimiento,
                Direccion = c.Direccion,
                CURP = c.CURP,
                Email = c.Email,
                MatriculaProfesional = c.MatriculaProfesional,
                Telefono = c.Telefono,
                Genero = c.Genero,
                FechaCreacion = c.FechaCreacion,
                FechaActualizacion = c.FechaActualizacion,
                FechaContrato = c.FechaContrato,
                Licencia = c.Licencia,
                EsActivo = c.EsActivo,
                ID_Cede = c.ID_Cede.ToString(),
                Estado = c.Cede != null ? c.Cede.Estado : "Desconocido",
                UsuarioNombre = c.Usuarios.FirstOrDefault() != null ? c.Usuarios.FirstOrDefault().Nombre : "Sin usuario",
                UsuarioContrasenia = c.Usuarios.FirstOrDefault() != null ? c.Usuarios.FirstOrDefault().Contrasenia : "",
                Rol = c.ColaboradorDetalles.FirstOrDefault() != null && c.ColaboradorDetalles.FirstOrDefault().TipoColaborador != null
                      ? c.ColaboradorDetalles.FirstOrDefault().TipoColaborador.Tipo
                      : "Sin rol"
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ColaboradorConUsuarioYDetalleDto>> GetColaboradoresPorEspecialidadAsync(int idEspecialidad)
    {
        return await _context.Colaboradores
            .Include(c => c.Usuarios)
            .Include(c => c.ColaboradorDetalles)
                .ThenInclude(d => d.TipoColaborador)
            .Where(c => c.ID_Especialidad == idEspecialidad && c.EsActivo)
            .Select(c => new ColaboradorConUsuarioYDetalleDto
            {
                ID = c.ID,
                Nombre = c.Nombre,
                ApellidoPaterno = c.ApellidoPaterno,
                ApellidoMaterno = c.ApellidoMaterno,
                Edad = c.Edad,
                FechaNacimiento = c.FechaNacimiento,
                Direccion = c.Direccion,
                CURP = c.CURP,
                Email = c.Email,
                MatriculaProfesional = c.MatriculaProfesional,
                Telefono = c.Telefono,
                Genero = c.Genero,
                FechaCreacion = c.FechaCreacion,
                FechaActualizacion = c.FechaActualizacion,
                FechaContrato = c.FechaContrato,
                Licencia = c.Licencia,
                EsActivo = c.EsActivo,
                ID_Cede = c.ID_Cede.ToString(),
                Estado = c.Cede != null ? c.Cede.Estado : "Desconocido",
                UsuarioNombre = c.Usuarios.FirstOrDefault() != null ? c.Usuarios.FirstOrDefault().Nombre : "Sin usuario",
                UsuarioContrasenia = c.Usuarios.FirstOrDefault() != null ? c.Usuarios.FirstOrDefault().Contrasenia : "",
                Rol = c.ColaboradorDetalles.FirstOrDefault() != null && c.ColaboradorDetalles.FirstOrDefault().TipoColaborador != null
                      ? c.ColaboradorDetalles.FirstOrDefault().TipoColaborador.Tipo
                      : "Sin rol"
            })
            .ToListAsync();





    }


    public async Task<bool> ReactivarColaboradorYUsuarioAsync(int id)
    {
        var colaborador = await _context.Colaboradores
            .Include(c => c.Usuarios)
            .FirstOrDefaultAsync(c => c.ID == id);

        if (colaborador == null)
            return false;

        colaborador.EsActivo = true;
        colaborador.FechaActualizacion = DateTime.Now;

        // Reactivar usuario si existe
        var usuario = colaborador.Usuarios.FirstOrDefault();
        if (usuario != null)
        {
            usuario.EsActivo = true;
            usuario.FechaActualizacion = DateTime.Now;
        }

        await _context.SaveChangesAsync();
        return true;
    }




}
