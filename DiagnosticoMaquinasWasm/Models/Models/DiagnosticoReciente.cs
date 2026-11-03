namespace DiagnosticoMaquinas.Models;

public class DiagnosticoReciente
{
    public long Id { get; set; }

    public string Maquina { get; set; } = "";

    public DateTime Fecha { get; set; }

    public int Hallazgos { get; set; }

    public string Estatus { get; set; } = "";
}