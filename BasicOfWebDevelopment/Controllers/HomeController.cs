using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicOfWebDevelopment.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs("GET", "POST", "PUT", "DELETE")]
        public string DoSomething()
        {
            if(FileWriter.getInstance().WriteInformation(HttpContext.Request.UserHostAddress, HttpContext.Request.HttpMethod, HttpContext.Request.Url.AbsolutePath))
            {
                return HttpContext.Request.HttpMethod;
            }
            else
                return "Error";
        }
    }
}