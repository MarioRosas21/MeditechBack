using MediatR;

namespace MediTech.Application.Recetas.Commands
{
    public class DeleteSignosVitalesCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteSignosVitalesCommand(int id)
        {
            Id = id;
        }
    }
}
