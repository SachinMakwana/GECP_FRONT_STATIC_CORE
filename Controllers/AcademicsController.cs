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
   
    public class AcademicsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<AchievementsVM> AchievementsVM = new List<AchievementsVM>();
        public List<AcademicCalendersVM> AcademicCalendersVM = new List<AcademicCalendersVM>();
        public List<SSIPDocumentsVM> SSIPDocumentsVM = new List<SSIPDocumentsVM>();
        public List<ResearchGrantsVM> ResearchGrantsVM = new List<ResearchGrantsVM>();
        public AchievementsWrapperVM achievementsWrapperVM = new AchievementsWrapperVM();
        public IntakeVM intakeVM = new IntakeVM();
        public AcademicsController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\Data\Achievements\Achievements.json";
            string jsonpath1 = webRootPath + @"\Data\Academics\SSIPDocuments.json";
            string jsonpath2 = webRootPath + @"\Data\Academics\ResearchGrants.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            string json1 = webClient.DownloadString(jsonpath1);
            string json2 = webClient.DownloadString(jsonpath2);
            achievementsWrapperVM = JsonConvert.DeserializeObject<AchievementsWrapperVM>(json);
            //AchievementsVM = achievementsWrapperVM.Achievements;

            jsonpath = webRootPath + @"\Data\Academics\AcademicsCalender.json";

            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            AcademicCalendersVM = JsonConvert.DeserializeObject<List<AcademicCalendersVM>>(json);
            SSIPDocumentsVM = JsonConvert.DeserializeObject<List<SSIPDocumentsVM>>(json1);
            ResearchGrantsVM = JsonConvert.DeserializeObject<List<ResearchGrantsVM>>(json2);

            jsonpath = webRootPath + @"\Data\Academics\Intake.json";

            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            intakeVM = JsonConvert.DeserializeObject<IntakeVM>(json);
            SSIPDocumentsVM = JsonConvert.DeserializeObject<List<SSIPDocumentsVM>>(json1);
            ResearchGrantsVM = JsonConvert.DeserializeObject<List<ResearchGrantsVM>>(json2);
        }
        public IActionResult AcademicCalender()
        {
            return View(AcademicCalendersVM.Where(m=>m.isShow==true).ToList());
        }

        public IActionResult AdmissionProcess()
        {
            return View(intakeVM);
        }

        public IActionResult Achievements()
        {
            return View(achievementsWrapperVM);
        }

        public IActionResult AchievementsByYear(int year=0)
        {
            AchievementsWrapperVM data = new AchievementsWrapperVM();
            data = achievementsWrapperVM;
            if (year > 0)
            {
                data.Achievements = achievementsWrapperVM.Achievements.Where(m => m.Year == year).ToList();
            }
            
            return View("_Achievements", data);
        }

        //send data departmentwise
        //public IActionResult AchievementsByDept(int deptId = 0) {
        //    AchievementsWrapperVM data = new AchievementsWrapperVM();
        //    data = achievementsWrapperVM;
        //    if (deptId > 0)
        //    {
        //        data.Achievements = achievementsWrapperVM.Achievements.Where(m => m.DeptID == deptId).ToList();
        //    }

        //    return View("_Achievements", data);
        //}

        public IActionResult SSIPDocuments()
        {
            return View(SSIPDocumentsVM.Where(m => m.isShow == true).ToList());
        }
        public IActionResult ResearchGrants()
        {
            return View(ResearchGrantsVM.Where(m => m.isShow == true).OrderByDescending(m => m.ID).ToList());
        }

        public IActionResult Syllabus()
        { 
            return View();
        }
    }
}
