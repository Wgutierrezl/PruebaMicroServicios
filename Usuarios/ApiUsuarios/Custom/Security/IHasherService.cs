namespace ApiUsuarios.Custom.Security
{
    public interface IHasherService
    {
        string GenerateHasherPassword(string password);
    }
}
