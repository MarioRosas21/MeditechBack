using MediatR;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;

namespace MediTech.Application.Features.Colaboradores.Commands.ReactivarColaborador
{
    public class ReactivarColaboradorCommandHandler
        : IRequestHandler<ReactivarColaboradorCommand, bool>
    {
        private readonly IColaboradorRepository _repository;

        public ReactivarColaboradorCommandHandler(IColaboradorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ReactivarColaboradorCommand request, CancellationToken cancellationToken)
        {
            var resultado = await _repository.ReactivarColaboradorYUsuarioAsync(request.Id);
            return resultado;
        }
    }
}
