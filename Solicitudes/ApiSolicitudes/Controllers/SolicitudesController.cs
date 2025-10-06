using ApiSolicitudes.Interface.IService;
using ApiSolicitudes.Models;
using ApiSolicitudes.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSolicitudes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public SolicitudesController(IRequestService service)
        {
            _requestService = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("NuevaSolicitud")]
        public async Task<ActionResult<Solicitudes>> NewRequestInSystem([FromBody] SolicitudDTO requestDTO)
        {
            var userId = GetUserByAuthentication();

            var requestCreated = await _requestService.NewRequest(requestDTO, userId);
            if (requestCreated == null)
            {
                return BadRequest("No hemos logrado crear la solicitud");
            }

            return requestCreated;

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("ObtenerSolicitudesPorUsuarioId/{userId}")]
        public async Task<ActionResult<IEnumerable<RequestWithUser>>> GetRequestByUserId(string userId)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var userRequestList = await _requestService.GetRequestByUserId(userId, token);
            if (userRequestList == null || !userRequestList.Any())
            {
                return NotFound("No hay solicitudes que hayan sido realizadas por ese usuario");
            }

            return Ok(userRequestList);
        }



        private string GetUserByAuthentication()
        {
            return User.FindFirst("userId")!.Value.ToString();
        }
    }
}
