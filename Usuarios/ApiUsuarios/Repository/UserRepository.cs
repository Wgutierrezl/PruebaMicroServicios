using ApiUsuarios.Data;
using ApiUsuarios.Interface.IRepository;
using ApiUsuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Usuarios> AddNewUser(Usuarios usuarios)
        {
            await _context.Usuarios.AddAsync(usuarios);
            return usuarios;
        }

        public async Task<Usuarios> GetUserByEmail(string email)
        {
            return await _context.Usuarios.Where(e => e.Correo.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<Usuarios> GetUserById(string userId)
        {
            return await _context.Usuarios.FindAsync(userId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
