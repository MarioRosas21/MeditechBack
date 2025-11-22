using MediatR;
using MediTech.Domain.Entities.Colaboradores_Entities;

namespace MediTech.Application.Services.Colaborador_Services.Features.CRUD.Queries.GetColaboradorConUsuarioYDetalleBYCURP
{
    public class GetColaboradorByCurpQuery : IRequest<Colaborador?>
    {
        public string Curp { get; set; }

        public GetColaboradorByCurpQuery(string curp)
        {
            Curp = curp;
        }
    }
}
