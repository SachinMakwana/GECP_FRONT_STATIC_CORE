using GECP_Front_End_Static.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using System.Net;

namespace GECP_Front_End_Static.Controllers
{
	public class StudentCornerController : Controller
	{
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<MOUModel> MOUModelVM = new List<MOUModel>();
        public StudentCornerController(IWebHostEnvironment hostingEnvironment)
		{
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\MOU\MPU.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            MOUModelVM = JsonConvert.DeserializeObject<List<MOUModel>>(json);
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
