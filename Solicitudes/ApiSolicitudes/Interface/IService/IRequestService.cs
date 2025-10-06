using ApiSolicitudes.Models;
using ApiSolicitudes.ModelsDTO;

namespace ApiSolicitudes.Interface.IService
{
    public interface IRequestService
    {
        Task<Solicitudes> NewRequest(SolicitudDTO request, string userId);
        Task<List<RequestWithUser>> GetRequestByUserId(string userId, string token);

    }
}
