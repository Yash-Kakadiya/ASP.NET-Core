using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class AppointmentController : Controller
    {

        public IActionResult AppointmentList()
        {
            return View();
        }

        public IActionResult AppointmentAddEdit()
        {
            return View();
        }
        public IActionResult AppointmentDetail()
        {
            return View();
        }
    }
}
