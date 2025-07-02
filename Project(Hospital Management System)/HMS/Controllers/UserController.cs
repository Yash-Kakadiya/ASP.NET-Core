using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserList()
        {
            return View();
        }

        public IActionResult UserAddEdit()
        {
            return View();
        }
        public IActionResult UserDetail()
        {
            return View();
        }
    }
}
