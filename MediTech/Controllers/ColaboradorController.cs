using MediatR;
using MediTech.Application.Colaboradores.Queries;
using MediTech.Application.Commands.Usuarios;
using MediTech.Application.Features.Colaboradores.Commands.ReactivarColaborador;
using MediTech.Application.Queries.Colaboradores;
using MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetCitaDePacienteByCurpOEmail;
using MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetCitasDeColaborador;
using MediTech.Application.Services.Colaborador_Services.Features.CRUD.Commands.CreateColaborador;
using MediTech.Application.Services.Colaborador_Services.Features.CRUD.Commands.UpdateColaborador;
using MediTech.Application.Services.Colaborador_Services.Features.CRUD.Queries.GetColaboradoresByEspecialidad;
using MediTech.Application.Services.Colaborador_Services.Features.Queries;
using MediTech.Application.Usuarios.Commands;
using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Entities.Colaboradores_Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MediTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ColaboradorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // 🔹 POST api/colaborador
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearUsuarioDto dto)
        {
            var command = new CreateColaboradorCommand(dto);
            var resultado = await _mediator.Send(command);

            if (!resultado.Exito)
                return BadRequest(new { mensaje = resultado.Mensaje });

            return Ok(new
            {
                mensaje = resultado.Mensaje,
                usuarioId = resultado.UsuarioId
            });
        }

        // 🔹 DELETE api/colaborador/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteColaboradorCommand(id);
            var eliminado = await _mediator.Send(command);

            if (eliminado)
                return Ok(new { mensaje = "Colaborador desactivado correctamente", ColaboradorID = id });

            return NotFound(new { mensaje = "No se encontró el colaborador para eliminar", ColaboradorID = id });
        }

        // 🔹 PUT api/colaborador/reactivar/{id}
        [HttpPut("reactivar/{id:int}")]
        public async Task<IActionResult> Reactivar(int id)
        {
            var resultado = await _mediator.Send(new ReactivarColaboradorCommand(id));

            if (!resultado)
                return NotFound("No se pudo reactivar el colaborador.");

            return Ok("Colaborador reactivado correctamente.");
        }

        // 🔹 PUT api/colaborador/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrearUsuarioDto dto)
        {
            var command = new UpdateColaboradorCommand(id, dto);
            var actualizado = await _mediator.Send(command);

            if (actualizado)
                return Ok(new { mensaje = "Colaborador actualizado correctamente", ColaboradorID = id });

            return NotFound(new { mensaje = "No se encontró el colaborador para actualizar", ColaboradorID = id });
        }

        // 🔹 GET api/colaborador
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var colaboradores = await _mediator.Send(new GetAllColaboradoresConUsuariosYDetalleQuery());
            return Ok(colaboradores);
        }

        // 🔹 GET api/colaborador/id/{id}
        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var colaborador = await _mediator.Send(new GetColaboradorConUsuariosYDetalleByIdQuery(id));

            if (colaborador == null)
                return NotFound(new { Message = "Colaborador no encontrado" });

            return Ok(colaborador);
        }

        // 🔹 GET api/colaborador/curp/{curp}
        [HttpGet("curp/{curp}")]
        public async Task<IActionResult> GetByCurp(string curp)
        {
            var colaborador = await _mediator.Send(new GetColaboradorConUsuariosYDetalleByCurpQuery(curp));

            if (colaborador == null)
                return NotFound(new { Message = "Colaborador no encontrado" });

            return Ok(colaborador);
        }

        // 🔹 GET api/colaborador/especialidad/{idEspecialidad}
        [HttpGet("especialidad/{idEspecialidad:int}")]
        public async Task<IActionResult> GetByEspecialidad(int idEspecialidad)
        {
            var colaboradores = await _mediator.Send(new GetColaboradoresByEspecialidadQuery(idEspecialidad));

            if (colaboradores == null || !colaboradores.Any())
                return NotFound(new { mensaje = "No se encontraron colaboradores con esa especialidad" });

            return Ok(colaboradores);
        }

        // 🔹 GET api/colaborador/citas-paciente/{identificador}
        [Authorize(Policy = "EsMedicoOEnfermeroByRole")]
        [HttpGet("citas-paciente/{identificador}")]
        public async Task<IActionResult> GetCitasDePaciente(string identificador)
        {
            string? curp = identificador.Contains("@") ? null : identificador;
            string? email = identificador.Contains("@") ? identificador : null;

            var query = new GetCitaDePacienteByCurpOEmailQuery(curp, email);
            var citas = await _mediator.Send(query);

            return Ok(citas);
        }

        // 🔹 GET api/colaborador/citas-colaborador/{idColaborador}
        [Authorize(Policy = "EsMedicoOEnfermeroByRole")]
        [HttpGet("citas-colaborador/{idColaborador:int}")]
        public async Task<IActionResult> GetCitasDeColaborador(int idColaborador)
        {
            var query = new GetCitasDeColaboradorQuery(idColaborador);
            var citas = await _mediator.Send(query);

            return Ok(citas);
        }
    }
}
