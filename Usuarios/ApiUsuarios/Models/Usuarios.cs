using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ApiUsuarios.Models
{
    public class Usuarios
    {
        [Key]
        public string UsuarioId { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; } = true;
        public string? Rol { get; set; }

    }
}
