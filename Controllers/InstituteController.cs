using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GECP_Front_End_Static.Controllers
{
    public class InstituteController : Controller
    {
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
            return View();
        }

        public IActionResult Tenders()
        {
            return View();
        }

        public IActionResult ImportantDocuments()
        {
            return View();
        }

        public IActionResult RTI()
        {
            return View();
        }
    }
}
