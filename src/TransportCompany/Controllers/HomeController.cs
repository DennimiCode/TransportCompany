using Microsoft.AspNetCore.Mvc;

namespace TransportCompany.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult CreateOrder() => View();
    public IActionResult Privacy() => View();
}
