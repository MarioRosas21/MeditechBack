using MediTech.Domain.Dtos.Recetas;
using MediTech.Domain.Entities;
using MediTech.Domain.Entities.Recetas_Entities;
namespace MediTech.Application.Common.Interfaces.Repositories
{
    public interface IRecetasRepository
    {
        // CRUD
        Task<bool> CreateAsync(Recetas entity);
        Task<bool> UpdateAsync(Recetas entity);
        Task<bool> DeleteAsync(int id);

        // QUERIES
        Task<IEnumerable<RecetasDto>> GetAllAsync();
        Task<RecetasDto?> GetByIdAsync(int id);
        Task<IEnumerable<RecetasDto>> GetByPacienteIdAsync(int pacienteId);
        Task<IEnumerable<RecetasDto>> GetByColaboradorIdAsync(int colaboradorId);
    }
}
