using GECP_Front_End_Static.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GECP_Front_End_Static.Controllers
{
    public class InstituteController : Controller
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<MOUModel> MOUModelVM = new List<MOUModel>();
        public List<NewsLettersModel> NewsLettersModel = new List<NewsLettersModel>();

        public InstituteController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\MOU\MPU.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            MOUModelVM = JsonConvert.DeserializeObject<List<MOUModel>>(json);

            jsonpath = webRootPath + @"\news\NewsLetters.json";

            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            NewsLettersModel = JsonConvert.DeserializeObject<List<NewsLettersModel>>(json);
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult CoE()
        {
            return View();
        }
        public IActionResult NewsLetter()
        {
            return View(NewsLettersModel.OrderByDescending(m=>m.ID).ToList());
        }

        public IActionResult Tenders()
        {
            return View();
        }

        public IActionResult ImportantDocuments()
        {
            return View();
        }

        public IActionResult MoU()
        {
            return View(MOUModelVM);
        }

        public IActionResult RTI()
        {
            return View();
        }
    }
}
