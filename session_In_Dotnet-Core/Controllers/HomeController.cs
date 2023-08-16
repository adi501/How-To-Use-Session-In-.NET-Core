using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using session_In_Dotnet_Core.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace session_In_Dotnet_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // set session as string
            HttpContext.Session.SetString("LoginUser", "Adi");  
            // set session as int
            HttpContext.Session.SetInt32("LoginUserId", 101);

            //Set Object as JSON from Session
            // some object
            
            object value = new object();
            // set object value in session
            HttpContext.Session.SetString("Key_Name", JsonConvert.SerializeObject(value));

            return View();
        }

        public IActionResult Privacy()
        {
            // get string session
            var loginUser = HttpContext.Session.GetString("LoginUser");
            //get int session
            var loginUserId = HttpContext.Session.GetInt32("LoginUserId");

            //Get Object as JSON from Session
            // get object value in session
            object value = new object();
            var sesionValue = HttpContext.Session.GetString("Key_Name");
            var sessionObj = value == null ? default(T) : JsonConvert.DeserializeObject<T>(sesionValue);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}