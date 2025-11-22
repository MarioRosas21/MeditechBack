using MediatR;

namespace MediTech.Application.Usuarios.Commands
{
    public class DeleteColaboradorCommand : IRequest<bool>
    {
        public int ColaboradorId { get; set; }

        public DeleteColaboradorCommand(int colaboradorId)
        {
            ColaboradorId = colaboradorId;
        }
    }
}
