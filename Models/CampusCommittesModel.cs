using Newtonsoft.Json;
using System.Collections.Generic;

namespace GECP_Front_End_Static.Models
{
    public class CampusCommittesModel
    {
    }

    public class Members
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Department { get; set; }
    }

    public class CampusCommittesVM
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
        public List<string> SubObjectives { get; set; } = new List<string>();
        public string SubObjImg { get; set; }
        public List<string> BulletPoints { get; set; } = new List<string>();
        public string BulletPointsImg { get; set; }
        public string PageFlyer { get; set; }
        public string Tagline { get; set; }
        public string BlogLink { get; set; }

		public string Link { get; set; }

		public List<Members> Members { get; set; }= new List<Members>();
        public List<CommitteeActivity> Activities { get; set; } = new List<CommitteeActivity>();
        public List<AdditionalMembers> AdditionalMembers { get; set; } = new List<AdditionalMembers>();
    		public List<AchievementsVM> Achievements { get; set; } = new List<AchievementsVM>();
        public bool ShowDocument { get; set; } = false;
        public TabTitles TabTitles { get; set; } = new TabTitles();
        public bool TableView { get; set; } = false;
    }


    public class AdditionalMembers
    {
        public string CommitteeTitle { get; set; }
        public List<Members> Members { get; set; } = new List<Members>();
    }

    public class CommitteeActivity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public int Year { get; set; } 
        public List<File> Files { get; set; } = new List<File>();
        public List<string> Images { get; set; } = new List<string>();
        public int DeptID { get; set; }
        public int CommitteId { get; set; }
        public string Keywords { get; set; }

        public bool IsFile { get; set; } = true;
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ExternalLink { get; set; }
        public string PageID { get; set; }
    }

    public class File
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
    }

    public class TabTitles
    {
        public string About { get; set; } = "About";
        public string VisionMission { get; set; } = "Vision & Mission";
        public string SubObjectives { get; set; } = "Sub Objectives";
        public string Procedure { get; set; } = "Procedure";
        public string Members { get; set; } = "Members";
        public string Activities { get; set; } = "Activities";
        public string Blogspot { get; set; } = "Blogspot";
        public string Documents { get; set; } = "Documents";

		public string Link { get; set; } = "Register Grievance";
	}

}
