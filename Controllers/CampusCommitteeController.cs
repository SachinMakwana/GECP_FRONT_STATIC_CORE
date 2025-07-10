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
    public class CampusCommitteeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<PlacementDataVM> PlacementDataVM = new List<PlacementDataVM>();
        public List<PlacementTeamVM> PlacementTeamVM = new List<PlacementTeamVM>();
        public List<CampusCommittesVM> CampusCommittesVMs = new List<CampusCommittesVM>();
		public AchievementsWrapperVM achievementsWrapperVM = new AchievementsWrapperVM();
		public List<CommitteeActivity> ActivitiesVM = new List<CommitteeActivity>();
		public CampusCommitteeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\Data\PlacementCell\PlacementData.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            PlacementDataVM = JsonConvert.DeserializeObject<List<PlacementDataVM>>(json);

            jsonpath = webRootPath + @"\Data\PlacementCell\PlacementTeam.json";
            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            PlacementTeamVM = JsonConvert.DeserializeObject<List<PlacementTeamVM>>(json);

            jsonpath = webRootPath + @"\Data\CampusCommittes\CampusCommittes.json";
            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            CampusCommittesVMs = JsonConvert.DeserializeObject<List<CampusCommittesVM>>(json);

			jsonpath = webRootPath + @"\Data\Achievements\Achievements.json";
			webClient = new WebClient();
			json = webClient.DownloadString(jsonpath);
			achievementsWrapperVM = JsonConvert.DeserializeObject<AchievementsWrapperVM>(json);

            jsonpath = webRootPath + @"\Data\Activities\Activities.json";
            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            ActivitiesVM = JsonConvert.DeserializeObject<List<CommitteeActivity>>(json);
        }

        public IActionResult CommitteePage(int id)
        {
            var committee = CampusCommittesVMs.Where(m=>m.ID==id).FirstOrDefault();
			committee.Achievements = achievementsWrapperVM.Achievements.Where(m => m.CommitteId == id).OrderBy(m => m.ID).ToList();
			committee.Activities = ActivitiesVM.Where(m => m.CommitteId == id).OrderBy(m => m.ID).ToList();
			return View(committee);
        }

        public IActionResult Activities (int id)
        {
            var activity = ActivitiesVM.Where(m => m.ID == id).FirstOrDefault();
            return View(activity);
        }
        public IActionResult WomenCell()
        {
            return View();
        }
        public IActionResult SSIP()
        {
            return View();
        }
        public IActionResult NSS()
        {
            return View();
        }
        public IActionResult AntiRagging()
        {
            return View();
        }
        public IActionResult Grievence()
        {
            return View();
        }
        public IActionResult PlacementCell()
        {

            return View(PlacementTeamVM);
        }

        public IActionResult PlacementStatistics()
        {
            return View(PlacementDataVM);
        }

        [HttpPost]
        public IActionResult GetChartData(int id = 0)
        {
            var data = PlacementDataVM.Where(m => m.BranchID == id).FirstOrDefault().Data.Where(m => m.IsDisplay == true).ToList();
            return Json(data);
        }

        [HttpPost]
        public IActionResult GetPieChartData()
        {
            List<PlacementPieChart> placementPieCharts = new List<PlacementPieChart>();
           
            foreach (var item in PlacementDataVM)
            {
                foreach (var pie in item.Pie)
                {
                    var placementPieChart = placementPieCharts.Where(m => m.year == pie.year).FirstOrDefault();
                    
                    BranchWisePercentage branchWisePercentage = new BranchWisePercentage();
                    branchWisePercentage.BranchName = item.BranchName;
                    branchWisePercentage.year = pie.year;
                    branchWisePercentage.Percentage = pie.Percentage;

                    if(placementPieChart != null)
                    {
                        placementPieCharts.Where(m => m.year == pie.year).FirstOrDefault().Data.Add(branchWisePercentage);
                    }
                    else
                    {
                        placementPieChart = new PlacementPieChart();
                        placementPieChart.year = pie.year;
                        placementPieChart.ID = placementPieCharts.LastOrDefault() != null ? placementPieCharts.LastOrDefault().ID + 1 : 1;
                        placementPieChart.Data.Add(branchWisePercentage);
                        placementPieCharts.Add(placementPieChart);
                    }
                }
            }
            return Json(placementPieCharts);
        }
    }
}
