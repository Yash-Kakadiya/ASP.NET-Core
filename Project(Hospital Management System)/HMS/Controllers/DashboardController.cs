using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
