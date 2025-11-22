
using MediTech.Domain.Entities.Pacientes_Entities;

namespace MediTech.Infrastructure.Persistence.Paciente_Persistences
{
    /// <summary>
    /// Esta clase se encarga de leer los datos de la base de datos
    /// </summary>
    public class PacienteRepository : IPacienteRepository
    {
        private readonly string _connectionString;               //esta variable es para almacenar la cadena de coneccion de la base de datos.
        private readonly AppDbContext _context;                  //esta variable hace referencia al contexto de la tabla de base de datos.

        //Constructor
        public PacienteRepository(IConfiguration configuration, AppDbContext context)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException(nameof(configuration));
        }
        /// <summary>
        /// Metodos para el CRUP de Pacientes
        /// </summary>
        /// <returns></returns>

        //Metodo que nos devuleve el paciente por Id
        public async Task<Paciente?> GetPacienteByIdAsync(int pacienteId)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.ID == pacienteId);
        }

        //Metodo que nos devuleve todos los pacientes
        public async Task<IEnumerable<Paciente?>> GetAllAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        //Metodo que agrega un nuvo paciente a la base de datos
        public async Task<Paciente> AddAsync(Paciente paciente)
        {
            var nuevoPaciente = await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
            return nuevoPaciente.Entity;
        }

        // Método que elimina un paciente de la base de datos.
        public async Task<bool> DeleteAsync(Paciente paciente)
        {
            _context.Pacientes.Remove(paciente);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }


        //Metodo que actualiza un paciente
        public async Task<bool> UpdateAsync(Paciente paciente)
        {
            _context.Entry(paciente).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }


        /// <summary>
        ///  estos metodos de extraccionde datos de la base de datos, es para el login
        /// </summary>

        //Metodo que trae un paciente por Email
        public async Task<Paciente?> GetPacienteByEmailAsync(string email)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.Email == email);
        }

        //Metodo que trae un paciente por CURP
        public async Task<Paciente?> GetPacienteByCURPAsync(string curp)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.CURP == curp);
        }

        // Método que trae un paciente por teléfono
        public async Task<Paciente?> GetPacienteByTelefonoAsync(string telefono)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.Telefono == telefono);
        }

        public async Task<bool> ExistePacienteAsync(string curp, string email)
        {
            return await _context.Pacientes.AnyAsync(p => p.CURP == curp || p.Email == email);
        }

        public async Task<Paciente?> GetPacienteByTokenAsync(string token)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.TokenVerificacionEmail == token);
        }

    }
}
