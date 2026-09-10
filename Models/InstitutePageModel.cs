using System.Collections.Generic;

namespace GECP_Front_End_Static.Models
{
    public class MOUModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }

        public string MonthYear { get; set; } = "";
    }

    public class TendersVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
        public string UploadDate { get; set; }
        public bool isShow { get; set; }
    }

    public class NewsLettersModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
        public string download_name { get; set; }
        public string Thumb { get; set; }
    }

    public class AboutUsVM
    {
        public string Title { get; set; } = "About Us";
        public string History { get; set; }
        public List<string> ImagePaths { get; set; }
        public string PrincipalName { get; set; }
        public string PrincipalDesignation { get; set; }
        public string PrincipalMessage { get; set; }
        public string PrincipalPhoto { get; set; }
        public List<string> Vision { get; set; }
        public List<string> Mission { get; set; }
        public IList<ProgramInfo> Departments { get; set; }
        public AboutUsVM()
        {
            Departments = new List<ProgramInfo>();
        }
    }

    public class ProgramInfo
    {
        public string ProgramName { get; set; }
        public int Intake { get; set; }
        public string CourseCode { get; set; }

        public string Accreditation { get; set; }

        public int DepartmentID { get; set; }
        public string Icon { get; set; }
        public bool showIntake { get; set; }
    }
}
