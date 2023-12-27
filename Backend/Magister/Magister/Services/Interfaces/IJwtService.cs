namespace Magister.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string email, Guid userId, string userName, IList<string> roles);
    }
}
