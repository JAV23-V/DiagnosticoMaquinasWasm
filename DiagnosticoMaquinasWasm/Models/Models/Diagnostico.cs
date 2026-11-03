using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DiagnosticoMaquinas.Models;

[Table("diagnosticos")]
public class Diagnostico : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("maquina_id")]
    public long MaquinaId { get; set; }

    [Column("tecnico_id")]
    public long TecnicoId { get; set; }

    [Column("supervisor_id")]
    public long SupervisorId { get; set; }

    [Column("fecha")]
    public DateTime Fecha { get; set; }

    [Column("configuracion")]
    public string Configuracion { get; set; } = "";

    [Column("observaciones")]
    public string Observaciones { get; set; } = "";

    [Column("estatus")]
    public string Estatus { get; set; } = "";

    [Column("fecha_creacion")]
    public DateTime FechaCreacion { get; set; }

    [Column("finalizado")]
    public bool Finalizado { get; set; }

    [Column("fecha_cierre")]
    public DateTime? FechaCierre { get; set; }
}