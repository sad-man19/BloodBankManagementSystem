using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class HealthcareController : Controller
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
