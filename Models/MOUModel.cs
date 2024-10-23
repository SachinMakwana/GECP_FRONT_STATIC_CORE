namespace GECP_Front_End_Static.Models
{
       public class MOUModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
    }

    public class NewsLettersModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
        public string download_name { get; set; }
        public string Thumb { get; set; }
    }
}
