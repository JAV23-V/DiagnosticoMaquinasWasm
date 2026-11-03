namespace DiagnosticoMaquinas.Models;

public class AccionGrid
{
    public string Id { get; set; } = "";

    public DateTime Fecha { get; set; }

    public string Maquina { get; set; } = "";

    public string Punto { get; set; } = "";

    public string Accion { get; set; } = "";

    public string Responsable { get; set; } = "";

    public DateTime? FechaCompromiso { get; set; }

    public string Estatus { get; set; } = "";

    public string EvidenciaUrl { get; set; } = "";
}