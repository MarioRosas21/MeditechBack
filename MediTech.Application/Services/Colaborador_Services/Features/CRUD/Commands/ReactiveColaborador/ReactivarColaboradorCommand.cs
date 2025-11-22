using MediatR;

namespace MediTech.Application.Features.Colaboradores.Commands.ReactivarColaborador
{
    public class ReactivarColaboradorCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public ReactivarColaboradorCommand(int id)
        {
            Id = id;
        }
    }
}
