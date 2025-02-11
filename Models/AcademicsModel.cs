namespace GECP_Front_End_Static.Models
{
    
    public class AchievementsVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
    public class AcademicCalendersVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
        public string UploadDate { get; set; }
        public bool isShow { get; set; }
    }
    public class SSIPDocumentsVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
        public string UploadDate { get; set; }
        public bool isShow { get; set; }
    }


    public class IntakeVM
    {
        public int EC { get; set; }
        public int Computer { get; set; }
        public int Electrical { get; set; }
        public int Civil { get; set; }
        public int Mechanical { get; set; }
    }
}
