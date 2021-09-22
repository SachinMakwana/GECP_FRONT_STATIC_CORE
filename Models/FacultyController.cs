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

        public object JsonConvert { get; }

        public FacultyController()
        {
            var webClient = new WebClient();
            string json = webClient.DownloadString(@"C:\Users\Asus\source\repos\SachinMakwana\GECP_FRONT_STATIC_CORE\wwwroot\js\FacultyRecords.json");
            FacultyData = JsonConvert.DeserializeObject<List<FacultyDetailsVM>>(json);
        }
        public IActionResult Electronics()
        {

            var ecData = FacultyData.Where(m => m.Dept_ID == 1).ToList();
            return View(ecData);
        }

        public IActionResult Computer()
        {
            var computerData = FacultyData.Where(m => m.Dept_ID == 2).ToList();
            return View(computerData);
        }

        public IActionResult Electrical()
        {
            var electricalData = FacultyData.Where(m => m.Dept_ID == 3).ToList();
            return View(electricalData);
        }

        public IActionResult Civil()
        {
            var civilData = FacultyData.Where(m => m.Dept_ID == 4).ToList();
            return View(civilData);
        }

        public IActionResult Mechanical()
        {
            var mechanicalData = FacultyData.Where(m => m.Dept_ID == 5).ToList();
            return View(mechanicalData);
        }

        public IActionResult Library()
        {
            var libraryData = FacultyData.Where(m => m.Dept_ID == ).ToList();
            return View(libraryData);
        }

        public IActionResult Administration()
        {
            var administrationData = FacultyData.Where(m => m.Dept_ID == 6).ToList();
            return View(administrationData);
        }

        public IActionResult TEQIP()
        {
            var teqipData = FacultyData.Where(m => m.Dept_ID == 1).ToList();
            return View(teqipData);
        }

        public IActionResult FacultyInfo(int ID = 0)
        {
            FacultyDetailsVM data = FacultyData.Where(m => m.ID == ID).FirstOrDefault();
            return View(data);
        }
    }
}
