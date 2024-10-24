using System;

namespace GECP_Front_End_Static.Models
{
    public class AcademicCal
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsFile { get; set; }
        public string File { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public DateTime Date { get; set; }
    }

}
