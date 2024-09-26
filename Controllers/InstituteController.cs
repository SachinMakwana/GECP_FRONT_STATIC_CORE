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
       

        public InstituteController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\MOU\MPU.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            MOUModelVM = JsonConvert.DeserializeObject<List<MOUModel>>(json);

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
            return View();
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
