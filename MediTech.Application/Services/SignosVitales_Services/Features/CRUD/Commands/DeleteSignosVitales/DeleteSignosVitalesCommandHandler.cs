//using MediatR;
//using MediTech.Application.Recetas.Commands;
//using MediTech.Infrastructure.Persistence.Recetas_Persistences;

//namespace MediTech.Application.Recetas.Handlers
//{
//    public class DeleteSignosVitalesCommandHandler
//        : IRequestHandler<DeleteSignosVitalesCommand, bool>
//    {
//        private readonly ISignosVitalesRepository _repository;

//        public DeleteSignosVitalesCommandHandler(ISignosVitalesRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<bool> Handle(DeleteSignosVitalesCommand request, CancellationToken cancellationToken)
//        {
//            // Obtener el registro
//            var entity = await _repository.GetByIdAsync(request.Id);
//            if (entity == null)
//                return false;

//            // Eliminarlo
//            return await _repository.DeleteAsync(entity);
//        }
//    }
//}
