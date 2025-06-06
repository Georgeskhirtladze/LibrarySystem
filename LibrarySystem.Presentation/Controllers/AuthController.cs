using LibrarySystem.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string username, string password, string role = "user")
    {
        var success = await _authService.RegisterAsync(username, password, role);
        if (!success)
            return BadRequest("Username already taken");

        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        var token = await _authService.LoginAsync(username, password);
        if (token == null)
            return Unauthorized("Invalid credentials");

        return Ok(new { token });
    }
}
