

namespace MediTech.Application.Services.Especialidad_Services.Features.Queries.GetAllEspecialidadesActivas
{
    /// <summary>
    /// Handler que procesa la consulta para obtener todas las especialidades activas.
    /// </summary>
    public class GetAllEspecialidadesActivasHandler
        : IRequestHandler<GetAllEspecialidadesActivasQuery, IEnumerable<Especialidad>>
    {
        private readonly IEspecialidadRepository _especialidadRepository;

        public GetAllEspecialidadesActivasHandler(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        public async Task<IEnumerable<Especialidad>> Handle(
            GetAllEspecialidadesActivasQuery request,
            CancellationToken cancellationToken)
        {
            // 🔍 Llama al repositorio para obtener las especialidades activas
            var especialidades = await _especialidadRepository.GetAllActivasAsync();

            return especialidades;
        }
    }
}
