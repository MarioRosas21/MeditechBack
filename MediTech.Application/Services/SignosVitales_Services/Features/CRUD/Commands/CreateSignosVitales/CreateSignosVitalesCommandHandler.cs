using MediTech.Domain.Dtos.SignosVitales;

using MediTech.Application.Recetas.Commands;

namespace MediTech.Application.Recetas.Handlers
{
    public class CreateSignosVitalesCommandHandler
        : IRequestHandler<CreateSignosVitalesCommand, bool>
    {
        private readonly ISignosVitalesRepository _repository;

        public CreateSignosVitalesCommandHandler(ISignosVitalesRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateSignosVitalesCommand request, CancellationToken cancellationToken)
        {

            var entity = new MediTech.Domain.Entities.SignosVitales
            {
                Temperatura = request.Dto.Temperatura,
                Presion = request.Dto.Presion,
                Estatura = request.Dto.Estatura,
                Alergias = request.Dto.Alergias,
                ID_Colaborador = request.Dto.ID_Colaborador,
                ID_Paciente = request.Dto.ID_Paciente
            };

            var result = await _repository.AddAsync(entity);
            return result != null;
        }
    }
}
