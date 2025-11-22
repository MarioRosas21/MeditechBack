namespace MediTech.Domain.Interfaces.Repositories.Citas_Repositories;
public interface ICitaRepository
{
    Task<IEnumerable<Cita>> GetAllAsync();
    Task<Cita?> GetByIdAsync(int id);
    Task<Cita> AddAsync(Cita cita);
    Task<bool> UpdateAsync(Cita cita);
    Task<bool> DeleteAsync(Cita cita);
    Task<IEnumerable<Cita>> GetCitasByColaboradorAsync(int colaboradorId);

}
