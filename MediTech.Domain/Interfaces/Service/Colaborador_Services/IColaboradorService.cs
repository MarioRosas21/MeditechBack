using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Entities.Colaboradores_Entities;
using MediTech.Domain.Entities.Usuarios_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediTech.Domain.Interfaces.Service.Colaborador_Services
{
    internal interface IColaboradorService
    {
        Task<IEnumerable<Colaborador>> GetAllAsync();
        Task<Colaborador?> GetByIdAsync(int id);
        Task AddAsync(Colaborador colaborador);
        Task UpdateAsync(Colaborador colaborador);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Colaborador>> GetAllWithFilterAsync(bool? activo = null);
        Task<Usuarios> RegistrarUsuarioCompletoAsync(CrearUsuarioDto dto);

    }
}
