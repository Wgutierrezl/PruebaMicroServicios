using ApiUsuarios.Interface.IService;
using ApiUsuarios.Models;
using ApiUsuarios.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserService _service;

        public UsuarioController(IUserService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("Logearse")]
        public async Task<ActionResult<SessionDTO>> Login([FromBody] LoginDTO loginDTO)
        {
            var session = await _service.LoginUser(loginDTO);
            if (session == null)
            {
                return BadRequest("Correo o contraseña incorrectas");
            }

            return Ok(session);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("ObtenerUsuarioPorId/{id}")]
        public async Task<ActionResult<Usuarios>> GetProfileByUserId(string id)
        {
            var user = await _service.GetUserById(id);
            if (user == null)
            {
                return NotFound("No hemos logrado encontrar al usuario que buscas");
            }

            return user;
        }

        [AllowAnonymous]
        [HttpPost("RegistrarUsuario")]
        public async Task<ActionResult<Usuarios>> RegisterUser([FromBody] UsuarioDTO userDTO)
        {
            var userCreated = await _service.RegisterUser(userDTO);
            if(userCreated == null)
            {
                return BadRequest("No hemos logrado crear al usuario dentro del sistema");
            }

            return userCreated;
        }
    }
}
