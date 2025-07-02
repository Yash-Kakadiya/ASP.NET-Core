using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class DoctorDepartmentController : Controller
    {
        public IActionResult DoctorDepartmentList()
        {
            return View();
        }

        public IActionResult DoctorDepartmentAddEdit()
        {
            return View();
        }
        public IActionResult DoctorDepartmentDetail()
        {
            return View();
        }

    }
}
