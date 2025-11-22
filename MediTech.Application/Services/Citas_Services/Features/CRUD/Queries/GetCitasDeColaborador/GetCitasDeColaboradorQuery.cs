namespace MediTech.Application.Services.Citas_Services.Features.CRUD.Queries.GetCitasDeColaborador;

public record GetCitasDeColaboradorQuery(int ColaboradorId) : IRequest<List<CitaVM>>;
