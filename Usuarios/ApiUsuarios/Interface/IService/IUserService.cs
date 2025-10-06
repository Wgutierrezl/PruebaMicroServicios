using ApiUsuarios.Models;
using ApiUsuarios.ModelsDTO;

namespace ApiUsuarios.Interface.IService
{
    public interface IUserService
    {
        Task<Usuarios> RegisterUser(UsuarioDTO user);
        Task<SessionDTO> LoginUser(LoginDTO logDTO);
        Task<Usuarios> GetUserById(string id);
    }
}
