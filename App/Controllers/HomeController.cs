using App.Models;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        UserService userService;
        BloodGroupInventoryService bloodGroupInventoryService;

        public HomeController(UserService userService, BloodGroupInventoryService bloodGroupInventoryService)
        {
            this.userService = userService;
            this.bloodGroupInventoryService = bloodGroupInventoryService;
        }

        ////////////// Registration /////////////
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.BloodGroupInventories = bloodGroupInventoryService.Get();
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserDTO u)
        {
            if (ModelState.IsValid)
            {
                if (userService.EmailExists(u.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists.");
                }
                if (userService.PhoneExists(u.Phone))
                {
                    ModelState.AddModelError("Phone", "Phone number already exists.");
                }
                if(!ModelState.IsValid)
                {
                    ViewBag.BloodGroupInventories = bloodGroupInventoryService.Get();
                    return View(u);
                }

                userService.Create(u);

                TempData["Success"] = "Registration successful! Please log in.";
                return RedirectToAction("Login");
            }

            //foreach (var item in ModelState)
            //{
            //    foreach (var error in item.Value.Errors)
            //    {
            //        Console.WriteLine(item.Key + " : " + error.ErrorMessage);
            //    }
            //}


            ViewBag.BloodGroupInventories = bloodGroupInventoryService.Get();
            return View(u);
        }


        ////////////// Login /////////////
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {

            return View();
        }





        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
