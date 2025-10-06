using ApiUsuarios.Custom.Security;
using ApiUsuarios.Interface.IRepository;
using ApiUsuarios.Interface.IService;
using ApiUsuarios.Models;
using ApiUsuarios.ModelsDTO;

namespace ApiUsuarios.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly ILogger<UserService> _logger;
        private readonly ITokenService _token;
        private readonly IHasherService _hasher;

        public UserService(IUserRepository repo, ILogger<UserService> logger, ITokenService tokenService, IHasherService hasher)
        {
            _repo = repo;
            _logger = logger;
            _token = tokenService;
            _hasher=hasher;
        }

        public async Task<Usuarios> GetUserById(string id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<SessionDTO> LoginUser(LoginDTO logDTO)
        {
            try
            {
                var user = await _repo.GetUserByEmail(logDTO.Email);
                if (user == null)
                {
                    _logger.LogInformation("No existe el usuario con ese correo registrado");
                    return null;

                }

                var passwordHash = _hasher.GenerateHasherPassword(logDTO.Password);

                if (passwordHash != user.Contrasena)
                {
                    _logger.LogInformation("Contraseña incorrecta");
                    return null;
                }

                return new SessionDTO
                {
                    UserId = user.UsuarioId,
                    Token = _token.GenerateJWT(user)
                };

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex} ha ocurrido un error inesperado");
                throw new InvalidOperationException($"{ex} ha ocurrido un error inesperado");
            }

        }

        public async Task<Usuarios> RegisterUser(UsuarioDTO user)
        {
            var usr = new Usuarios
            {
                UsuarioId = user.UsuarioId,
                Nombre = user.Nombre,
                Correo = user.Correo,
                Contrasena = _hasher.GenerateHasherPassword(user.Contraseña),
                FechaRegistro = DateTime.UtcNow,
                Estado = true,
                Rol = user.Rol

            };

            var userCreated = await _repo.AddNewUser(usr);
            await _repo.SaveChangesAsync();

            if(userCreated == null)
            {
                return null;
            }

            return userCreated;
        }
    }
}
