using MediatR;
using MediTech.Domain.Dtos.Recetas;

namespace MediTech.Application.Recetas.Commands
{
    public class CreateSignosVitalesCommand : IRequest<bool>
    {
        public CreateSignosVitalesDto Dto { get; set; }

        public CreateSignosVitalesCommand(CreateSignosVitalesDto dto)
        {
            Dto = dto;
        }
    }
}

