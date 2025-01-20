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
        //public List<Student> Students = new List<Student>();
        public List<Student> StudentVMs = new List<Student>();
        public List<Medical> MedicalVMs = new List<Medical>();
        public List<Library> LibraryVMs = new List<Library>();
        public FacilitiesController(IWebHostEnvironment hostingEnvironment) 
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\Data\Facilities\Facilities.json";
            string jsonpath1 = webRootPath + @"\Data\Facilities\Medical.json";
            string jsonpath3 = webRootPath + @"\Data\Facilities\Library.json";
            // string jasonpath1 = webRootPath + @"\Data\Facilities\Student.json";
            string jsonpath2 = webRootPath + @"\Data\Facilities\Student.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            string json2 = webClient.DownloadString(jsonpath2);
            string json1 = webClient.DownloadString(jsonpath1);
            string json3 = webClient.DownloadString(jsonpath3);

            // string json1 = webClient.DownloadString(jasonpath1);
            FacilitiesVMs = JsonConvert.DeserializeObject<List<FacilitiesVM>>(json);
            // Students = JsonConvert.DeserializeObject<List<Student>>(json1);
            StudentVMs = JsonConvert.DeserializeObject<List<Student>>(json2);
            MedicalVMs = JsonConvert.DeserializeObject<List<Medical>>(json1);
            LibraryVMs = JsonConvert.DeserializeObject<List<Library>>(json3);


        }
        public IActionResult FacilityPage(int id)
        {
            var Facility = FacilitiesVMs.Where(m => m.ID == id).FirstOrDefault();
            return View(Facility);
        }
        public IActionResult Library ()
        {
            return View(LibraryVMs);
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
        public IActionResult MedicalFacility(int id)
        {
            var medical = MedicalVMs.Where(m => m.ID == id).FirstOrDefault();
            return View(medical);
        }
        public IActionResult StudentClub(int id)
        {
            var student = StudentVMs.Where(m => m.ID == id).FirstOrDefault();
            // var Stud = Students.Where(m => m.ID == id).FirstOrDefault();
            return View(student);
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
