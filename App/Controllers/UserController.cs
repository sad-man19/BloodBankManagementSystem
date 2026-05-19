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
            ModelState.Remove("NewPassword");
            ModelState.Remove("ConfirmNewPassword");

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

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(UserDTO u)
        {
            var UserId = HttpContext.Session.GetInt32("UserId").Value;
            ModelState.Remove("Name");
            ModelState.Remove("Email");
            ModelState.Remove("Phone");
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("BloodGroupId");
            ModelState.Remove("BloodGroup");
            ModelState.Remove("Role");
            ModelState.Remove("LastDonationDate");
            ModelState.Remove("Dob");
            if (!ModelState.IsValid)
            {
                return View(u);
            }
            var res = userService.ChangePass(u);
            if (res == true)
            {
                TempData["PassChange"] = "Password changed successfully.";
                return RedirectToAction("ViewProfile", new { id = HttpContext.Session.GetInt32("UserId") });

            }
            else
            {
                TempData["ErrorMessage"] = "Failed to change password. Please try again.";
                return View(u);
            }
        }

        [HttpGet]
        public IActionResult DeleteUser()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var user = userService.Get(userId.Value);

            return View(user);
        }
        [HttpPost]
        public IActionResult DeleteUser(int id, string Decision)
        {
            if (Decision.Equals("Yes"))
            {
                userService.Delete(id);
                TempData["DeleteMessage"] = "Account deleted successfully.";
                return RedirectToAction("Login", "Home");
            }
            return RedirectToAction("ViewProfile", new { id = HttpContext.Session.GetInt32("UserId") });
        }

        [HttpGet]
        public IActionResult RecordDonation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RecordDonation(DonationDTO d)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var user = userService.Get(userId.Value);
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            d.UserId = userId.Value;
            d.BloodGroupId = user.BloodGroupId;

            var res = donationService.CreateDonation(d);
            if (res == true)
            {
                TempData["DonationMessage"] = "Donation recorded successfully.";
                return RedirectToAction("Dashboard");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to record donation. Please try again.";
                return View(d);
            }

            //return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {

            var userId = HttpContext.Session.GetInt32("UserId");
            var user = userService.Get(userId.Value);
            ViewBag.UserName = user.Name;
            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (userId == null)
            {
                return Unauthorized();
            }
            var res = donationService.Get(userId.Value);
            return View(res);
        }

        [HttpGet]
        public IActionResult Request()
        {
            ViewBag.BloodGroupInventories = bloodGroupInventoryService.Get();
            return View();
        }
        [HttpPost]
        public IActionResult Request(RequestDTO r)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var user = userService.Get(userId.Value);
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ModelState.Remove("UserId");
            ModelState.Remove("ReqDate");
            ModelState.Remove("Status");
            ModelState.Remove("Email");

            r.UserId = userId.Value;
            r.ReqDate = DateOnly.FromDateTime(DateTime.Now);
            r.Status = "Pending";


            var res = requestService.CreateRequest(r);
            if (res == true)
            {
                TempData["RequestMessage"] = "Request submitted successfully.";
                return RedirectToAction("Dashboard");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to submit request. Please try again.";
                ViewBag.BloodGroupInventories = bloodGroupInventoryService.Get();
                return View(r);
            }
        }
    }
}
