namespace ApiSolicitudes.ModelsDTO
{
    public class RequestWithUser
    {
        // Propiedades de la Solicitud
        public int SolicitudId { get; set; }
        public string UsuarioId { get; set; } = null!;
        public string? TipoSolicitud { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
        public string? Estado { get; set; }

        // Propiedades del Usuario (traídas del UserDTO)
        public string? NombreUsuario { get; set; }
        public string? CorreoUsuario { get; set; }
        public string? RolUsuario { get; set; }
    }
}
