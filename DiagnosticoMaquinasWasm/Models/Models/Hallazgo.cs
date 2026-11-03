using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("hallazgos")]
public class Hallazgo : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("diagnostico_id")]
    public long DiagnosticoId { get; set; }

    [Column("punto")]
    public string Punto { get; set; } = "";

    [Column("comentario")]
    public string Comentario { get; set; } = "";

    [Column("estatus")]
    public string Estatus { get; set; } = "";

    [Column("responsable")]
    public string Responsable { get; set; } = "";

    [Column("fecha_compromiso")]
    public DateTime? FechaCompromiso { get; set; }

    [Column("imagen")]
    public string Imagen { get; set; } = "";

    [Column("fecha_creacion")]
    public DateTime FechaCreacion { get; set; }
}

