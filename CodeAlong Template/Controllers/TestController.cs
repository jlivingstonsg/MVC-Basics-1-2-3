using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAlong_Template.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomTest()
        {
            return View(); 
        }
    }
}
