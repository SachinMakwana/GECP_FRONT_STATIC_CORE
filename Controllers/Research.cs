using Microsoft.AspNetCore.Mvc;

namespace GECP_Front_End_Static.Controllers
{
    public class Research : Controller
    {
        public IActionResult DesignLab()
        {
            return View();
        }

        public IActionResult CoursesAndIntake() 
        {
            return View();
        }
    }
}
