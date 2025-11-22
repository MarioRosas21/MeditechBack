using MediTech.Domain.Dtos.Recetas;
using MediTech.Domain.Dtos.SignosVitales;
using MediTech.Domain.Entities;

public interface ISignosVitalesRepository
{
    Task<IEnumerable<SignosVitalesDto>> GetAllAsync();
    Task<SignosVitales> AddAsync(SignosVitales entity);
    Task<bool> UpdateAsync(SignosVitalesUpdateDto dto);
    Task<bool> DeleteAsync(SignosVitales entity);
    Task<IEnumerable<SignosVitalesDto>> GetByPacienteIdAsync(int pacienteId);
    Task<SignosVitalesDto?> GetByPacienteAndFechaAsync(int pacienteId, DateTime fecha);

    Task<IEnumerable<SignosVitales>> GetByColaboradorIdAsync(int colaboradorId);
    Task<bool> CreateAsync(CreateSignosVitalesDto dto);
}
