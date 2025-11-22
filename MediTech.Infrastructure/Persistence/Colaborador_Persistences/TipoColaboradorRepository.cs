using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Entities.Colaboradores_Entities;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;
using Microsoft.EntityFrameworkCore;

namespace MediTech.Infrastructure.Persistence.Colaborador_Persistences
{
    public class TipoColaboradorRepository : ITipoColaboradorRepository
    {
        private readonly AppDbContext _context;

        public TipoColaboradorRepository(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Obtener todos los tipos de colaboradores
        public async Task<IEnumerable<TipoColaboradorDto>> GetAllAsync()
        {
            return await _context.TipoColaboradores
                .Select(tc => new TipoColaboradorDto
                {
                    ID = tc.ID,
                    Tipo = tc.Tipo
                })
                .ToListAsync();
        }

        // ✅ Obtener tipo de colaborador por ID
        public async Task<TipoColaboradorDto?> GetByIdAsync(int id)
        {
            var tipo = await _context.TipoColaboradores
                .FirstOrDefaultAsync(t => t.ID == id);

            if (tipo == null)
                return null;

            return new TipoColaboradorDto
            {
                ID = tipo.ID,
                Tipo = tipo.Tipo
            };
        }

        // ✅ Agregar nuevo tipo de colaborador
        public async Task AddAsync(TipoColaboradores tipoColaborador)
        {
            _context.TipoColaboradores.Add(tipoColaborador);
            await _context.SaveChangesAsync();
        }

        // ✅ Actualizar tipo de colaborador
        public async Task UpdateAsync(TipoColaboradores tipoColaborador)
        {
            _context.TipoColaboradores.Update(tipoColaborador);
            await _context.SaveChangesAsync();
        }

        // ✅ Eliminar tipo de colaborador
        public async Task<bool> DeleteAsync(int id)
        {
            var tipo = await _context.TipoColaboradores.FindAsync(id);
            if (tipo == null)
                return false;

            _context.TipoColaboradores.Remove(tipo);
            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Verificar si existe un tipo por nombre
        public async Task<bool> ExisteTipoAsync(string tipo)
        {
            return await _context.TipoColaboradores
                .AnyAsync(t => t.Tipo.ToLower() == tipo.ToLower());
        }



        public async Task<ColaboradorTipoDto> ObtenerTipoColaboradorPorUsuarioId(int usuarioId)
    {
        var detalle = await _context.ColaboradorDetalle
            .Include(cd => cd.Colaborador)         // Trae la información del colaborador
            .Include(cd => cd.TipoColaborador)     // Trae la información del tipo de colaborador
            .Where(cd => cd.ID_Colaborador == usuarioId)
            .Select(cd => new ColaboradorTipoDto
            {
                NombreColaborador = cd.Colaborador.Nombre,  // Ajusta al nombre real del campo
                TipoColaborador = cd.TipoColaborador.Tipo // Ajusta al nombre real del campo
            })
            .FirstOrDefaultAsync();

        return detalle; // puede ser null si no se encuentra
    }




}
}
