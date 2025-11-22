using MediTech.Application.Queries.Colaboradores;
using MediTech.Domain.Entities.Colaboradores_Entities;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Queries.GetColaboradorById
{
    /// <summary>
    /// Handler para procesar la consulta de obtener un colaborador por ID
    /// </summary>
    public class GetColaboradorByIdHandler : IRequestHandler<GetColaboradorByIdQuery, Colaborador>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public GetColaboradorByIdHandler(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<Colaborador> Handle(GetColaboradorByIdQuery request, CancellationToken cancellationToken)
        {
            // Trae el colaborador por ID desde el repositorio
            var colaborador = await _colaboradorRepository.GetByIdAsync(request.Id);

            return colaborador; // puede ser null si no existe
        }
    }
}
