using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class UserController : Controller
    {
        UserService userService;
        BloodGroupInventoryService bloodGroupInventoryService;
        DonationService donationService;
        RequestService requestService;

        public UserController(UserService userService, BloodGroupInventoryService bloodGroupInventoryService, DonationService donationService, RequestService requestService)
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
        [HttpGet]
        public IActionResult EditUserProfile(int id)
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
        [HttpPost]
        public IActionResult EditUserProfile(UserDTO u)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Password");
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("BloodGroupId");
            ModelState.Remove("BloodGroup");
            ModelState.Remove("Role");
            ModelState.Remove("LastDonationDate");
            ModelState.Remove("Dob");
            
            if (ModelState.IsValid)
            {
                var res = userService.Update(u);
                if (res == true)
                {
                    TempData["SuccessMessage"] = "Profile updated successfully.";
                    return RedirectToAction("ViewProfile", new { id = HttpContext.Session.GetInt32("UserId") });

                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to update profile. Please try again.";
                    var freshData = userService.Get(u.Id);
                    return View(freshData);
                }
            }
            return View(u);

        }
    }
}
