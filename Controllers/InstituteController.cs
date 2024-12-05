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
    public class InstituteController : Controller
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<MOUModel> MOUModelVM = new List<MOUModel>();
        public List<NewsLettersModel> NewsLettersModel = new List<NewsLettersModel>();
        public List<NEWSModel> NEWSModelData = new List<NEWSModel>();
        public List<TendersVM> TendersVM = new List<TendersVM>();
        public List<TendersVM> ImpDocuments = new List<TendersVM>();

        public InstituteController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\MOU\MPU.json";
            string newsjsonpatah = webRootPath + @"\NEWS.json";
            string tendersjsonpath = webRootPath + @"\Tenders\Tenders.json";
            string impDocsJsonpath = webRootPath + @"\Data\ImportantDocuments\documentItems.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            MOUModelVM = JsonConvert.DeserializeObject<List<MOUModel>>(json);

            jsonpath = webRootPath + @"\news\NewsLetters.json";

            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            NewsLettersModel = JsonConvert.DeserializeObject<List<NewsLettersModel>>(json);

            webClient = new WebClient();
            json = webClient.DownloadString(newsjsonpatah);
            NEWSModelData = JsonConvert.DeserializeObject<List<NEWSModel>>(json);

            webClient = new WebClient();
            json = webClient.DownloadString(tendersjsonpath);
            TendersVM = JsonConvert.DeserializeObject<List<TendersVM>>(json);

            webClient = new WebClient();
            json = webClient.DownloadString(impDocsJsonpath);
            ImpDocuments = JsonConvert.DeserializeObject<List<TendersVM>>(json);
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult CoE()
        {
            return View();
        }
        public IActionResult NewsLetter()
        {
            return View(NewsLettersModel.OrderByDescending(m=>m.ID).ToList());
        }

        public IActionResult Tenders()
        {
            return View(TendersVM.Where(m=>m.isShow==true).ToList());
        }

        public IActionResult ImportantDocuments()
        {
            return View(ImpDocuments.Where(m => m.isShow == true).ToList());
        }

        public IActionResult MoU()
        {
            return View(MOUModelVM);
        }

        public IActionResult RTI()
        {
            return View();
        }

        public IActionResult NEWS()
        {
            var data = NEWSModelData.Where(m => string.IsNullOrWhiteSpace(m.ActionName) && string.IsNullOrWhiteSpace(m.ControllerName)).ToList();
            return View(data);
        }

        public IActionResult NEWSDetail(int id=0)
        {
            var data = NEWSModelData.Where(m => m.ID == id).FirstOrDefault();
            return View(data);
        }
    }
}
