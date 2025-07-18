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
    public class DepartmentController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<FacultyDetailsVM> FacultyData = new List<FacultyDetailsVM>();
        public List<DepartmentVM>  DepartmentData = new List<DepartmentVM>();
        public List<Labs> LabsData = new List<Labs>();
		public List<AchievementsVM> AchievementsVM = new List<AchievementsVM>();
		public AchievementsWrapperVM achievementsWrapperVM = new AchievementsWrapperVM();
        public List<CommitteeActivity> ActivitiesVM = new List<CommitteeActivity>();
        public DepartmentController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\Data\Faculties\FacultyRecords.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            FacultyData = JsonConvert.DeserializeObject<List<FacultyDetailsVM>>(json);

            jsonpath = webRootPath + @"\Data\Departments\department.json";

            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            DepartmentData = JsonConvert.DeserializeObject<List<DepartmentVM>>(json);

            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);

            // Deserialize directly into a List<Labs>
            LabsData = JsonConvert.DeserializeObject<List<Labs>>(json);

			jsonpath = webRootPath + @"\Data\Achievements\Achievements.json";
			webClient = new WebClient();
			json = webClient.DownloadString(jsonpath);
			achievementsWrapperVM = JsonConvert.DeserializeObject<AchievementsWrapperVM>(json);

            jsonpath = webRootPath + @"\Data\Activities\Activities.json";
            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            ActivitiesVM = JsonConvert.DeserializeObject<List<CommitteeActivity>>(json);

        }

        public IActionResult DepartmentDetails(int id=0)
        {
            var data = DepartmentData.Where(m => m.ID == id).FirstOrDefault();

            if (data != null)
            {
                data.FacultyList = FacultyData.Where(m => m.Dept_ID == id).OrderBy(m => m.ID).ToList();
				data.Achievements = achievementsWrapperVM.Achievements.Where(m => m.DeptID == id).OrderBy(m => m.ID).ToList();
                data.Activities = ActivitiesVM.Where(m => m.CommitteId == id).OrderBy(m => m.ID).ToList();
                //data.Labs = LabsData.Where(m => m.Dept_ID == id).OrderBy(m => m.LabID).ToList(); // Use Dept_ID
            }

            return View(data);
        }

		//public IActionResult AchievementsByDept(int deptId = 0)
		//{
		//	AchievementsWrapperVM data = new AchievementsWrapperVM();
		//	data = achievementsWrapperVM;
		//	if (deptId > 0)
		//	{
		//		data.Achievements = achievementsWrapperVM.Achievements.Where(m => m.DeptID == deptId).ToList();
		//	}

		//	return View("_Achievements", data);
		//}
		public IActionResult EC()
        {
            var ecData = FacultyData.Where(m => m.Dept_ID == 1).OrderBy(m => m.ID).ToList();
            return View(ecData);
        }
        public IActionResult Computer()
        {
            var compData = FacultyData.Where(m => m.Dept_ID == 2).OrderBy(m => m.ID).ToList();
            return View(compData);
        }
        public IActionResult Electrical()
        {
            var elecData = FacultyData.Where(m => m.Dept_ID == 3).OrderBy(m => m.ID).ToList();
            return View(elecData);
        }
        public IActionResult Civil()
        {
            var civilData = FacultyData.Where(m => m.Dept_ID == 4).OrderBy(m => m.ID).ToList();
            return View(civilData);
        }

        public IActionResult Mechanical()
        {
            var mechData = FacultyData.Where(m => m.Dept_ID == 5).OrderBy(m => m.ID).ToList();
            return View(mechData);
        }
        public IActionResult Library()
        {
            return View();
        }
        public IActionResult Administrative()
        {
            return View();
        }
        public IActionResult TEQIP()
        {
            return View();
        }
        public IActionResult General()
        {
            var genData = FacultyData.Where(m => m.Dept_ID == 6).OrderBy(m => m.ID).ToList();
            return View(genData);
        }

        public IActionResult Applied()
        {
            var genData = FacultyData.Where(m => m.Dept_ID == 8).OrderBy(m => m.ID).ToList();
            return View(genData);
        }
    }
}
