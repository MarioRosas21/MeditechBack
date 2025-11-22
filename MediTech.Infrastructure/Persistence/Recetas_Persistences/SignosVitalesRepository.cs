using MediTech.Domain.Dtos.Recetas;
using MediTech.Domain.Dtos.SignosVitales;
using MediTech.Domain.Entities;

namespace MediTech.Infrastructure.Persistence.Recetas_Persistences
{
    /// <summary>
    /// Esta clase se encarga de leer los datos de la base de datos para la tabla de Signos Vitales.
    /// </summary>
    public class SignosVitalesRepository : ISignosVitalesRepository
    {
        private readonly string _connectionString;     
        private readonly AppDbContext _context;        

        // Constructor
        public SignosVitalesRepository(IConfiguration configuration, AppDbContext context)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException(nameof(configuration));
        }






        public async Task<bool> CreateAsync(CreateSignosVitalesDto dto)
        {
            var entity = new SignosVitales
            {
                Temperatura = dto.Temperatura,
                Presion = dto.Presion,
                Estatura = dto.Estatura,
                Alergias = dto.Alergias,
                ID_Colaborador = dto.ID_Colaborador,
                ID_Paciente = dto.ID_Paciente,
                FechaRegistro =dto.FechaRegistro
            };

            _context.SignosVitales.Add(entity);
            await _context.SaveChangesAsync();

            return true;
        }





        /// <summary>
        /// Devuelve un registro de signos vitales por ID.
        /// Incluye al colaborador y paciente relacionado.
        /// </summary>
        public async Task<IEnumerable<SignosVitalesDto>> GetByPacienteIdAsync(int pacienteId)
        {
            return await _context.SignosVitales
                .Include(s => s.Colaborador)
                .Include(s => s.Paciente)
                .Where(s => s.ID_Paciente == pacienteId)
                .Select(s => new SignosVitalesDto
                {
                    IdSignosVitales = s.ID,
                    Temperatura = s.Temperatura,
                    Presion = s.Presion,
                    Estatura = s.Estatura,
                    Alergias = s.Alergias,
                    FechaRegistro=s.FechaRegistro,

                    ID_Colaborador = s.Colaborador.ID,
                    ColaboradorNombre = s.Colaborador.Nombre,
                    ColaboradorApellidoPaterno = s.Colaborador.ApellidoPaterno,
                    ColaboradorApellidoMaterno = s.Colaborador.ApellidoMaterno,
                    ColaboradorEdad = s.Colaborador.Edad,
                    ColaboradorTelefono = s.Colaborador.Telefono,
                    ColaboradorEmail = s.Colaborador.Email,
                    MatriculaProfesional = s.Colaborador.MatriculaProfesional,

                    ID_Paciente = s.Paciente.ID,
                    PacienteNombre = s.Paciente.Nombre,
                    PacienteApellidoPaterno = s.Paciente.ApellidoPaterno,
                    PacienteApellidoMaterno = s.Paciente.ApellidoMaterno,
                    PacienteEdad = s.Paciente.Edad,
                    PacienteFechaNacimiento = s.Paciente.FechaNacimiento,
                    PacienteTelefono = s.Paciente.Telefono
                })
                .ToListAsync();
        }

        /// <summary>
        /// Agrega un nuevo registro de signos vitales.
        /// </summary>
        public async Task<SignosVitales> AddAsync(SignosVitales entity)
        {
            var nuevo = await _context.SignosVitales.AddAsync(entity);
            await _context.SaveChangesAsync();
            return nuevo.Entity;
        }

        /// <summary>
        /// Actualiza un registro de signos vitales.
        /// </summary>
        public async Task<bool> UpdateAsync(SignosVitalesUpdateDto dto)
        {
            var entity = await _context.SignosVitales.FirstOrDefaultAsync(x => x.ID == dto.ID);

            if (entity == null)
                return false;

            entity.Temperatura = dto.Temperatura;
            entity.Presion = dto.Presion;
            entity.Estatura = dto.Estatura;
            entity.Alergias = dto.Alergias;
            entity.FechaRegistro = dto.FechaRegistro;
            entity.ID_Colaborador = dto.ID_Colaborador;
            entity.ID_Paciente = dto.ID_Paciente;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(SignosVitales entity)
        {
            _context.SignosVitales.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // -------------------------------------------------------------------------------------------
        // MÉTODOS PERSONALIZADOS
        // -------------------------------------------------------------------------------------------

        /// <summary>
        /// Obtiene todos los signos vitales registrados por un colaborador.
        /// </summary>
        public async Task<IEnumerable<SignosVitales>> GetByColaboradorIdAsync(int colaboradorId)
        {
            return await _context.SignosVitales
                .Include(sv => sv.Colaborador)
                .Include(sv => sv.Paciente)
                .Where(sv => sv.ID_Colaborador == colaboradorId)
                .ToListAsync();
        }



        public async Task<IEnumerable<SignosVitalesDto>> GetAllAsync()
        {
            return await _context.SignosVitales
                .Include(s => s.Colaborador)
                .Include(s => s.Paciente)
                .Select(s => new SignosVitalesDto
                {
                    // SIGNOS VITALES
                    IdSignosVitales = s.ID,
                    Temperatura = s.Temperatura,
                    Presion = s.Presion,
                    Estatura = s.Estatura,
                    Alergias = s.Alergias,
                    FechaRegistro = s.FechaRegistro,

                    // COLABORADOR
                    ID_Colaborador = s.Colaborador.ID,
                    ColaboradorNombre = s.Colaborador.Nombre,
                    ColaboradorApellidoPaterno = s.Colaborador.ApellidoPaterno,
                    ColaboradorApellidoMaterno = s.Colaborador.ApellidoMaterno,
                    ColaboradorEdad = s.Colaborador.Edad,
                    ColaboradorTelefono = s.Colaborador.Telefono,
                    ColaboradorEmail = s.Colaborador.Email,
                    MatriculaProfesional = s.Colaborador.MatriculaProfesional,

                    // PACIENTE
                    ID_Paciente = s.Paciente.ID,
                    PacienteNombre = s.Paciente.Nombre,
                    PacienteApellidoPaterno = s.Paciente.ApellidoPaterno,
                    PacienteApellidoMaterno = s.Paciente.ApellidoMaterno,
                    PacienteEdad = s.Paciente.Edad,
                    PacienteFechaNacimiento = s.Paciente.FechaNacimiento,
                    PacienteTelefono = s.Paciente.Telefono
                })
                .ToListAsync();
        }

        // ============================================================
        // 🔹 NUEVO MÉTODO: Obtener por ID paciente + Fecha
        // ============================================================
        public async Task<SignosVitalesDto?> GetByPacienteAndFechaAsync(int pacienteId, DateTime fecha)
        {
            return await _context.SignosVitales
                .Include(s => s.Colaborador)
                .Include(s => s.Paciente)
                .Where(s =>
                    s.ID_Paciente == pacienteId &&
                    s.FechaRegistro.Date == fecha.Date)
                .Select(s => new SignosVitalesDto
                {
                    IdSignosVitales = s.ID,
                    Temperatura = s.Temperatura,
                    Presion = s.Presion,
                    Estatura = s.Estatura,
                    Alergias = s.Alergias,
                    FechaRegistro = s.FechaRegistro,

                    ID_Colaborador = s.Colaborador.ID,
                    ColaboradorNombre = s.Colaborador.Nombre,
                    ColaboradorApellidoPaterno = s.Colaborador.ApellidoPaterno,
                    ColaboradorApellidoMaterno = s.Colaborador.ApellidoMaterno,
                    ColaboradorEdad = s.Colaborador.Edad,
                    ColaboradorTelefono = s.Colaborador.Telefono,
                    ColaboradorEmail = s.Colaborador.Email,
                    MatriculaProfesional = s.Colaborador.MatriculaProfesional,

                    ID_Paciente = s.Paciente.ID,
                    PacienteNombre = s.Paciente.Nombre,
                    PacienteApellidoPaterno = s.Paciente.ApellidoPaterno,
                    PacienteApellidoMaterno = s.Paciente.ApellidoMaterno,
                    PacienteEdad = s.Paciente.Edad,
                    PacienteFechaNacimiento = s.Paciente.FechaNacimiento,
                    PacienteTelefono = s.Paciente.Telefono
                })
                .FirstOrDefaultAsync();
        }
    }
}
