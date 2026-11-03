namespace DiagnosticoMaquinas.Models;

public class HallazgoResumenDto
{
    public string Seccion { get; set; } = "";
    public string Punto { get; set; } = "";
    public string Accion { get; set; } = "";
    public string Responsable { get; set; } = "";
    public DateTime? FechaCompromiso { get; set; }
    public string Estatus { get; set; } = "";
}