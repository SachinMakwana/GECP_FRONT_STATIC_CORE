using System.Collections.Generic;

namespace GECP_Front_End_Static.Models
{
    public class DocumentsModel
    {
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Document
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
        public bool isShow { get; set; }
        public string FileType { get; set; }

		public string FilePath { get; set; }
		public string UploadDate { get; set; }
        public string MonthYear { get; set; } = "";
    }

    public class DocumentsVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<YearSection> YearSection { get; set; }
    }

    public class YearSection
    {
        public string Year { get; set; }
        public int Order { get; set; } = 0;
        public bool isShow { get; set; } = true;
        public List<Document> Documents { get; set; } = new List<Document>();
    }


}
