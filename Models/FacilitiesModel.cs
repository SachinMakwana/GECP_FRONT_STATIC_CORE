using System.Collections.Generic;
using System.Diagnostics;

namespace GECP_Front_End_Static.Models
{
    public class FacilitiesModel
    {
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    //public class Members
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public string Position { get; set; }
    //    public string Department { get; set; }
    //    public string Image { get; set; }
    //    public string Email { get; set; }
    //}

    public class Factor
    {
        public string Name { get; set; }
        public string Rooms { get; set; }
        public string Capacity { get; set; }
        public string Mess { get; set; }
        public string TTHall { get; set; }
        public string Hall { get; set; }
    }

    public class Hostel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string TitleImage { get; set; }
        public string TitleImageCSSClass { get; set; }
        public string SideImage { get; set; }
        public string BlogLink { get; set; }
        public string Tagline { get; set; }
        public List<string> Vision { get; set; }
        public List<string> Mission { get; set; }
        public string PageFlyer { get; set; }
        public string About { get; set; }
        public Factor Factors { get; set; }
        public List<Members> Members { get; set; }
    }

    public class Club
    {
        public int ID { get; set; }
        public string Icon { get; set; }
        public List<string> Images { get; set; }
        public string About { get; set; }
        public string Title { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public bool IsDynamic { get; set; }
        public int? dynamicID { get; set; }
        public List<Members> Members { get; set; }
        public List<string> SubObjectives { get; set; }
        public string BlogLink { get; set; }
        public List<CommitteeActivity> Activities { get; set; }

    }

	public class Student
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Titleimage { get; set; }
        public string TitleImageCSSClass { get; set; }
        public List<Club> Clubs { get; set; }
    }
    public class Medical
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Titleimage { get; set; }
        public string TitleImageCSSClass { get; set; }
        public List<string> Descriptions { get; set; }
    }
    
    public class Library
    {
        public string Title { get; set; }
        public string Titleimage { get; set; }
        public string TitleImageCSSClass { get; set; }
        public string Content { get; set; }
		public List<string> Vision { get; set; }
		public List<string> Mission { get; set; }
		public string Books { get; set; }
        public string Periodicals { get; set; }
        public string Reports { get; set; }
        public string Biography { get; set; }
		public string TagLine { get; set; }
        public List<Members> Members { get; set; }
    }

	//public class Member2
	//{
	//    public int ID { get; set; }
	//    public string Name { get; set; }
	//    public string Position { get; set; }
	//    public string Department { get; set; }
	//    public string Image { get; set; }
	//    public string Email { get; set; }

	//}
	public class Benefit
	{
		public string Icon { get; set; }
		public string Time { get; set; }
		public string Text { get; set; }
	}

	public class COE
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
        public List<Members> Members { get; set; } = new List<Members>();
        public List<CommitteeActivity> Activities { get; set; } = new List<CommitteeActivity>();
        public List<AdditionalMembers> AdditionalMembers { get; set; } = new List<AdditionalMembers>();
        public List<AchievementsVM> Achievements { get; set; } = new List<AchievementsVM>();
        public bool ShowDocument { get; set; } = false;
        public TabTitles TabTitles { get; set; } = new TabTitles();
        public List<Benefit> Benefits { get; set; } = new List<Benefit>();
        public List<Labs> Labs { get; set; } = new List<Labs>();
    }

}