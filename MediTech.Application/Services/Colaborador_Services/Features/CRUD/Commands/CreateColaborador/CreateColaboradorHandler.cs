using MediTech.Application.Services.Colaborador_Services.Features.CRUD.Commands.CreateColaborador;
using MediTech.Domain.Dtos.Colaboradores;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediTech.Application.Commands.Usuarios;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Handlers
{
    public class CreateColaboradorHandler : IRequestHandler<CreateColaboradorCommand, RegistroResultadoDto>
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly ILogger<CreateColaboradorHandler> _logger;

        public CreateColaboradorHandler(
            IColaboradorRepository colaboradorRepository,
            ILogger<CreateColaboradorHandler> logger)
        {
            _colaboradorRepository = colaboradorRepository;
            _logger = logger;
        }

        public async Task<RegistroResultadoDto> Handle(CreateColaboradorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 🔹 Registrar colaborador y usuario completo (la validación se hace internamente)
                var resultado = await _colaboradorRepository.RegistrarUsuarioCompletoAsync(request.Dto);

                if (!resultado.Exito)
                {
                    _logger.LogWarning($"❌ Falló el registro: {resultado.Mensaje}");
                    return resultado; // devuelve tal cual el error de duplicado o fallo interno
                }

                _logger.LogInformation($"✅ Usuario creado correctamente. ID: {resultado.UsuarioId}");
                return resultado;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el colaborador.");

                return new RegistroResultadoDto
                {
                    Exito = false,
                    Mensaje = $"Error al crear el colaborador: {ex.Message}",
                    UsuarioId = null
                };
            }
        }
    }
}
