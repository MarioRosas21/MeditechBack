namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Queries.GetAllPacientes;

/// <summary>
/// Este Query representa una solicitud para obtener la lista completa de pacientes.
/// IRequest<List<PacienteVM>> indica que el handler devolverá una lista de objetos de tipo PacienteVM (Vista Modelo).
/// </summary>

public class GetAllPacientesQuery : IRequest<List<PacienteVM>>
{
    // No requiere parámetros, ya que se espera que traiga todos los pacientes disponibles.
    // Sin embargo, se podrían agregar filtros (por ejemplo, activos, por género, etc.) en el futuro, generar otra calse query para estas acciones.
}
