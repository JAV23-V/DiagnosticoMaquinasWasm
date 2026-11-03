public class HistorialDiagnostico
{
    public long Id { get; set; }

    public DateTime Fecha { get; set; }

    public string Maquina { get; set; } = "";

    public string Serie { get; set; } = "";

    public string Responsable { get; set; } = "";

    public int Hallazgos { get; set; }

    public int Avance { get; set; }

    public bool Finalizado { get; set; }

}