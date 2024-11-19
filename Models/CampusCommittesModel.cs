using Newtonsoft.Json;
using System.Collections.Generic;

namespace GECP_Front_End_Static.Models
{
    public class CampusCommittesModel
    {
    }

    public class Member
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
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
        public List<Member> Members { get; set; }
    }
}
