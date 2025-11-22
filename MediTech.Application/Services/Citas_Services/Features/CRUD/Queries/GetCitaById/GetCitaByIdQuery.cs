namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetCitaById;
public class GetCitaByIdQuery : IRequest<CitaVM>
{
    public int ID { get; set; }

    public GetCitaByIdQuery(int id)
    {
        ID = id;
    }
}
