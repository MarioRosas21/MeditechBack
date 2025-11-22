namespace MediTech.Application.Services.Cede_Services.Features.CRUD.Queries.GetCedeByDireccion;

public class GetCedeByDireccionQuery : IRequest<CedeVM>
{
    public string Direccion { get; set; }

    public GetCedeByDireccionQuery(string direccion)
    {
        Direccion = direccion;
    }

    public GetCedeByDireccionQuery() { }
}
