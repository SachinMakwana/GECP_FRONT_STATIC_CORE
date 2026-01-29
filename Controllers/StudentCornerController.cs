using GECP_Front_End_Static.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using System.Net;
using System.Linq;

namespace GECP_Front_End_Static.Controllers
{
	public class StudentCornerController : Controller
	{
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<MOUModel> MOUModelVM = new List<MOUModel>();
		public List<CommitteeActivity> ActivitiesVM = new List<CommitteeActivity>();
        public Student ClubsVMs = new Student();
        public StudentCornerController(IWebHostEnvironment hostingEnvironment)
		{
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\MOU\MPU.json";
            string jsonpath1 = webRootPath + @"\Data\Facilities\StudentClub.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            string json1 = webClient.DownloadString(jsonpath1);
            MOUModelVM = JsonConvert.DeserializeObject<List<MOUModel>>(json);
            ClubsVMs = JsonConvert.DeserializeObject<Student>(json1);

            jsonpath = webRootPath + @"\Data\Activities\Activities.json";
            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            ActivitiesVM = JsonConvert.DeserializeObject<List<CommitteeActivity>>(json);
        }
        public IActionResult Rules()
		{
			return View();
		}
		public IActionResult TimeTable()
		{
			return View(MOUModelVM);
		}
		public IActionResult Enroll()
		{
			return View(MOUModelVM);
		}
		public IActionResult StudentClubs ()
		{
			return View(ClubsVMs);
		}
        public IActionResult ClubDetails(int id)
        {
			var ClubVM = ClubsVMs.Clubs.FirstOrDefault(m => m.ID == id);
			ClubVM.Activities = ActivitiesVM.Where(m => m.ClubId == id).ToList();
            return View(ClubVM);
        }
        public IActionResult StudentGradeHistory()
		{
			return View();
		}
		public IActionResult Fees()
		{
			return View();
		}
    }
}
