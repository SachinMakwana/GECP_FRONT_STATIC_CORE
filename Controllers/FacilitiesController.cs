using GECP_Front_End_Static.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace GECP_Front_End_Static.Controllers
{
    public class FacilitiesController : Controller
    { 
    
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<FacilitiesVM> FacilitiesVMs = new List<FacilitiesVM>();
        public FacilitiesController(IWebHostEnvironment hostingEnvironment) 
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\Data\Facilities\Facilities.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            FacilitiesVMs = JsonConvert.DeserializeObject<List<FacilitiesVM>>(json);

        }
        public IActionResult FacilityPage(int id)
        {
            var Facility = FacilitiesVMs.Where(m => m.ID == id).FirstOrDefault();
            return View(Facility);
        }
        public IActionResult Library ()
        {
            return View();
        }
        public IActionResult Canteen()
        {
            return View();
        }
        public IActionResult Hostel()
        {
            return View();
        }
        public IActionResult Gymkhana()
        {
            return View();
        }
        public IActionResult StudentSection()
        {
            return View();
        }
        public IActionResult CentralFacilities()
        {
            return View();
        }
        public IActionResult MedicalFacility()
        {
            return View();
        }
        public IActionResult StudentClub()
        {
            return View();
        }
        public IActionResult CenterOfExcellence()
        {
            return View();
        }
        public IActionResult Transportation()
        {
            return View();
        }
    }
}
