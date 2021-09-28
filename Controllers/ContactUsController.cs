using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GECP_Front_End_Static.helpers;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace GECP_Front_End_Static.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {

            string email = common.GetEmailByDeptID(Convert.ToInt32(form["dept"]));
            StringBuilder collegemsg = new StringBuilder();

            collegemsg.AppendFormat("Hi...<br/>");
            collegemsg.AppendFormat("<br/>You have contacted us!<br/> Please check the details");

            collegemsg.AppendFormat("<table>");
            collegemsg.AppendFormat("<tr><td>Name</td><td>&nbsp;&nbsp;&nbsp;{0}</td>", form["name"]);
            collegemsg.AppendFormat("<tr><td>Phone</td><td>&nbsp;&nbsp;&nbsp;{0}</td>", form["phone"]);
            collegemsg.AppendFormat("<tr><td>Subject</td><td>&nbsp;&nbsp;&nbsp;{0}</td>", form["subject"]);
            collegemsg.AppendFormat("<tr><td>Message</td><td>&nbsp;&nbsp;&nbsp;{0}</td>", form["message"]);
            collegemsg.AppendFormat("</table>");

            StringBuilder studntmsg = new StringBuilder();

            studntmsg.AppendFormat("Hi {0}", form["name"]);
            studntmsg.AppendFormat("<br/>We have received your contact request.");
            studntmsg.AppendFormat("<br/>We will contact back soon.<br/>");
            studntmsg.AppendFormat("<br/><br/>");
            studntmsg.AppendFormat("Thank you");
            studntmsg.AppendFormat("<br/>GEC Patan");

            var flag = Email.SendEmail(form["email"], form["subject"] + " " + form["name"], studntmsg.ToString(), "jspatel19264@gmail.com");
            var flag1 = Email.SendEmail("jspatel19264@gmail.com", "Contact Request [" + form["subject"] + "_" + form["name"] + "]", collegemsg.ToString(), form["email"]);
            return Json(true);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}