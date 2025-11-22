namespace MediTech.Application.Services.Cede_Services.Features.CRUD.Queries.GetCedeById;
public class GetCedeByIdQuery : IRequest<CedeVM>
{
    public int Id { get; set; }

    public GetCedeByIdQuery(int id)
    {
        Id = id;
    }

    public GetCedeByIdQuery() { }
}
