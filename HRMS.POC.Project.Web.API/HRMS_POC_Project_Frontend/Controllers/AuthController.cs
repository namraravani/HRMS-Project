﻿using HRMS_POC_Project_Frontend.Models;
using HRMS_POC_Project_Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_POC_Project_Frontend.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO loginDto)
        {
            if (ModelState.IsValid)
            {
                var token = await _userService.LoginAsync(loginDto);
                if (!string.IsNullOrEmpty(token))
                {
                    Console.WriteLine("Hello I am Here I am About to send the token ");
                    Console.WriteLine(token);
                    HttpContext.Response.Cookies.Append("AuthToken", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None,
                        Path = "/"
                    });

                   
                    

                    return RedirectToAction("Index", "Organization");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View("Login", loginDto);
        }

    }
}
