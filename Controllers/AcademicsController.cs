﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GECP_Front_End_Static.Controllers
{
    public class AcademicsController : Controller
    {
        public IActionResult AcademicCalender()
        {
            return View();
        }

        public IActionResult AdmissionProcess()
        {
            return View();
        }

        public IActionResult Achievements()
        {
            return View();
        }
    }
}
