using CodeAlong_Template.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAlong_Template.Controllers
{
    public class PlayGameController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PlayGameController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: PlayGameController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // custome route
        [Route("guessingGame")]
        public ActionResult Create()
        {
            // generate random number from 1 to  100
            Random rand = new Random();
            string randomNumber = rand.Next(1, 100).ToString();

            // set some session 
            HttpContext.Session.SetString("number", randomNumber);
            HttpContext.Session.SetString("near", "");
            HttpContext.Session.SetString("checkMatch", "");


            // set some cookies 
            string key = "attemps";
            string value = "0";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append(key, value, cookieOptions);

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("guessingGame")]
        public ActionResult Create(Game model)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);

            if (model.Number == int.Parse(HttpContext.Session.GetString("number")))
            {
                Response.Cookies.Delete("attemps");
                Response.Cookies.Append("attemps", "0", cookieOptions);

                HttpContext.Session.SetString("near", "");
                HttpContext.Session.SetString("checkMatch", "Congratulations ! you win ... please try again");

                // if result success than  again number generate 1 to 100 
                Random rand = new Random();
                string randomNumber = rand.Next(1, 100).ToString();
                HttpContext.Session.SetString("number", randomNumber);

            }
            else
            {
                int c = int.Parse(_httpContextAccessor.HttpContext.Request.Cookies["attemps"]) + 1;
                Response.Cookies.Delete("attemps");

                Response.Cookies.Append("attemps", c.ToString(), cookieOptions);

                int v = 0;
                string msg = "";
                if (model.Number > int.Parse(HttpContext.Session.GetString("number")))
                {
                    v = model.Number - int.Parse(HttpContext.Session.GetString("number"));
                    msg = v.ToString() + "" + " Number is to high.";
                    HttpContext.Session.SetString("checkMatch", "");
                }
                else
                {
                    v = int.Parse(HttpContext.Session.GetString("number")) - model.Number;
                    msg = v.ToString() + "" + " Number is to low.";
                    HttpContext.Session.SetString("checkMatch", "");
                }
                HttpContext.Session.SetString("near", msg);

            }


            return View();
        }


    }
}