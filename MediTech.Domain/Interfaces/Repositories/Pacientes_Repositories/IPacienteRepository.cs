
namespace MediTech.Domain.Interfaces.Repositories.Pacientes_Repositories;
public interface IPacienteRepository
{
    Task<Paciente> AddAsync(Paciente paciente);
    Task<bool> DeleteAsync(Paciente paciente);
    Task<IEnumerable<Paciente?>> GetAllAsync();
    Task<Paciente?> GetPacienteByIdAsync(int pacienteId);
    Task<bool> UpdateAsync(Paciente pacientes);

    // Nuevos métodos para login
    Task<Paciente?> GetPacienteByEmailAsync(string email);
    Task<Paciente?> GetPacienteByCURPAsync(string curp);
    Task<Paciente?> GetPacienteByTelefonoAsync(string telefono);

    Task<bool> ExistePacienteAsync(string curp, string email);
    Task<Paciente> GetPacienteByTokenAsync(string token);
}
