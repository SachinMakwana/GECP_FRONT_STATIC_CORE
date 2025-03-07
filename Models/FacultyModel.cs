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
        public bool IsTeaching { get; set; }

        public string personal_details { get; set; }

        public string url { get; set; }
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

        public PersonalDetails PersonalDetails { get; set; } = new PersonalDetails();
        public List<EducationalQualification> EducationalQualifications { get; set; }= new List<EducationalQualification>();
        public List<ProfessionalExperience> ProfessionalExperiences { get; set; }=new List<ProfessionalExperience>();
        public List<TrainingAndWorkshop> TrainingAndWorkshops { get; set; }=new List<TrainingAndWorkshop>();
        public List<Publication> Publications { get; set; } =new List<Publication>();

        public int SeniorityOrder { get; set; } = 0;
    }

    public class PersonalDetails
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
    }

    public class EducationalQualification
    {
        public string Degree { get; set; }
        public string University { get; set; }
        public string Year { get; set; }
        public string Specialization { get; set; }
    }

    public class ProfessionalExperience
    {
        public string Position { get; set; }
        public string Organization { get; set; }
        public string Duration { get; set; }
    }

    public class TrainingAndWorkshop
    {
        public string Title { get; set; }
        public string OrganizedBy { get; set; }
        public string Date { get; set; }
    }

    public class Publication
    {
        public int SrNo { get; set; }
        public string Title { get; set; }
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