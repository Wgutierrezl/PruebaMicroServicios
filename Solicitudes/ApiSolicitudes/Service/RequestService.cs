using ApiSolicitudes.Interface.IRepository;
using ApiSolicitudes.Interface.IService;
using ApiSolicitudes.Models;
using ApiSolicitudes.ModelsDTO;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ApiSolicitudes.Service
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repo;
        private readonly HttpClient _httpClient;
        public RequestService(IRequestRepository repo, IHttpClientFactory httpClient)
        {
            _repo = repo;
            _httpClient = httpClient.CreateClient("UsuariosApi");
        }

        public async Task<List<RequestWithUser>> GetRequestByUserId(string userId, string token)
        {

            var userRequest = await _repo.GetAllRequestByUserId(userId);
            if (userRequest == null)
            {
                return new List<RequestWithUser>();
            }


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/Usuario/ObtenerUsuarioPorId/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("No se puedo obtener la informacion del usuario");
            }

            var content = await response.Content.ReadAsStringAsync();

            var user = JsonSerializer.Deserialize<UserDTO>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var result = userRequest.Select(s => new RequestWithUser
            {
                SolicitudId = s.SolicitudId,
                UsuarioId = s.UsuarioId,
                TipoSolicitud = s.TipoSolicitud,
                Descripcion = s.Descripcion,
                FechaSolicitud = s.FechaSolicitud,
                Estado = s.Estado,
                NombreUsuario = user.Nombre,
                CorreoUsuario = user.Correo,
                RolUsuario = user.Rol

            }).ToList();

            return result;
        }

        public async Task<Solicitudes> NewRequest(SolicitudDTO request, string userId)
        {
            var requestdb = new Solicitudes
            {
                UsuarioId = userId,
                TipoSolicitud = request.TipoSolicitud,
                Descripcion = request.Descripcion,
                Estado = "Pendiente",
                FechaSolicitud = DateTime.UtcNow

            };

            var requestCreated = await _repo.NewRequest(requestdb);
            await _repo.SaveChangeAsync();

            if (requestCreated == null)
            {
                return null;
            }

            return requestCreated;
        }
    }
}
