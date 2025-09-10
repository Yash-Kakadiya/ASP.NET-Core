using Demo.Helpers;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Demo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserAddEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserAddEdit(UserModel um)
        {
            ViewBag.UserID = um.UserID;
            ViewBag.UserName = um.UserName;
            string filePath = "";
            try
            {
                filePath = ImageHelper.SaveImage(imageFile: um.Image, dir: "Profile");
            }
            catch (System.Exception)
            {
                Console.WriteLine("file not provided mostly");
            }
            ViewBag.ImagePath = filePath;
            ViewBag.Password = um.Password;
            ViewBag.Age = um.Age;
            ViewBag.Email = um.Email;
            ViewBag.Gender = um.Gender;
            ViewBag.Hobbies = um.Hobbies;
            ViewBag.PhoneNo = um.PhoneNo;


            return View();
        }

        //[HttpPost]
        //public IActionResult UserAddEdit(int id, string name, string email, string password)
        //{
        //    ViewBag.Id = id;
        //    ViewBag.Name = name;
        //    ViewBag.Email = email;
        //    ViewBag.Password = password;

        //    return View();
        //}


        //[HttpPost]
        //public IActionResult UserAddEdit(IFormCollection fc)
        //{
        //    ViewBag.Id = fc["id"];
        //    ViewBag.Name = fc["name"];
        //    ViewBag.Email = fc["email"];
        //    ViewBag.Password = fc["password"];

        //    return View();
        //}
    }
}
