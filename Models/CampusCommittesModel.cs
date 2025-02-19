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
        public List<string> Vision { get; set; }
        public List<string> Mission { get; set; }
        public List<string> SubObjectives { get; set; }
        public string SubObjImg { get; set; }
        public List<string> BulletPoints { get; set; }
        public string BulletPointsImg { get; set; }
        public string PageFlyer { get; set; }
        public string Tagline { get; set; }
        public string BlogLink { get; set; }
        public List<Members> Members { get; set; }
        public List<CommitteeActivity> Activities { get; set; }
    }

    public class CommitteeActivity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public List<File> Files { get; set; }
        public List<string> Images { get; set; }
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
}
