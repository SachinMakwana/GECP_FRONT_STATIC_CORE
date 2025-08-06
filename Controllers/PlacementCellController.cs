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
        }
        public IActionResult Index()
        {
            PlacementCellContent.RecruiterDetails.Courses = ProgramIntake;
            return View(PlacementCellContent);
        }
    }
}
