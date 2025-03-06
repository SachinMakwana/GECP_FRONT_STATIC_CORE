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
        public List<DocumentsVm> TendersVM = new List<DocumentsVm>();
        public List<TendersVM> ImpDocuments = new List<TendersVM>();

        public List<DocumentsVm> DocumentsVms = new List<DocumentsVm>();

        public InstituteController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            //string jsonpath = webRootPath + @"\MOU\MPU.json";
            string jsonpath = webRootPath + @"\Data\Documents\Documents.json";
            string newsjsonpatah = webRootPath + @"\NEWS.json";
            string tendersjsonpath = webRootPath + @"\Data\Tenders\Tenders.json";
            string impDocsJsonpath = webRootPath + @"\Data\ImportantDocuments\documentItems.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            //MOUModelVM = JsonConvert.DeserializeObject<List<MOUModel>>(json);
            DocumentsVms = JsonConvert.DeserializeObject<List<DocumentsVm>>(json);

            jsonpath = webRootPath + @"\news\NewsLetters.json";

            webClient = new WebClient();
            json = webClient.DownloadString(jsonpath);
            NewsLettersModel = JsonConvert.DeserializeObject<List<NewsLettersModel>>(json);

            webClient = new WebClient();
            json = webClient.DownloadString(newsjsonpatah);
            NEWSModelData = JsonConvert.DeserializeObject<List<NEWSModel>>(json);

            webClient = new WebClient();
            json = webClient.DownloadString(tendersjsonpath);
            TendersVM = JsonConvert.DeserializeObject<List<DocumentsVm>>(json);

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
            return View(NewsLettersModel.OrderByDescending(m => m.ID).ToList());
        }

        public IActionResult Tenders()
        {
            return View(TendersVM);
        }

        public IActionResult TendersTableView()
        {
            return View(TendersVM);
        }

        [HttpPost]
        public IActionResult TendersList(int id = 0)
        {
            DocumentsVm data = new DocumentsVm();
            if (id > 0)
            {
                data = TendersVM.Where(m => m.Id == id).FirstOrDefault();
                data.YearSection = data.YearSection.OrderByDescending(m => m.Order).ToList();
            }
            return View(data);
        }

        public IActionResult ImportantDocuments()
        {
            return View(ImpDocuments.Where(m => m.isShow == true).ToList());
        }

        public IActionResult MoU() //document id 50
        {
            DocumentsVm data = new DocumentsVm();

            data = DocumentsVms.Where(m => m.Id == 50).FirstOrDefault();
            data.YearSection = data.YearSection.OrderByDescending(m => m.Order).ToList();
            return View(data);
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

        public IActionResult NEWSDetail(int id = 0)
        {
            var data = NEWSModelData.Where(m => m.ID == id).FirstOrDefault();
            return View(data);
        }
    }
}