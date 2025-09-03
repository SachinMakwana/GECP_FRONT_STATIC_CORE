using GECP_Front_End_Static.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace GECP_Front_End_Static.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<FacultyDetailsVM> FacultyData = new List<FacultyDetailsVM>();
        public List<PrincipalViewModel> PrincipalData = new List<PrincipalViewModel>();
        public CentralStoreVM CentralStore = new CentralStoreVM();

        public AdministrationController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\Data\Faculties\FacultyRecords.json";
            string jsonpath2 = webRootPath + @"\Data\Principal.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            FacultyData = JsonConvert.DeserializeObject<List<FacultyDetailsVM>>(json);

            string json2 = webClient.DownloadString(jsonpath2);
            PrincipalData = JsonConvert.DeserializeObject<List<PrincipalViewModel>>(json2);

            jsonpath = webRootPath + @"\Data\Administration\CentralStoreVM.json";
            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            CentralStore = JsonConvert.DeserializeObject<CentralStoreVM>(json);
        }
        public IActionResult Principal()
        {
            var principal = PrincipalData.FirstOrDefault();
            return View(principal);
        }

        public IActionResult Esta()
        {
            var adminData = FacultyData.Where(m => m.Dept_ID == 7).OrderBy(m => m.ID).ToList();
            return View(adminData);
        }

        public IActionResult Central_Store()
        { 
            return View(CentralStore);
        }
    }
}
