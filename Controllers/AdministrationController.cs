using GECP_Front_End_Static.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace GECP_Front_End_Static.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<FacultyDetailsVM> FacultyData = new List<FacultyDetailsVM>();

        public AdministrationController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\Data\Faculties\FacultyRecords.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            FacultyData = JsonConvert.DeserializeObject<List<FacultyDetailsVM>>(json);

        }
        public IActionResult Principal()
        {
            return View();
        }

        public IActionResult Esta()
        {
            var adminData = FacultyData.Where(m => m.Dept_ID == 7).OrderBy(m => m.ID).ToList();
            return View(adminData);
        }
    }
}
