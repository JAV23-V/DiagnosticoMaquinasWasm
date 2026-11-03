using DiagnosticoMaquinas.Models;

namespace DiagnosticoMaquinasWasm.Services;

public class SesionService
{
    public Usuario UsuarioActual { get; set; } = new();
}
