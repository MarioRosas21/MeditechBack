namespace MediTech.Domain.Interfaces.Service.Pacientes_Services;
public interface IPacienteService
{
    Task<Paciente> AddAsync(Paciente paciente);
    Task<bool> DeleteAsync(Paciente paciente);
    Task<IEnumerable<Paciente?>> GetAllAsync();
    Task<Paciente?> GetPacienteByIdAsync(int pacienteId);
    Task<bool> UpdateAsync(Paciente pacientes);

    // Nuevos métodos para login
    Task<Paciente?> GetPacienteByEmailAsync(string email);
    Task<Paciente?> GetPacienteByCURPAsync(string curp);
}
