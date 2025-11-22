namespace MediTech.Application.Services.Paciente_Services.Features.CRUD.Commands.DeletePaciente;

/// <summary>
/// Representa el comando que se envía cuando se desea eliminar un paciente del sistema.
/// </remarks>
public class DeletePacienteCommand : IRequest<bool>
{
    /*
     *  - El controlador recibe un DELETE /api/pacientes/{id}
     *  - Se crea un nuevo DeletePacienteCommand con el ID del paciente.
     *  - El Mediator lo envía al DeletePacienteCommandHandler.
     *  - El Handler verifica si existe el paciente y lo elimina.
     *  - Devuelve true si la operación fue exitosa, false si no se encontró o falló.
     */

    /// <summary>
    /// Identificador único del paciente que se desea eliminar.
    /// </summary>
    /// <example>42</example>
    public int Id { get; set; }

    /// <summary>
    /// Constructor que inicializa el comando con el ID del paciente.
    /// </summary>
    /// <param name="id">Identificador del paciente a eliminar.</param>
    public DeletePacienteCommand(int id)
    {
        Id = id;
    }
}
