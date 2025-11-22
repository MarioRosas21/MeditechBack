namespace MediTech.Domain.Interfaces.Repositories.Cedes_Repositories;
public interface ICedeRepository
{
    Task<Cede?> GetByIdAsync(int id);
    Task<Cede?> GetByDireccionAsync(string direccion);
    Task<IEnumerable<Cede>> GetAllAsync();
    Task<Cede> AddAsync(Cede cede);
    Task<bool> UpdateAsync(Cede cede);
    Task<bool> DeleteAsync(Cede cede);
}
