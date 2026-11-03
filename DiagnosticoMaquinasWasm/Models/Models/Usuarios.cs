using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DiagnosticoMaquinas.Models;

[Table("usuarios")]
public class Usuario : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("usuario")]
    public string UsuarioSistema { get; set; } = "";

    [Column("nombre_completo")]
    public string NombreCompleto { get; set; } = "";

    [Column("correo")]
    public string Correo { get; set; } = "";

    [Column("telefono")]
    public string Telefono { get; set; } = "";

    [Column("rol")]
    public string Rol { get; set; } = "";

    [Column("area")]
    public string Area { get; set; } = "";

    [Column("foto_perfil")]
    public string FotoPerfil { get; set; } = "";

    [Column("password")]
    public string Password { get; set; } = "";

    [Column("activo")]
    public bool Activo { get; set; }


}