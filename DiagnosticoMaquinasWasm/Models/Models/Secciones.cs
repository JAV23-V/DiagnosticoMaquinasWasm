using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DiagnosticoMaquinas.Models;

[Table("secciones")]
public class Seccion : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; } = "";

    [Column("descripcion")]
    public string Descripcion { get; set; } = "";

    [Column("activo")]
    public bool Activo { get; set; }
}