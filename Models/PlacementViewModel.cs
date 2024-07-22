using System.Collections.Generic;

namespace GECP_Front_End_Static.Models
{
    public class PlacementViewModel
    {
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class PlaementDataYearWiseVM
    {
        public string Year { get; set; }
        public int Passout { get; set; }
        public int Placed { get; set; }
        public int AverageCTC { get; set; }
        public int HigherStudy { get; set; }
        public int Business { get; set; }
        public double PlacementPercentage { get; set; }
        public bool IsDisplay { get; set; }
    }

    public class PlacementDataVM
    {
        public string BranchID { get; set; }
        public string BranchName { get; set; }
        public List<PlaementDataYearWiseVM> Data { get; set; }
    }


}
