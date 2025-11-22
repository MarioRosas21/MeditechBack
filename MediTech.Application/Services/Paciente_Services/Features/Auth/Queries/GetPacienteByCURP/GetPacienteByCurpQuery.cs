    namespace MediTech.Application.Services.Paciente_Services.Features.Auth.Queries.GetPacienteByCURP;
    // Query para obtener un paciente por su CURP
    public class GetPacienteByCurpQuery : IRequest<PacienteVM>
    {
        public string CURP { get; set; }

        public GetPacienteByCurpQuery(string curp)
        {
            CURP = curp 
                ?? throw new ArgumentNullException(nameof(curp));
        }
    }

