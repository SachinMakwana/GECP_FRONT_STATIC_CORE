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
        public string Measures { get; set; }
        public string Measure_Image { get; set; }
        public List<string> Vision { get; set; } = new List<string>();
        public List<string> Mission { get; set; } = new List<string>();
        public List<string> Objectives { get; set; }
        public FunctionTNPCell Functions { get; set; }
        public List<PlacementStatistics> Statistics { get; set; }
        public List<Recruiter> TopRecruiters { get; set; }
        public List<CommitteeActivity> ActivitiesCalendar { get; set; }

        public StudentPolicy StudentPolicy { get; set; }

        public RecruiterInfo RecruiterDetails { get; set; }

        public string SuccessStoriesNote { get; set; }

        public ContactInfo Contact { get; set; }

        public List<Members> Team { get; set; }

        public bool TableView { get; set; } = false;
        public bool TopRecruitersTableView { get; set; } = false;
        public bool PlacementTeamTabelView { get; set; } = false;
    }

    public class PlacementStatistics
    {
        public string Department { get; set; }
        public List<Graph> Graphs { get; set; }
    }
    public class Graph
    {
        public string Year { get; set; }
        public string Image { get; set; }
    }
    public class Recruiter
    {
        public int SrNo { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }
    }

    public class StudentPolicy
    {
        public List<string> PolicyText { get; set; }
        public List<string> InternshipOffers { get; set; }
        public List<string> DressCode { get; set; }
        public List<string> OfferLetterPolicy { get; set; }
        public List<DownloadItem> Downloads { get; set; }
    }
    public class DownloadItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public class RecruiterInfo
    {
        public string Content { get; set; }
        public List<ProgramInfo> Courses { get; set; }
        public List<string> WhyRecruitFromUs { get; set; }
        public List<string> PlacementPolicy { get; set; }
        public string BrochureLink { get; set; }
        public string ProposalInstruction { get; set; }
        public string ProposalFormLink { get; set; }
        public string Email { get; set; }
    }

    public class FunctionTNPCell
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
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