using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class HealthcareController : Controller
    {
        UserService userService;
        BloodGroupInventoryService bloodGroupInventoryService;
        DonationService donationService;
        RequestService requestService;

        public HealthcareController(UserService userService, BloodGroupInventoryService bloodGroupInventoryService, DonationService donationService, RequestService requestService)
        {
            this.userService = userService;
            this.bloodGroupInventoryService = bloodGroupInventoryService;
            this.donationService = donationService;
            this.requestService = requestService;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ViewProfile(int id)
        {
            var sessionId = HttpContext.Session.GetInt32("UserId");
            if (sessionId == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (sessionId != id)
            {
                return Unauthorized();
            }

            var data = userService.Get(id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
    }
}
