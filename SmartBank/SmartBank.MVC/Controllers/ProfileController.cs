using Microsoft.AspNetCore.Mvc;
using SmartBank.Core.DTOs.Profile;
using System.Net.Http.Headers;

namespace SmartBank.MVC.Controllers;

public class ProfileController : Controller
{
    private readonly IHttpClientFactory _factory;
    public ProfileController(IHttpClientFactory factory) => _factory = factory;

    private HttpClient GetClient()
    {
        var client = _factory.CreateClient("API");
        var token = HttpContext.Session.GetString("Token");
        if (token != null)
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        return client;
    }

    public async Task<IActionResult> Index()
    {
        if (HttpContext.Session.GetString("Token") == null)
            return RedirectToAction("Login", "Auth");

        var client = GetClient();
        var response = await client.GetAsync("api/profile");
        if (!response.IsSuccessStatusCode)
            return RedirectToAction("Login", "Auth");

        var profile = await response.Content.ReadFromJsonAsync<ProfileDto>();
        return View(profile);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateProfileDto dto)
    {
        if (!ModelState.IsValid) return View("Index");

        var client = GetClient();
        var response = await client.PutAsJsonAsync("api/profile", dto);

        if (response.IsSuccessStatusCode)
            TempData["Success"] = "Profile updated successfully!";
        else
            TempData["Error"] = "Failed to update profile.";

        return RedirectToAction("Index");
    }
}
