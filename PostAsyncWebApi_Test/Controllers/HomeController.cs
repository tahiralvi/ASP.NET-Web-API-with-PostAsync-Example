using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PostAsyncWebApi_Test.Controllers
{
    public class HomeController : Controller
    {
        public class PatOBInfo
        {
            public int acokey { get; set; }
            public int practiceid { get; set; }
            public string userid { get; set; }
            public string searchtext { get; set; }
            public int option { get; set; }
            public int viewall { get; set; }
        }
        public ActionResult Index()
        {
            PatOBInfo jobject = new PatOBInfo();
            jobject.acokey = 1;
            jobject.practiceid = 1;
            jobject.userid = "1";
            jobject.searchtext = "";
            jobject.option = 1;
            jobject.viewall = 1;

            ViewData["list"] = PostAsyncWebApi_Test(jobject);
            return View();
        }

        public  List<PatOBInfo> PostAsyncWebApi_Test(PatOBInfo product)
        {
            List<PatOBInfo> list = new List<PatOBInfo>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://internal.premierphc360.com/CCMAPI");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(product), System.Text.Encoding.UTF8, "application/json");
                // HTTP POST
                HttpResponseMessage response = client.PostAsync("https://internal.premierphc360.com/CCMAPI/api/Patient/PostAsyncWebApi_Test", content).Result;
                string data1 = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<PatOBInfo>>(data);
                }
            }
            return list;
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