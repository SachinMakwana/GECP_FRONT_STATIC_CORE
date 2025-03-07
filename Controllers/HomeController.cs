using GECP_Front_End_Static.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace GECP_Front_End_Static.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<MarqueeModelVM> MarqueeData = new List<MarqueeModelVM>();
        public List<TestimonialModelVM> TestimonialData = new List<TestimonialModelVM>();
        public List<NEWSModel> NEWSModelData = new List<NEWSModel>();
        public List<MasterSliderVM> MasterSliderVMData = new List<MasterSliderVM>();
        public List<MenuVM> MenuVMs = new List<MenuVM>();
        private HeaderVM headerVM = new HeaderVM();
        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string marqueejsonpath = webRootPath + @"\js\MarqueeContent.json";
            string testimonialjsonpath = webRootPath + @"\js\TestimonialsData.json";
            string newsjsonpatah = webRootPath + @"\NEWS.json";
            string MSjsonpatah = webRootPath + @"\Data\MasterSlider.json";
            string HeaderJsonpatah = webRootPath + @"\Data\HeaderItems.json";
            string MenuJsonpatah = webRootPath + @"\Data\MenuItems.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(marqueejsonpath);
            MarqueeData = JsonConvert.DeserializeObject<List<MarqueeModelVM>>(json);

            webClient = new WebClient();
            json = webClient.DownloadString(testimonialjsonpath);
            TestimonialData = JsonConvert.DeserializeObject<List<TestimonialModelVM>>(json);

            webClient = new WebClient();
            json = webClient.DownloadString(newsjsonpatah);
            NEWSModelData = JsonConvert.DeserializeObject<List<NEWSModel>>(json);

            webClient = new WebClient();
            json = webClient.DownloadString(MSjsonpatah);
            MasterSliderVMData = JsonConvert.DeserializeObject<List<MasterSliderVM>>(json);

            webClient = new WebClient();
            json = webClient.DownloadString(HeaderJsonpatah);
            headerVM = JsonConvert.DeserializeObject<HeaderVM>(json);

            webClient = new WebClient();
            json = webClient.DownloadString(MenuJsonpatah);
            MenuVMs = JsonConvert.DeserializeObject<List<MenuVM>>(json);
        }

        public IActionResult Index()
        {
            HomePageModelVM homePageModelVM = new HomePageModelVM();
            homePageModelVM.marqueeModelVM = MarqueeData;
            homePageModelVM.testimonialModelVM = TestimonialData;
            homePageModelVM.newsModelVM = NEWSModelData;
            homePageModelVM.masterSliderVM = MasterSliderVMData;
            return View(homePageModelVM);
        }

        public PartialViewResult TopMenu()
        {
            return PartialView(@"~/Views/Shared/_topHeader.cshtml", headerVM);
        }

        public PartialViewResult Footer()
        {
            return PartialView(@"~/Views/Shared/_footer.cshtml", headerVM);
        }
        public PartialViewResult Menu(string currentController, string currentAction, int? dynamicID)
        {
            if (currentController == null || currentAction == null)
            {
                currentController = ControllerContext.RouteData.Values["controller"]?.ToString();
                currentAction = ControllerContext.RouteData.Values["action"]?.ToString();
            }
            ViewBag.CurrentController = currentController;
            ViewBag.CurrentAction = currentAction;
            ViewBag.DynamicID = dynamicID;
            return PartialView(@"~/Views/Shared/_header.cshtml", MenuVMs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
