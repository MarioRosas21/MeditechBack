using MediatR;
using MediTech.Domain.Dtos.Recetas;

namespace MediTech.Application.Recetas.Commands.UpdateReceta
{
    public class UpdateRecetaCommand : IRequest<bool>
    {
        public UpdateRecetaDto Data { get; set; }

        public UpdateRecetaCommand(UpdateRecetaDto data)
        {
            Data = data;
        }
    }
}
