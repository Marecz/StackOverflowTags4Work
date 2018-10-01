using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
using StackOverflowTags.Models;

namespace StackOverflowTags.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StackOverflowTags()
        {

            ViewBag.Message = "1000 StackOverflowTags.";
            var model = APIStackOverFlow();
            return View(model);
        }

        public static RootObject APIStackOverFlow()
        {
            using (WebClient wc = new WebClient())
            {
                var client = new WebClient();
                var response = client.DownloadString("https://api.stackexchange.com/2.2/tags?pagesize=5&order=desc&sort=popular&site=stackoverflow"); ;

                RootObject m = JsonConvert.DeserializeObject<RootObject>(response);

                return m;
            }

        }
    }
}