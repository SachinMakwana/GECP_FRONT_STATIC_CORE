using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GECP_Front_End_Static.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GECP_Front_End_Static.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<FacultyDetailsVM> FacultyData = new List<FacultyDetailsVM>();

        public FacultyController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\js\FacultyRecords.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            FacultyData = JsonConvert.DeserializeObject<List<FacultyDetailsVM>>(json);
        }
        public IActionResult Electronics()
        {

            var ecData = FacultyData.Where(m => m.Dept_ID == 1).ToList();
            return View(ecData);
        }

        public IActionResult Computer()
        {
            var compData = FacultyData.Where(m => m.Dept_ID == 2).ToList();
            return View(compData);
        }

        public IActionResult Electrical()
        {
            var elecData = FacultyData.Where(m => m.Dept_ID == 3).ToList();
            return View(elecData);
        }

        public IActionResult Civil()
        {
            var civilData = FacultyData.Where(m => m.Dept_ID == 4).ToList();
            return View(civilData);
        }

        public IActionResult Mechanical()
        {
            var mechData = FacultyData.Where(m => m.Dept_ID == 5).ToList();
            return View(mechData);
        }

        public IActionResult Administration()
        {
            var adminData = FacultyData.Where(m => m.Dept_ID == 7).ToList();
            return View(adminData);
        }

        public IActionResult General()
        {
            var genData = FacultyData.Where(m => m.Dept_ID == 6).ToList();
            return View(genData);
        }

        public IActionResult FacultyInfo(int ID = 0)
        {
            FacultyDetailsVM data = FacultyData.Where(m => m.ID == ID).FirstOrDefault();
            return View(data);
        }
    }
}
