using System.Collections.Generic;
namespace GECP_Front_End_Static.Models
{
    public class Administration
    {
    }

    public class CentralStoreVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string TitleImage { get; set; }
        public string About { get; set; }
        public string Logo { get; set; }
        public List<string> About_Images { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public string BlogLink { get; set; }
        public string Link { get; set; }
        public bool ShowDocument { get; set; } = false;
        public TabTitles TabTitles { get; set; } = new TabTitles();
    }
}
