namespace Magister.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string email, Guid userId, IList<string> roles);
    }
}
