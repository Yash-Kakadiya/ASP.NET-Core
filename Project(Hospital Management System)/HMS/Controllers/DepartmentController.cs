using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult DepartmentList()
        {
            return View();
        }

        public IActionResult DepartmentAddEdit()
        {
            return View();
        }
        public IActionResult DepartmentDetail()
        {
            return View();
        }
    }
}
