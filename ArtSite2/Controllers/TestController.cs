using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ArtSite2.Controllers
{
    public class TestController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        
        public string Index() => "Hello MVC";

       
        public string Index2() => "Hello Tester2";

        public string Index3() => "Hello Tester3";
    }

    public class Test2Controller : Controller
    {
        public IActionResult Index()
        {
            return View(); 

            //return Content("Some test string");
        }

        public IActionResult Index2()
        {
            return Content("Some test string");
        }
    }
}