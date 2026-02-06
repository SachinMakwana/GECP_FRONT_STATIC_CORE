using System.Collections;
using System.Collections.Generic;

namespace GECP_Front_End_Static.Models
{
    public class MarqueeModelVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsFile { get; set; }
        public string FileLink { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
   
    public class ActivityMarqueeModelVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsFile { get; set; }
        public string FileLink { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }

    public class TestimonialModelVM
    {
        public int ID { get; set; }
        public string StudentName { get; set; }
        public string Department { get; set; }
        public string PassoutYear { get; set; }
        public string Testimonial { get; set; }
    }

    public class MasterSliderVM
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string H3_text { get; set; }
        public string H4_text { get; set; }
        public string H5_text { get; set; }
        public string Anchor1_text { get; set; }
        public string Anchor1_Link { get; set; }
        public string Anchor2_text { get; set; }
        public string Anchor2_Link { get; set; }
        public bool isShow {  get; set; }
    }

    public class HomePageModelVM
    {
        public IList<MarqueeModelVM> marqueeModelVM { get; set; }

        public IList<CommitteeActivity> activitymarqueeModelVM { get; set; }
        public IList<TestimonialModelVM> testimonialModelVM { get; set; }

        public IList<NEWSModel> newsModelVM { get; set; }

        public IList<MasterSliderVM> masterSliderVM { get; set; }

        public HomePageModelVM()
        {
            marqueeModelVM = new List<MarqueeModelVM>();
            activitymarqueeModelVM = new List<CommitteeActivity>();
            testimonialModelVM = new List<TestimonialModelVM>();
            newsModelVM = new List<NEWSModel>();
            masterSliderVM = new List<MasterSliderVM>();
        }
    }

    public class MenuVM
    {
        public int ID { get; set; }
        public string MenuText { get; set; }
        public int? ParentID { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int position { get; set; }
        public bool isVisible { get; set; } = true;
        public int? dynamicID { get; set; }
        public string Link { get; set; }
        public string Color { get; set; }
        public string ColorFont { get; set; }
        public List<MenuVM> ChildMenuVMs { get; set; } = new List<MenuVM>();

    }

    public class HeaderVM
    {
        public List<MenuVM> MenuVMs { get; set; } = new List<MenuVM>();
        public string ContactNo { get; set; }
        public string ContactEmail { get; set; }
        public string logo { get; set; }
    }
}
