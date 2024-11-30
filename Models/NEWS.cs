using System.Collections.Generic;

namespace GECP_Front_End_Static.Models
{
    public class NEWSModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsFile { get; set; }
        public string FileLink { get; set; }
        public string BannerImage { get; set; }
        public string date { get; set; }
        public string Thumbnail { get; set; }
        public List<string> Images { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
    }
}
