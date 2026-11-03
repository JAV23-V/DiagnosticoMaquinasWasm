using ClosedXML.Excel;
using DiagnosticoMaquinas.Models;

namespace DiagnosticoMaquinasWasm.Services;

public class ExcelService
{
    public byte[] GenerarExcel(
        Diagnostico diagnostico,
        Maquina maquina,
        Tecnico tecnico,
        List<HallazgoResumenDto> hallazgos,
        int totalPuntos,
        int puntosRevisados,
        int puntosOK,
        int totalHallazgos,
        int puntosNA)
    {
        using var workbook = new XLWorkbook();

        var resumen = workbook.Worksheets.Add("Resumen");

        resumen.Cell("A1").Value = "Diagnóstico";
        resumen.Cell("B1").Value = diagnostico.Id;

        resumen.Cell("A2").Value = "Máquina";
        resumen.Cell("B2").Value = maquina.Nombre;

        resumen.Cell("A3").Value = "Serie";
        resumen.Cell("B3").Value = maquina.Serie;

        resumen.Cell("A4").Value = "Fecha";
        resumen.Cell("B4").Value = diagnostico.Fecha.ToString("dd/MM/yyyy");

        resumen.Cell("A5").Value = "Técnico";
        resumen.Cell("B5").Value = tecnico.Nombre;

        resumen.Cell("A6").Value = "Configuración";
        resumen.Cell("B6").Value = diagnostico.Configuracion;

        resumen.Cell("A7").Value = "Observaciones";
        resumen.Cell("B7").Value = diagnostico.Observaciones;

        resumen.Cell("D1").Value = "Indicadores";

        resumen.Cell("D2").Value = "Total puntos";
        resumen.Cell("E2").Value = totalPuntos;

        resumen.Cell("D3").Value = "Revisados";
        resumen.Cell("E3").Value = puntosRevisados;

        resumen.Cell("D4").Value = "OK";
        resumen.Cell("E4").Value = puntosOK;

        resumen.Cell("D5").Value = "Hallazgos";
        resumen.Cell("E5").Value = totalHallazgos;

        resumen.Cell("D6").Value = "N/A";
        resumen.Cell("E6").Value = puntosNA;

        var indicadores = resumen.Range("D1:E6");

        indicadores.Style.Font.Bold = true;
        indicadores.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

        resumen.Cell("D1").Style.Fill.BackgroundColor =
            XLColor.FromHtml("#0057D8");

        resumen.Cell("D1").Style.Font.FontColor =
            XLColor.White;
        var hallazgosSheet = workbook.Worksheets.Add("Hallazgos");
        var header = hallazgosSheet.Range("A1:F1");

        header.Style.Fill.BackgroundColor = XLColor.FromHtml("#0057D8");
        header.Style.Font.FontColor = XLColor.White;
        header.Style.Font.Bold = true;
        hallazgosSheet.Cell(1, 1).Value = "Sección";
        hallazgosSheet.Cell(1, 2).Value = "Punto";
        hallazgosSheet.Cell(1, 3).Value = "Acción";
        hallazgosSheet.Cell(1, 4).Value = "Responsable";
        hallazgosSheet.Cell(1, 5).Value = "Fecha compromiso";
        hallazgosSheet.Cell(1, 6).Value = "Estatus";

        int fila = 2;

        foreach (var item in hallazgos)
        {
            hallazgosSheet.Cell(fila, 1).Value = item.Seccion;
            hallazgosSheet.Cell(fila, 2).Value = item.Punto;
            hallazgosSheet.Cell(fila, 3).Value = item.Accion;
            hallazgosSheet.Cell(fila, 4).Value = item.Responsable;
            hallazgosSheet.Cell(fila, 5).Value =
                item.FechaCompromiso?.ToString("dd/MM/yyyy");
            hallazgosSheet.Cell(fila, 6).Value = item.Estatus;

            var celda = hallazgosSheet.Cell(fila, 3);
            switch (item.Accion)
            {
                case "Ajustar":
                    celda.Style.Fill.BackgroundColor = XLColor.Yellow;
                    break;

                case "Reemplazar":
                    celda.Style.Fill.BackgroundColor = XLColor.Red;
                    celda.Style.Font.FontColor = XLColor.White;
                    break;

                case "Reparar":
                    celda.Style.Fill.BackgroundColor = XLColor.Blue;
                    celda.Style.Font.FontColor = XLColor.White;
                    break;

                case "Limpiar":
                    celda.Style.Fill.BackgroundColor = XLColor.Orange;
                    break;

                case "Calibrar":
                    celda.Style.Fill.BackgroundColor = XLColor.Purple;
                    celda.Style.Font.FontColor = XLColor.White;
                    break;
            }

            fila++;
        }

        resumen.Columns().AdjustToContents();
        hallazgosSheet.Columns().AdjustToContents();
        var encabezado = resumen.Range("A1:B7");

        encabezado.Style.Font.Bold = true;
        encabezado.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        resumen.Cell("A1").Style.Fill.BackgroundColor = XLColor.DarkBlue;
        resumen.Cell("A1").Style.Font.FontColor = XLColor.White;
        resumen.Columns().AdjustToContents();
        hallazgosSheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);
        return stream.ToArray();


    }
    public byte[] GenerarReporteGeneral(
    string usuario,
    int diagnosticosMes,
    int accionesAbiertas,
    int accionesCerradas,
    int accionesVencidas,
    List<(string Maquina, int Total)> topMaquinas)
    {
        using var workbook = new XLWorkbook();

        var resumen = workbook.Worksheets.Add("Resumen General");

        resumen.Cell("A1").Value = "Usuario";
        resumen.Cell("B1").Value = usuario;

        resumen.Cell("A2").Value = "Fecha";
        resumen.Cell("B2").Value =
            DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        resumen.Cell("A4").Value = "Diagnósticos este mes";
        resumen.Cell("B4").Value = diagnosticosMes;

        resumen.Cell("A5").Value = "Acciones abiertas";
        resumen.Cell("B5").Value = accionesAbiertas;

        resumen.Cell("A6").Value = "Acciones cerradas";
        resumen.Cell("B6").Value = accionesCerradas;

        resumen.Cell("A7").Value = "Acciones vencidas";
        resumen.Cell("B7").Value = accionesVencidas;

        var maquinas = workbook.Worksheets.Add("Top Maquinas");

        maquinas.Cell(1, 1).Value = "Máquina";
        maquinas.Cell(1, 2).Value = "Hallazgos";

        int fila = 2;

        foreach (var item in topMaquinas)
        {
            maquinas.Cell(fila, 1).Value = item.Maquina;
            maquinas.Cell(fila, 2).Value = item.Total;

            fila++;
        }

        resumen.Columns().AdjustToContents();
        maquinas.Columns().AdjustToContents();

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }
}