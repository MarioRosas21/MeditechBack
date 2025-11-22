using MediTech.Domain.Entities.Colaboradores_Entities;

public class ColaboradorDetalle
{
    public int ID { get; set; }

    // FK hacia Colaborador
    public int ID_Colaborador { get; set; }
    public Colaborador Colaborador { get; set; }

    // FK hacia TipoColaboradores
    public int ID_TipoColaborador { get; set; }
    public TipoColaboradores TipoColaborador { get; set; }
}
