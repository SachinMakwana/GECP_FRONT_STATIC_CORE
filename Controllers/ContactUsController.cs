using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GECP_Front_End_Static.helpers;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;
using GECP_Front_End_Static.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Net;

namespace GECP_Front_End_Static.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private HeaderVM headerVM = new HeaderVM();
        public ContactUsController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string HeaderJsonpatah = webRootPath + @"\Data\HeaderItems.json";

            var webClient = new WebClient();
            var json = webClient.DownloadString(HeaderJsonpatah);
            headerVM = JsonConvert.DeserializeObject<HeaderVM>(json);
        }

        public IActionResult Index()
        {
            return View(headerVM);
        }

        [HttpPost]
        public JsonResult Index(ContactModel form)
        {

            StringBuilder collegemsg = new StringBuilder();

            collegemsg.AppendFormat("Hi...<br/>");
            collegemsg.AppendFormat("<br/>Please check the details");

            collegemsg.AppendFormat("<table>");
            collegemsg.AppendFormat("<tr><td>Name</td><td>&nbsp;&nbsp;&nbsp;{0}</td>", form.Name);
            collegemsg.AppendFormat("<tr><td>Phone</td><td>&nbsp;&nbsp;&nbsp;{0}</td>", form.Phone);
            collegemsg.AppendFormat("<tr><td>Subject</td><td>&nbsp;&nbsp;&nbsp;{0}</td>", form.Subject);
            collegemsg.AppendFormat("<tr><td>Message</td><td>&nbsp;&nbsp;&nbsp;{0}</td>", form.Message);
            collegemsg.AppendFormat("</table>");

            StringBuilder studntmsg = new StringBuilder();

            studntmsg.AppendFormat("Hi {0}", form.Name);
            studntmsg.AppendFormat("<br/>We have received your contact request.");
            studntmsg.AppendFormat("<br/>We will contact back soon.<br/>");
            studntmsg.AppendFormat("<br/><br/>");
            studntmsg.AppendFormat("Thank you");
            studntmsg.AppendFormat("<br/>GEC Patan");

            var flag = Email.SendEmail(form.Email, form.Subject + " " + form.Name, studntmsg.ToString(), "contact@gecpatan.ac.in","no-reply");
            var flag1 = Email.SendEmail("contact@gecpatan.ac.in", "Contact Request [" + form.Subject + "_" + form.Name + "]", collegemsg.ToString(), form.Email);
            return Json(true);
        }
    }
}