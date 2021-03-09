using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineeringProject.Models;

namespace SoftwareEngineeringProject.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel loginDetails)
        {
            User user = null;

            var db = new software_engineering_projectContext();
            user = db.User.FirstOrDefault(x => x.UserName.ToLower() == loginDetails.UserName.ToLower());


            if (user != null)
            {
                if (user.IsLocked == 1)
                {
                    ViewBag.Error = "Your account is locked!";
                }
                else
                {
                    if (user.Password == loginDetails.Password)
                    {
                        user.FailedAttempts = 0;
                        db.SaveChanges();

                        HttpContext.Session.SetString("User", JsonSerializer.Serialize(user));

                        return RedirectToActionPermanent("Index", "Books");
                    }
                    else
                    {
                        user.FailedAttempts += 1;
                        db.SaveChanges();

                    }

                    if (user.FailedAttempts == 3)
                    {
                        user.IsLocked = 1;
                        db.SaveChanges();

                        ViewBag.Error = "You have exceeded maximum login attempts. Your account is blocked";
                    }
                    else
                    {
                        ViewBag.Error = "Invalid User Name or Password";
                    }
                   
                }
                return View();

            }

            ViewBag.Error = "Invalid User Name or Password";

            return View();


        }
    }
}
