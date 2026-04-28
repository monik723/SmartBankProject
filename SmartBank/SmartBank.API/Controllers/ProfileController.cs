using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Core.DTOs.Profile;
using SmartBank.Core.Interfaces;
using System.Security.Claims;

namespace SmartBank.API.Controllers;

[ApiController]
[Route("api/profile")]
[Authorize]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profile;
    public ProfileController(IProfileService profile) => _profile = profile;

    private int GetUserId() =>
        int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        var result = await _profile.GetProfileAsync(GetUserId());
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _profile.UpdateProfileAsync(GetUserId(), dto);
        if (!result) return NotFound();
        return Ok(new { message = "Profile updated successfully." });
    }
}
