using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineeringProject.Models;

namespace SoftwareEngineeringProject.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Registration register)
        {
            //return error

            string error = string.Empty;


            if (!ModelState.IsValid)
            {
                return View();
            }
            
            bool containtsUpper =register.Password.Any(x=>Char.IsLetter(x) && Char.IsUpper(x));
            bool containtsLower = register.Password.Any(x => Char.IsLetter(x) && Char.IsLower(x));
            bool containtsSpecial = register.Password.Any(x => Char.IsPunctuation(x) || char.IsSymbol(x));

            if (containtsLower && containtsUpper && containtsSpecial)
            {
                // Save to database
                using (var db = new software_engineering_projectContext())
                {
                    db.User.Add(new User()
                    {
                        FirstName = register.FirstName,
                        LastName = register.LastName,
                        Email = register.Email,
                        Address = register.Address,
                        Password = register.Password,
                        Phone = register.Phone,
                        UserName = register.UserName
                    });

                    db.SaveChanges();
                }

                    // Return a message
                ViewBag.Message = "Account Created";
                return RedirectToAction("Index", "Home");
            }

            if (!containtsLower)
            {
                error = error + " Password must contain a lower case letter ";
            }

            if (!containtsUpper)
            {
                error = error + " Password must contain a upper case letter ";
            }

            if (!containtsSpecial)
            {
                error = error + " Password must contain a special character ";
            }

            ViewBag.Error = error;
            return View();

        }
        
    }
}
