using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Entities.Colaboradores_Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories
{
    public interface ITipoColaboradorRepository
    {
        Task<IEnumerable<TipoColaboradorDto>> GetAllAsync();
        Task<TipoColaboradorDto?> GetByIdAsync(int id);
        Task AddAsync(TipoColaboradores tipoColaborador);
        Task UpdateAsync(TipoColaboradores tipoColaborador);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExisteTipoAsync(string tipo);

        Task<ColaboradorTipoDto> ObtenerTipoColaboradorPorUsuarioId(int usuarioId);
    }
}
