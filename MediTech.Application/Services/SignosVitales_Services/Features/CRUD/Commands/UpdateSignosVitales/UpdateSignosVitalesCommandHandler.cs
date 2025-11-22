using MediatR;
using MediTech.Application.Recetas.Commands;
using MediTech.Infrastructure.Persistence.Recetas_Persistences;

namespace MediTech.Application.Recetas.Handlers
{
    public class UpdateSignosVitalesCommandHandler
        : IRequestHandler<UpdateSignosVitalesCommand, bool>
    {
        private readonly ISignosVitalesRepository _repository;

        public UpdateSignosVitalesCommandHandler(ISignosVitalesRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateSignosVitalesCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.Dto);
        }
    }
}
