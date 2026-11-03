using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DiagnosticoMaquinas.Models;

[Table("puntos_checklist")]
public class PuntoChecklist : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("seccion_id")]
    public long SeccionId { get; set; }

    [Column("codigo")]
    public string Codigo { get; set; } = "";

    [Column("nombre")]
    public string Nombre { get; set; } = "";

    [Column("activo")]
    public bool Activo { get; set; }
}
