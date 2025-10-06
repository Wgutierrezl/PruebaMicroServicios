using ApiUsuarios.Models;

namespace ApiUsuarios.Custom.Security
{
    public interface ITokenService
    {
        string GenerateJWT(Usuarios user);
    }
}
