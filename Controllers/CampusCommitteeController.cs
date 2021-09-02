using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GECP_Front_End_Static.Controllers
{
    public class CampusCommitteeController : Controller
    {
        public IActionResult WomenCell()
        {
            return View(); 
        }
        public IActionResult SSIP()
        {
            return View();
        }
        public IActionResult NSS()
        {
            return View();
        }
        public IActionResult AntiRagging()
        {
            return View();
        }
        public IActionResult Grievence()
        {
            return View();
        }
        public IActionResult PlacementCell()
        {
            return View();
        }
    }
}
