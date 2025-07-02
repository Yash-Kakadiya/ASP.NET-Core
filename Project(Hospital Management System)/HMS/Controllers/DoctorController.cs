using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult DoctorList()
        {
            return View();
        }

        public IActionResult DoctorAddEdit()
        {
            return View();
        }
        public IActionResult DoctorDetail()
        {
            return View();
        }

    }
}
