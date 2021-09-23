using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GECP_Front_End_Static.Models;
using System.IO;

namespace GECP_Front_End_Static.Controllers
{
    public class FacultyController : Controller
    {
        public List<FacultyDetailsVM> FacultyData = new List<FacultyDetailsVM>();

        public FacultyController()
        {
            var webClient = new WebClient();
            string json = webClient.DownloadString(@"D:\GECP_FRONT_STATIC_CORE\wwwroot\js\FacultyRecords.json");
            FacultyData = JsonConvert.DeserializeObject<List<FacultyDetailsVM>>(json);
        }
        public IActionResult Electronics()
        {

            var ecData = FacultyData.Where(m => m.Dept_ID == 1).ToList();
            return View(ecData);
        }

        public IActionResult Computer()
        {
            return View();
        }

        public IActionResult Electrical()
        {
            return View();
        }

        public IActionResult Civil()
        {
            return View();
        }

        public IActionResult Mechanical()
        {
            return View();
        }

        public IActionResult Library()
        {
            return View();
        }

        public IActionResult Administration()
        {
            return View();
        }

        public IActionResult TEQIP()
        {
            return View();
        }

        public IActionResult FacultyInfo(int ID = 0)
        {
            FacultyDetailsVM data = FacultyData.Where(m => m.ID == ID).FirstOrDefault();
            return View(data);
        }
    }
}
