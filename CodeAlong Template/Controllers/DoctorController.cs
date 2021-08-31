using CodeAlong_Template.Models;
using fever.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAlong_Template.Controllers
{
    public class DoctorController : Controller
    {
        [Route("/FeverCheck")]
        [HttpGet]
        public ActionResult FeverCheck()
        {
            
            ViewData["Fever"] = "";
            ViewData["shypothermia"] = "";
            return View();
        }

        public ActionResult RedirectToFeverChecker()
        {
            return RedirectToAction("FeverCheck");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/FeverCheck")]
        public ActionResult FeverCheck(Fever model)
        {
            if (!FeverStatic.IsValid(model.CheckFever))
            {
                ViewData["Message"] = "Please enter temperature level";
                return View();
            }
            if (model.Unit == "Fahrenheit")
            {
                if (model.CheckFever >= 99)
                {
                    ViewData["Message"] = "You have fever ";
                }
                else
                {
                    ViewData["Message"] = "You have not  fever ";
                    if ((model.CheckFever <= 95))
                    {
                        ViewData["shypothermia"] = "but hypothermia";
                    }
                    else
                    {
                        ViewData["shypothermia"] = "";

                    }
                }
            }
            else
            {
                if (model.CheckFever >= 38)
                {
                    ViewData["Message"] = "You have fever ";
                }
                else
                {
                    ViewData["Message"] = "You have not  fever ";
                    if ((model.CheckFever <= 35))
                    {
                        ViewData["shypothermia"] = "but hypothermia";
                    }
                    else
                    {
                        ViewData["shypothermia"] = "";
                    }

                }

            }
            return View();
        }
    }
}
