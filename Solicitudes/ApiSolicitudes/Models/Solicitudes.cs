using ApiSolicitudes.ModelsDTO;
using System.ComponentModel.DataAnnotations;

namespace ApiSolicitudes.Models
{
    public class Solicitudes
    {
        [Key]
        public int SolicitudId { get; set; }

        public string UsuarioId { get; set; } = null!;
        public string? TipoSolicitud { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
        public string? Estado { get; set; }
    }
}
