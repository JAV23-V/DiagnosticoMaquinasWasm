namespace DiagnosticoMaquinas.Models;

using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("acciones_correctivas")]
public class AccionCorrectiva : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("diagnostico_id")]
    public long DiagnosticoId { get; set; }

    [Column("maquina_id")]
    public long MaquinaId { get; set; }

    [Column("seccion_id")]
    public long SeccionId { get; set; }

    [Column("punto")]
    public string Punto { get; set; } = "";

    [Column("accion")]
    public string Accion { get; set; } = "";

    [Column("responsable")]
    public string Responsable { get; set; } = "";

    [Column("fecha_compromiso")]
    public DateTime? FechaCompromiso { get; set; }

    [Column("estatus")]
    public string Estatus { get; set; } = "";

    [Column("comentario")]
    public string Comentario { get; set; } = "";

    [Column("imagen")]
    public string Imagen { get; set; } = "";

    [Column("evidencia_url")]
    public string EvidenciaUrl { get; set; } = "";
}