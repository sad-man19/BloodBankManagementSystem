using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult ViewProfile()
        {
            return View();
        }
    }
}
