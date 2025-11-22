using MediTech.Domain.Dtos.Colaboradores;
using MediatR;

namespace MediTech.Application.Commands.Usuarios
{
    public class CreateColaboradorCommand : IRequest<RegistroResultadoDto>
    {
        public CrearUsuarioDto Dto { get; }

        public CreateColaboradorCommand(CrearUsuarioDto dto)
        {
            Dto = dto;
        }
    }
}
