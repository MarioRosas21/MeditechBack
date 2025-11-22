using MediTech.Application.Common.Interfaces.Repositories;
using MediTech.Domain.Dtos.Recetas;
using MediTech.Domain.Entities.Recetas_Entities;
using MediTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediTech.Domain.Entities.Recetas_Entities;
namespace MediTech.Infrastructure.Persistence.Recetas_Persistences
{
    /// <summary>
    /// Repositorio encargado de gestionar el acceso a datos
    /// para la tabla de Recetas Médicas.
    /// </summary>
    public class RecetasRepository : IRecetasRepository
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;

        public RecetasRepository(IConfiguration configuration, AppDbContext context)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException(nameof(configuration));
        }

        // ============================================================
        // 🔹 CREATE
        // ============================================================
        public async Task<bool> CreateAsync(Recetas entity)
        {
            _context.Recetas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // ============================================================
        // 🔹 UPDATE
        // ============================================================
        public async Task<bool> UpdateAsync(Recetas entity)
        {
            var existente = await _context.Recetas.FirstOrDefaultAsync(r => r.ID == entity.ID);

            if (existente == null)
                return false;

            existente.Tratamientos = entity.Tratamientos;
            existente.FechaActualizacion = DateTime.Now;
            existente.ID_Doctor = entity.ID_Doctor;
            existente.ID_Paciente = entity.ID_Paciente;
            existente.ID_SignosVitales = entity.ID_SignosVitales;

            await _context.SaveChangesAsync();
            return true;
        }

        // ============================================================
        // 🔹 DELETE
        // ============================================================
        public async Task<bool> DeleteAsync(int id)
        {
            var receta = await _context.Recetas.FindAsync(id);

            if (receta == null)
                return false;

            _context.Recetas.Remove(receta);
            return await _context.SaveChangesAsync() > 0;
        }

        // ============================================================
        // 🔹 GET ALL (con información expandida)
        // ============================================================
        public async Task<IEnumerable<RecetasDto>> GetAllAsync()
        {
            return await _context.Recetas
                .Include(r => r.Paciente)
                .Include(r => r.Colaborador)
                .Include(r => r.SignosVitales)
                .Select(r => new RecetasDto
                {
                    ID = r.ID,
                    Tratamientos = r.Tratamientos,
                    FechaCreacion = r.FechaCreacion,
                    FechaActualizacion = r.FechaActualizacion,

                    // SIGNOS VITALES
                    IdSignosVitales = r.SignosVitales.ID,
                    Temperatura = r.SignosVitales.Temperatura,
                    Presion = r.SignosVitales.Presion,
                    Estatura = r.SignosVitales.Estatura,
                    Alergias = r.SignosVitales.Alergias,
                    FechaRegistro = r.SignosVitales.FechaRegistro,

                    // COLABORADOR
                    ID_Colaborador = r.Colaborador.ID,
                    ColaboradorNombre = r.Colaborador.Nombre,
                    ColaboradorApellidoPaterno = r.Colaborador.ApellidoPaterno,
                    ColaboradorApellidoMaterno = r.Colaborador.ApellidoMaterno,
                    ColaboradorEdad = r.Colaborador.Edad,
                    ColaboradorTelefono = r.Colaborador.Telefono,
                    ColaboradorEmail = r.Colaborador.Email,
                    MatriculaProfesional = r.Colaborador.MatriculaProfesional,

                    // PACIENTE
                    ID_Paciente = r.Paciente.ID,
                    PacienteNombre = r.Paciente.Nombre,
                    PacienteApellidoPaterno = r.Paciente.ApellidoPaterno,
                    PacienteApellidoMaterno = r.Paciente.ApellidoMaterno,
                    PacienteEdad = r.Paciente.Edad,
                    PacienteFechaNacimiento = r.Paciente.FechaNacimiento,
                    PacienteTelefono = r.Paciente.Telefono
                })
                .ToListAsync();
        }

        // ============================================================
        // 🔹 GET BY ID (con todo expandido)
        // ============================================================
        public async Task<RecetasDto?> GetByIdAsync(int id)
        {
            return await _context.Recetas
                .Include(r => r.Paciente)
                .Include(r => r.Colaborador)
                .Include(r => r.SignosVitales)
                .Where(r => r.ID == id)
                .Select(r => new RecetasDto
                {
                    ID = r.ID,
                    Tratamientos = r.Tratamientos,
                    FechaCreacion = r.FechaCreacion,
                    FechaActualizacion = r.FechaActualizacion,

                    // SIGNOS VITALES
                    IdSignosVitales = r.SignosVitales.ID,
                    Temperatura = r.SignosVitales.Temperatura,
                    Presion = r.SignosVitales.Presion,
                    Estatura = r.SignosVitales.Estatura,
                    Alergias = r.SignosVitales.Alergias,
                    FechaRegistro = r.SignosVitales.FechaRegistro,

                    // COLABORADOR
                    ID_Colaborador = r.Colaborador.ID,
                    ColaboradorNombre = r.Colaborador.Nombre,
                    ColaboradorApellidoPaterno = r.Colaborador.ApellidoPaterno,
                    ColaboradorApellidoMaterno = r.Colaborador.ApellidoMaterno,
                    ColaboradorEdad = r.Colaborador.Edad,
                    ColaboradorTelefono = r.Colaborador.Telefono,
                    ColaboradorEmail = r.Colaborador.Email,
                    MatriculaProfesional = r.Colaborador.MatriculaProfesional,

                    // PACIENTE
                    ID_Paciente = r.Paciente.ID,
                    PacienteNombre = r.Paciente.Nombre,
                    PacienteApellidoPaterno = r.Paciente.ApellidoPaterno,
                    PacienteApellidoMaterno = r.Paciente.ApellidoMaterno,
                    PacienteEdad = r.Paciente.Edad,
                    PacienteFechaNacimiento = r.Paciente.FechaNacimiento,
                    PacienteTelefono = r.Paciente.Telefono
                })
                .FirstOrDefaultAsync();
        }

        // ============================================================
        // 🔹 GET POR PACIENTE
        // ============================================================
        public async Task<IEnumerable<RecetasDto>> GetByPacienteIdAsync(int pacienteId)
        {
            return await _context.Recetas
                .Include(r => r.Paciente)
                .Include(r => r.Colaborador)
                .Include(r => r.SignosVitales)
                .Where(r => r.ID_Paciente == pacienteId)
                .Select(r => new RecetasDto
                {
                    ID = r.ID,
                    Tratamientos = r.Tratamientos,
                    FechaCreacion = r.FechaCreacion,
                    FechaActualizacion = r.FechaActualizacion,

                    IdSignosVitales = r.SignosVitales.ID,
                    Temperatura = r.SignosVitales.Temperatura,
                    Presion = r.SignosVitales.Presion,
                    Estatura = r.SignosVitales.Estatura,
                    Alergias = r.SignosVitales.Alergias,
                    FechaRegistro = r.SignosVitales.FechaRegistro,

                    ID_Colaborador = r.Colaborador.ID,
                    ColaboradorNombre = r.Colaborador.Nombre,
                    ColaboradorApellidoPaterno = r.Colaborador.ApellidoPaterno,
                    ColaboradorApellidoMaterno = r.Colaborador.ApellidoMaterno,
                    ColaboradorEdad = r.Colaborador.Edad,
                    ColaboradorTelefono = r.Colaborador.Telefono,
                    ColaboradorEmail = r.Colaborador.Email,
                    MatriculaProfesional = r.Colaborador.MatriculaProfesional,

                    ID_Paciente = r.Paciente.ID,
                    PacienteNombre = r.Paciente.Nombre,
                    PacienteApellidoPaterno = r.Paciente.ApellidoPaterno,
                    PacienteApellidoMaterno = r.Paciente.ApellidoMaterno,
                    PacienteEdad = r.Paciente.Edad,
                    PacienteFechaNacimiento = r.Paciente.FechaNacimiento,
                    PacienteTelefono = r.Paciente.Telefono
                })
                .ToListAsync();
        }

        // ============================================================
        // 🔹 GET POR COLABORADOR
        // ============================================================
        public async Task<IEnumerable<RecetasDto>> GetByColaboradorIdAsync(int colaboradorId)
        {
            return await _context.Recetas
                .Include(r => r.Paciente)
                .Include(r => r.Colaborador)
                .Include(r => r.SignosVitales)
                .Where(r => r.ID_Doctor == colaboradorId)
                .Select(r => new RecetasDto
                {
                    ID = r.ID,
                    Tratamientos = r.Tratamientos,
                    FechaCreacion = r.FechaCreacion,
                    FechaActualizacion = r.FechaActualizacion,

                    IdSignosVitales = r.SignosVitales.ID,
                    Temperatura = r.SignosVitales.Temperatura,
                    Presion = r.SignosVitales.Presion,
                    Estatura = r.SignosVitales.Estatura,
                    Alergias = r.SignosVitales.Alergias,
                    FechaRegistro = r.SignosVitales.FechaRegistro,

                    ID_Colaborador = r.Colaborador.ID,
                    ColaboradorNombre = r.Colaborador.Nombre,
                    ColaboradorApellidoPaterno = r.Colaborador.ApellidoPaterno,
                    ColaboradorApellidoMaterno = r.Colaborador.ApellidoMaterno,
                    ColaboradorEdad = r.Colaborador.Edad,
                    ColaboradorTelefono = r.Colaborador.Telefono,
                    ColaboradorEmail = r.Colaborador.Email,
                    MatriculaProfesional = r.Colaborador.MatriculaProfesional,

                    ID_Paciente = r.Paciente.ID,
                    PacienteNombre = r.Paciente.Nombre,
                    PacienteApellidoPaterno = r.Paciente.ApellidoPaterno,
                    PacienteApellidoMaterno = r.Paciente.ApellidoMaterno,
                    PacienteEdad = r.Paciente.Edad,
                    PacienteFechaNacimiento = r.Paciente.FechaNacimiento,
                    PacienteTelefono = r.Paciente.Telefono
                })
                .ToListAsync();
        }
    }
}
