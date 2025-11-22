using MediatR;
using MediTech.Domain.Dtos.Recetas;

namespace MediTech.Application.Recetas.Commands.CreateReceta
{
    public class CreateRecetaCommand : IRequest<bool>
    {
        public CreateRecetaDto Data { get; set; }

        public CreateRecetaCommand(CreateRecetaDto data)
        {
            Data = data;
        }
    }
}
