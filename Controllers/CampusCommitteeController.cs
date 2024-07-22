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
    public class CampusCommitteeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<PlacementDataVM> PlacementDataVM = new List<PlacementDataVM>();

        public CampusCommitteeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\PlacementCell\PlacementData.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            PlacementDataVM = JsonConvert.DeserializeObject<List<PlacementDataVM>>(json);
        }
        public IActionResult WomenCell()
        {
            return View(); 
        }
        public IActionResult SSIP()
        {
            return View();
        }
        public IActionResult NSS()
        {
            return View();
        }
        public IActionResult AntiRagging()
        {
            return View();
        }
        public IActionResult Grievence()
        {
            return View();
        }
        public IActionResult PlacementCell()
        {
            return View(PlacementDataVM);
        }
    }
}
