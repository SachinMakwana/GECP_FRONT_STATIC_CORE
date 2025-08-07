using GECP_Front_End_Static.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GECP_Front_End_Static.Controllers
{
    public class PlacementCellController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PlacementCellContent PlacementCellContent = new PlacementCellContent();
        public List<ProgramInfo> ProgramIntake = new List<ProgramInfo>();
        public List<CommitteeActivity> ActivitiesCalendar = new List<CommitteeActivity>();
        public PlacementCellController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;

            string jsonpath = webRootPath + @"\Data\NewPlacementCell\PlacementCellContent.json";
            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            PlacementCellContent = JsonConvert.DeserializeObject<PlacementCellContent>(json);

            jsonpath = webRootPath + @"\Data\Institute\ProgramIntake.json";
            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            ProgramIntake = JsonConvert.DeserializeObject<List<ProgramInfo>>(json);

            jsonpath = webRootPath + @"\Data\Activities\Activities.json";
            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            ActivitiesCalendar = JsonConvert.DeserializeObject<List<CommitteeActivity>>(json);
        }
        public IActionResult Index()
        {
            var data = ActivitiesCalendar
           .Where(x => x.CommitteId == 9
                &&( x.Files != null
                && x.Files.Any(f =>
                       f.FileType.Equals("PDF", StringComparison.OrdinalIgnoreCase)
                       && !string.IsNullOrWhiteSpace(f.FilePath)))
            || (!string.IsNullOrWhiteSpace(x.TargetStudents)))
                .ToList();
          
            PlacementCellContent.RecruiterDetails.Courses = ProgramIntake;
            PlacementCellContent.ActivitiesCalendar = data;

            return View(PlacementCellContent);
        }
    }
}
