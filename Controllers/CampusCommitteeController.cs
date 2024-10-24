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
        public List<PlacementDataVM> placementDataVM = new List<PlacementDataVM>();
        public List<PlacementTeamVM> PlacementTeamVM = new List<PlacementTeamVM>();
        public List<PlacementMarqueeModel> CurrentPlacement = new List<PlacementMarqueeModel>();
        public List<Studentsplaced> Studentsplaceds = new List<Studentsplaced>();

        public CampusCommitteeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\PlacementCell\PlacementData.json";
            string jsonpath2 = webRootPath + @"\js\CurrentPlacement\placementmarquee.json";
            string jsonpath3 = webRootPath + @"\PlacementCell\StudentsPlaced.json";
            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            placementDataVM = JsonConvert.DeserializeObject<List<PlacementDataVM>>(json);

            jsonpath = webRootPath + @"\PlacementCell\PlacementTeam.json";
            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            PlacementTeamVM = JsonConvert.DeserializeObject<List<PlacementTeamVM>>(json);

            json = webClient.DownloadString(jsonpath2);
            CurrentPlacement = JsonConvert.DeserializeObject<List<PlacementMarqueeModel>>(json);

            json = webClient.DownloadString(jsonpath3);
            Studentsplaceds = JsonConvert.DeserializeObject<List<Studentsplaced>>(json);
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
            PlacementPageData placementPageData = new PlacementPageData();
            placementPageData.placementMarqueeModel = CurrentPlacement;
            placementPageData.PlacementTeamVMs = PlacementTeamVM;
            placementPageData.PlacementDataVMs = placementDataVM;
            placementPageData.StudentsPlaced = Studentsplaceds;
            return View(placementPageData);
        }

        public IActionResult Placements()
        {
            return View(CurrentPlacement);
        }

        [HttpPost]
        public IActionResult Marquee(int id = 0)
        {
            var data = CurrentPlacement.Where(m => m.ID == id).Cast<PlacementMarqueeModel>().Where(m => m.IsFile == true).ToList();
            return Json(data);
        }

        [HttpPost]
        public IActionResult GetChartData(int id = 0)
        {
            var data = placementDataVM.Where(m => m.BranchID == id).FirstOrDefault().Data.Where(m => m.IsDisplay == true).ToList();
            return Json(data);
        }

        [HttpPost]
        public IActionResult GetPieChartData()
        {
            List<PlacementPieChart> placementPieCharts = new List<PlacementPieChart>();
           
            foreach (var item in placementDataVM)
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
