using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult PatientList()
        {
            return View();
        }

        public IActionResult PatientAddEdit()
        {
            return View();
        }
        public IActionResult PatientDetail()
        {
            return View();
        }
    }
}
