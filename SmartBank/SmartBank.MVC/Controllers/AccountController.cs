using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Core.DTOs.Account;

namespace SmartBank.MVC.Controllers;

public class AccountController : Controller
{
    private readonly IHttpClientFactory _factory;

    public AccountController(IHttpClientFactory factory) => _factory = factory;

    private HttpClient GetClient()
    {
        var client = _factory.CreateClient("API");
        var token = HttpContext.Session.GetString("Token");
        if (token != null)
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                token
            );
        return client;
    }

    public async Task<IActionResult> Index()
    {
        if (HttpContext.Session.GetString("Token") == null)
            return RedirectToAction("Login", "Auth");

        var client = GetClient();
        var response = await client.GetAsync("api/accounts");
        var accounts = await response.Content.ReadFromJsonAsync<List<AccountDto>>();
        return View(accounts);
    }

    [HttpGet]
    public IActionResult Open()
    {
        if (HttpContext.Session.GetString("Token") == null)
            return RedirectToAction("Login", "Auth");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Open(CreateAccountDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var client = GetClient();
        var response = await client.PostAsJsonAsync("api/accounts/create", dto);

        if (response.IsSuccessStatusCode)
        {
            TempData["Success"] = "Account opened successfully!";
            return RedirectToAction("Index");
        }

        ViewBag.Error = "Failed to open account.";
        return View(dto);
    }
}
