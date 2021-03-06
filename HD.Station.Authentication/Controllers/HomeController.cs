﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HD.Station.Authentication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Secret()
        {
            return View();  
        }

        // claim base
        [Authorize(Policy = "Claim.Dob")]
        public IActionResult SecretPolicy()
        {
            return View("Secret");
        }
        // role base
        [Authorize(Roles  = "Admin")]
        public IActionResult SecretRole()
        {
            return View(); 
        }
        public IActionResult Authenticate()
        {
            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , "Bob"),
                new Claim (ClaimTypes.Email , "bob@gmail.com"),
                new Claim (ClaimTypes.DateOfBirth , "12/02/2020"),
                new Claim (ClaimTypes.Role , "Admin"),

                new Claim("Granma","Very nice boi")
            };
            var licenciClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob k foo"),
                new Claim("DrivingLicense","A+")
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
            var licenseIdentity = new ClaimsIdentity(licenciClaims, "Government");
            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentity });
            HttpContext.SignInAsync(userPrincipal);
            return RedirectToAction("Index");
        }
    }
    
}
