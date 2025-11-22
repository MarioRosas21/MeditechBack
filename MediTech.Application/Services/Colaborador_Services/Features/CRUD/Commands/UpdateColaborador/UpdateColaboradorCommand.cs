using MediTech.Domain.Dtos.Colaboradores;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Commands.UpdateColaborador
{
    public class UpdateColaboradorCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public CrearUsuarioDto Dto { get; set; }

        public UpdateColaboradorCommand(int id, CrearUsuarioDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
}
