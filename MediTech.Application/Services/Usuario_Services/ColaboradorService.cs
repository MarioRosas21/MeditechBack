
//using MediTech.Domain.Entities.Colaboradores_Entities;

//namespace MediTech.Application.Services.Usuario_Services;

//public class ColaboradorService
//{
//    private readonly IColaboradorRepository _colaboradorRepository;

//    public ColaboradorService(IColaboradorRepository colaboradorRepository)
//    {
//        _colaboradorRepository = colaboradorRepository;
//    }

//    public Task<IEnumerable<Colaborador>> GetAllAsync() => _colaboradorRepository.GetAllAsync();
//    public Task<Colaborador?> GetByIdAsync(int id) => _colaboradorRepository.GetByIdAsync(id);
//    public async Task<IEnumerable<Colaborador>> ObtenerTodosConFiltroAsync(bool? activo = null)
//    {
//        return await _colaboradorRepository.GetAllWithFilterAsync(activo);
//    }

//    public Task AddAsync(Colaborador colaborador) => _colaboradorRepository.AddAsync(colaborador);
//    public Task UpdateAsync(Colaborador colaborador) => _colaboradorRepository.UpdateAsync(colaborador);
//    public Task DeleteAsync(int id) => _colaboradorRepository.DeleteAsync(id);
//    public async Task<bool> EliminarColaboradorAsync(int id)
//    {
//        return await _colaboradorRepository.DeleteAsync(id);
//    }

//}
