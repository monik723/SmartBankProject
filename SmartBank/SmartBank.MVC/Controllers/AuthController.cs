using Microsoft.AspNetCore.Mvc;
using SmartBank.Core.DTOs.Auth;

namespace SmartBank.MVC.Controllers;

public class AuthController : Controller
{
    private readonly IHttpClientFactory _factory;

    public AuthController(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (HttpContext.Session.GetString("Token") != null)
            return RedirectToAction("Index", "Dashboard");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        var client = _factory.CreateClient("API");
        var response = await client.PostAsJsonAsync("api/auth/login", dto);

        if (!response.IsSuccessStatusCode)
        {
            ViewBag.Error = "Invalid email or password.";
            return View(dto);
        }

        var result = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
        HttpContext.Session.SetString("Token", result!.Token);
        HttpContext.Session.SetString("UserName", result.FullName);
        HttpContext.Session.SetString("Role", result.Role);
        HttpContext.Session.SetString("Email", result.Email);

        return RedirectToAction("Index", "Dashboard");
    }

    [HttpGet]
    public IActionResult Register()
    {
        if (HttpContext.Session.GetString("Token") != null)
            return RedirectToAction("Index", "Dashboard");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        var client = _factory.CreateClient("API");
        var response = await client.PostAsJsonAsync("api/auth/register", dto);

        if (!response.IsSuccessStatusCode)
        {
            ViewBag.Error = "Email already registered. Please use a different email.";
            return View(dto);
        }

        TempData["Success"] = "Account created successfully! Please login.";
        return RedirectToAction("Login");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
