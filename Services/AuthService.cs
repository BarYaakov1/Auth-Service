public class AuthService
{
    private readonly InMemoryUserStore _userStore;
    private readonly ILogger<AuthService> _logger;

    public AuthService(InMemoryUserStore userStore, ILogger<AuthService> logger)
    {
        _userStore = userStore;
        _logger = logger;
    }

    public bool Login(string username, string password)
    {
        if (_userStore.ValidateCredentials(username, password))
        {
            _userStore.SetLoginStatus(username, true);
            _logger.LogInformation($"User {username} logged in.");
            return true;
        }
        return false;
    }

    public bool Logout(string username)
    {
        var user = _userStore.GetUser(username);
        if (user != null && user.IsLoggedIn)
        {
            _userStore.SetLoginStatus(username, false);
            _logger.LogInformation($"User {username} logged out.");
            return true;
        }
        return false;
    }

    public bool IsAuthenticated(string username)
    {
        var user = _userStore.GetUser(username);
        return user?.IsLoggedIn ?? false;
    }
}