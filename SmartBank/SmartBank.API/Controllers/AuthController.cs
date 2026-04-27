using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Core.DTOs.Auth;
using SmartBank.Core.Interfaces;

namespace SmartBank.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;

    public AuthController(IAuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _auth.RegisterAsync(dto);

        if (result == null)
            return BadRequest(new { message = "Email already registered." });

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _auth.LoginAsync(dto);

        if (result == null)
            return Unauthorized(new { message = "Invalid email or password." });

        return Ok(result);
    }

    [HttpGet("test-protected")]
    [Authorize]
    public IActionResult TestProtected()
    {
        var name = User.Identity?.Name;
        var role = User.Claims.FirstOrDefault(c => c.Type.Contains("role"))?.Value;
        return Ok(new { message = $"JWT works! Welcome {name}, Role: {role}" });
    }
}
