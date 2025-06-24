using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (_authService.Login(request.Username, request.Password))
            return Ok($"{request.Username} logged in");
        return Unauthorized();
    }

    [HttpPost("logout")]
    public IActionResult Logout([FromBody] LogoutRequest request)
    {
        if (_authService.Logout(request.Username))
            return Ok($"{request.Username} Logged out");
        return BadRequest($"{request.Username} was not logged in");
    }

    [HttpGet("validate/{username}")]
    public IActionResult Validate(string username)
    {
        if (_authService.IsAuthenticated(username))
            return Ok();
        return Unauthorized();
    }
}

