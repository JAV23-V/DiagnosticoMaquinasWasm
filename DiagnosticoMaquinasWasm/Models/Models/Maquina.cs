using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DiagnosticoMaquinas.Models;

[Table("maquinas")]
public class Maquina : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; } = "";

    [Column("serie")]
    public string Serie { get; set; } = "";

    [Column("area")]
    public string Area { get; set; } = "";

    [Column("modelo")]
    public string Modelo { get; set; } = "";

    [Column("estatus")]
    public bool Activo { get; set; }

    [Column("imagen_url")]
    public string ImagenUrl { get; set; } = "";
}