using Microsoft.AspNetCore.Mvc;

namespace SmartBank.MVC.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("Token") == null)
            return RedirectToAction("Login", "Auth");

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        ViewBag.Role = HttpContext.Session.GetString("Role");
        ViewBag.Email = HttpContext.Session.GetString("Email");

        return View();
    }
}
