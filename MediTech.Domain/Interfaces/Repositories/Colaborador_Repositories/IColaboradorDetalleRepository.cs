namespace MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories
{
    public interface IColaboradorDetalleRepository
    {
        Task<ColaboradorDetalle?> GetByIdAsync(int id);
        Task<IEnumerable<ColaboradorDetalle>> GetByColaboradorIdAsync(int colaboradorId);
        Task AddAsync(ColaboradorDetalle detalle);
        Task UpdateAsync(ColaboradorDetalle detalle);
        Task<bool> DeleteAsync(int id);

    }
}
