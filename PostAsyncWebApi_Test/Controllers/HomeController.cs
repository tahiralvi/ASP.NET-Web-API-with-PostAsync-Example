using PostAsyncWebApi_Test.Models;
using System.Web.Mvc;

namespace PostAsyncWebApi_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PatOBInfo jobject = new PatOBInfo
            {
                acokey = 1,
                practiceid = 1,
                userid = "1",
                searchtext = "",
                option = 1,
                viewall = 1
            };

            ViewData["list"] = PostDataModel.PostAsyncWebApi_Test(jobject);
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
    }
}