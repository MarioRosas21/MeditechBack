using MediatR;
using MediTech.Domain.Dtos.Recetas;

namespace MediTech.Application.Recetas.Commands
{
    public class UpdateSignosVitalesCommand : IRequest<bool>
    {
        public SignosVitalesUpdateDto Dto { get; set; }

        public UpdateSignosVitalesCommand(SignosVitalesUpdateDto dto)
        {
            Dto = dto;
        }
    }
}
