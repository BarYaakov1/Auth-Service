
public interface IAuthService
{
    string Login(string username, string password);
    bool Logout(string token);
    bool IsTokenValid(string token, out string username);
}