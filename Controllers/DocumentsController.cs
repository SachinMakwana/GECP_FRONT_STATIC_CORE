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
    public class DocumentsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<DocumentsVm> DocumentsVms = new List<DocumentsVm>();

        public DocumentsController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string jsonpath = webRootPath + @"\Data\Documents\Documents.json";

            var webClient = new WebClient();
            string json = webClient.DownloadString(jsonpath);
            DocumentsVms = JsonConvert.DeserializeObject<List<DocumentsVm>>(json);

        }


        public IActionResult Index(int id = 0)
        {
            var data = DocumentsVms.Where(m => m.Id == id).FirstOrDefault();
            data.YearSection = data.YearSection.OrderBy(m => m.Year).ToList();
            return View(data);
        }

    }
}