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
        public Hostel HostelVM = new Hostel();
        //public List<Student> Students = new List<Student>();
        public Student CenterFacilityVM = new Student();
        public List<Medical> MedicalVMs = new List<Medical>();
        public Library LibraryVM = new Library();
        public COE COEVM = new COE();
        public FacilitiesController(IWebHostEnvironment hostingEnvironment) 
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\Data\Facilities\Hostel.json";
            string jsonpath1 = webRootPath + @"\Data\Facilities\Medical.json";
            string jsonpath3 = webRootPath + @"\Data\Facilities\Library.json";
            // string jasonpath1 = webRootPath + @"\Data\Facilities\Student.json";
            string jsonpath2 = webRootPath + @"\Data\Facilities\CenterFacilities.json";
            string jsonpath4 = webRootPath + @"\Data\Facilities\COE.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            string json2 = webClient.DownloadString(jsonpath2);
            string json1 = webClient.DownloadString(jsonpath1);
            string json3 = webClient.DownloadString(jsonpath3);
            string json4 = webClient.DownloadString(jsonpath4);

            // string json1 = webClient.DownloadString(jasonpath1);
            HostelVM = JsonConvert.DeserializeObject<Hostel>(json);
			// Students = JsonConvert.DeserializeObject<List<Student>>(json1);
			CenterFacilityVM = JsonConvert.DeserializeObject<Student>(json2);
            MedicalVMs = JsonConvert.DeserializeObject<List<Medical>>(json1);
            LibraryVM = JsonConvert.DeserializeObject<Library>(json3);
            COEVM = JsonConvert.DeserializeObject<COE>(json4);


        }
        //public iactionresult facilitypage(int id)
        //{
        //    var facility = facilitiesvms.where(m => m.id == id).firstordefault();
        //    return view(facility);
        //}
        public IActionResult Library ()
        {
            return View(LibraryVM);
        }
        public IActionResult Canteen()
        {
            return View();
        }
        public IActionResult Hostel()
        {
            return View(HostelVM);
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
        public IActionResult CenterFacilites()
        {
            return View(CenterFacilityVM);
        }
		

		public IActionResult CenterOfExcellence()
        {
            return View(COEVM);
        }
        public IActionResult Transportation()
        {
            return View();
        }
    }
}
