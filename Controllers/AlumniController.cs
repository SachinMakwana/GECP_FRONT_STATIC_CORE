using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GECP_Front_End_Static.Controllers
{
    public class AlumniController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
