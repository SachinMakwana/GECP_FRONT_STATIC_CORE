using Newtonsoft.Json;
using System.Collections.Generic;

namespace GECP_Front_End_Static.Models
{
    public class PlacementCell
    {
    }

    public class PlacementCellContent
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string TitleImage { get; set; }
        public string TitleImageCSSClass { get; set; }
        public string About { get; set; }
        public List<string> Vision { get; set; } = new List<string>();
        public List<string> Mission { get; set; } = new List<string>();
        public List<string> Objectives { get; set; }
        public FunctionTNPCell Functions { get; set; }

        public PlacementStatistics Statistics { get; set; }

        public List<PlacementActivity> ActivitiesCalendar { get; set; }

        public StudentPolicy StudentPlacementPolicy { get; set; }

        public RecruiterInfo RecruiterDetails { get; set; }

        public string SuccessStoriesNote { get; set; }

        public ContactInfo Contact { get; set; }

        public List<Members> Team { get; set; }
    }

    public class PlacementStatistics
    {
        public string Description { get; set; } // Placeholder since table was empty
        public int TotalRecruitersVisited { get; set; }
        public List<string> TopRecruiters { get; set; }
    }

    public class PlacementActivity
    {
        public int SrNo { get; set; }
        public string ActivityName { get; set; }
        public string Period { get; set; }
        public string TargetStudents { get; set; }
        public string ReportLink { get; set; }
    }

    public class StudentPolicy
    {
        public string PolicyText { get; set; }
        public string InternshipInstructions { get; set; }
        public string DressCode { get; set; }
        public string OfferLetterPolicy { get; set; }
        public List<string> Downloads { get; set; }
    }

    public class RecruiterInfo
    {
        public string Content { get; set; }
        public List<ProgramInfo> Courses { get; set; }
        public string WhyRecruitFromUs { get; set; }
        public string PlacementPolicy { get; set; }
        public string BrochureLink { get; set; }
        public string BrochureText { get; set; }
        public string ProposalFormLink { get; set; }
        public string Email { get; set; }
    }

    public class FunctionTNPCell
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> FunctionsInform { get; set; }
        public List<string> FunctionsPrepare { get; set; }
        public List<string> FunctionsOrganize { get; set; }
    }

    public class ContactInfo
    {
        public string Address { get; set; }
        public string Email { get; set; }
    }
}