﻿namespace GECP_Front_End_Static.Models
{
       public class MOUModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }

        public string MonthYear { get; set; } = "";
    }

    public class TendersVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
        public string UploadDate { get; set; }
        public bool isShow { get; set; }
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
