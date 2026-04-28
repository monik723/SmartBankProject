using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Core.DTOs.Account;
using SmartBank.Core.Interfaces;
using System.Security.Claims;

namespace SmartBank.API.Controllers;

[ApiController]
[Route("api/accounts")]
[Authorize]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accounts;
    public AccountsController(IAccountService accounts) => _accounts = accounts;

    private int GetUserId() =>
        int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpPost("create")]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _accounts.CreateAccountAsync(GetUserId(), dto);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAccounts()
    {
        var result = await _accounts.GetAccountsAsync(GetUserId());
        return Ok(result);
    }
}
