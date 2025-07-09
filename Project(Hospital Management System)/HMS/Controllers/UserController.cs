using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
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
