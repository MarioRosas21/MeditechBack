namespace MediTech.Application.Services.Cede_Services.Features.CRUD.Queries.GetCedeById
{
    public class CedeVM
    {
        public int ID { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public bool EsActivo { get; set; }
    }

}
