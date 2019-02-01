namespace Auth
{
    public interface ITokenGenerator
    {
        string GetToken(string email, string password = null);
    }
}