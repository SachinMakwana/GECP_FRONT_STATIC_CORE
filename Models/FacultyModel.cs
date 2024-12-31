using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GECP_Front_End_Static.Models
{
    public class Tabs
    {
        public Tabs()
        {
            Head = new List<string>();
            Values = new List<string>();
        }
        public List<string> Head { get; set; }
        public List<string> Values { get; set; }
    }

    public class FacultyDetailsVM
    {
        public FacultyDetailsVM()
        {
            Dept_ID = 0;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string image { get; set; }
        public DateTime Date_of_Joining { get; set; }
        public string Qualification { get; set; }
        public string Area_of_Interest { get; set; }

        public string personal_details { get; set; }
        public int YearsOfExperience
        {
            get
            {
                var today = DateTime.Today;
                int years = today.Year - Date_of_Joining.Year;
                if (Date_of_Joining > today.AddYears(-years)) years--;
                return years;
            }
        }
        public int Dept_ID { get; set; }
        public Tabs tabs { get; set; }
    }

    public class FacultiesVM
    {
        public FacultiesVM()
        {
            FacultyList = new List<FacultyDetailsVM>();
        }
        public IList<FacultyDetailsVM> FacultyList { get; set; }
    }

}
