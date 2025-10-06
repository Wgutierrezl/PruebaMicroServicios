using ApiUsuarios.Models;

namespace ApiUsuarios.Interface.IRepository
{
    public interface IUserRepository
    {
        Task<Usuarios> AddNewUser(Usuarios usuarios);
        Task<Usuarios> GetUserByEmail(string email);
        Task<Usuarios> GetUserById(string userId);
        Task SaveChangesAsync();
    }
}
