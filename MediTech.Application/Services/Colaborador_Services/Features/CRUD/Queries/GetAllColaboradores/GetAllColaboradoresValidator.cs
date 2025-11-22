using FluentValidation;
using MediTech.Application.Queries.Colaboradores;

namespace MediTech.Application.Validators.Colaboradores
{
    /// <summary>
    /// Valida los datos de entrada de la query GetAllColaboradores
    /// </summary>
    public class GetAllColaboradoresValidator : AbstractValidator<GetAllColaboradoresQuery>
    {
        public GetAllColaboradoresValidator()
        {
            // Actualmente no hay campos obligatorios, pero se deja preparado
            // para futuros filtros como "activo" u otros parámetros
        }
    }
}
