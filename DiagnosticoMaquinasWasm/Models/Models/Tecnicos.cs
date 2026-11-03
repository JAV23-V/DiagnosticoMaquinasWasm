using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DiagnosticoMaquinas.Models;

[Table("tecnicos")]
public class Tecnico : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; } = "";

    [Column("puesto")]
    public string Puesto { get; set; } = "";

    [Column("activo")]
    public bool Activo { get; set; }
}