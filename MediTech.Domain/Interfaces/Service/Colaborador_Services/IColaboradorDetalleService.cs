using MediTech.Domain.Entities.Colaboradores_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediTech.Domain.Interfaces.Repositories.Cedes_Repositories
{
    public interface IColaboradorDetalleService
    {
        Task<ColaboradorDetalle?> GetByIdAsync(int id);
        Task<IEnumerable<ColaboradorDetalle>> GetByColaboradorIdAsync(int colaboradorId);
        Task AddAsync(ColaboradorDetalle detalle);
        Task UpdateAsync(ColaboradorDetalle detalle);
        Task<bool> DeleteAsync(int id);

    }
}
