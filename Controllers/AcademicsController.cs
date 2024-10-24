﻿using GECP_Front_End_Static.Models;
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
   
    public class AcademicsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<AchievementsVM> AchievementsVM = new List<AchievementsVM>();

        public AcademicsController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\Achievements\Achievements.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            AchievementsVM = JsonConvert.DeserializeObject<List<AchievementsVM>>(json);
        }
        public IActionResult AcademicCalender()
        {
            return View();
        }

        public IActionResult AdmissionProcess()
        {
            return View();
        }

        public IActionResult Achievements()
        {
            return View(AchievementsVM);
        }
    }
}
