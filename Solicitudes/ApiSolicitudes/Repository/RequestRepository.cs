using ApiSolicitudes.Data;
using ApiSolicitudes.Interface.IRepository;
using ApiSolicitudes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSolicitudes.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext _context;

        public RequestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Solicitudes>> GetAllRequestByUserId(string userId)
        {
            return await _context.Solicitudes
                .Where(e => e.UsuarioId.ToLower() == userId.ToLower())
                .ToListAsync();
        }

        public async Task<Solicitudes> NewRequest(Solicitudes solicitudes)
        {
            await _context.Solicitudes.AddAsync(solicitudes);
            return solicitudes;

        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
