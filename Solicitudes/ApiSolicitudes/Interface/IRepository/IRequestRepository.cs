using ApiSolicitudes.Models;

namespace ApiSolicitudes.Interface.IRepository
{
    public interface IRequestRepository
    {
        Task<Solicitudes> NewRequest(Solicitudes solicitudes);
        Task<List<Solicitudes>> GetAllRequestByUserId(string userId);
        Task SaveChangeAsync();
    }
}
