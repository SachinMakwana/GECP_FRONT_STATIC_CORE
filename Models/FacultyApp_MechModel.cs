using Newtonsoft.Json;
using System.Collections.Generic;

namespace GECP_Front_End_Static.Models
{
   
    public class FacultyApp_MechModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }

        public string image { get; set; }
        public string Experience { get; set; }

        [JsonProperty("Area of Interest")]
        public string AreaofInterest { get; set; }
    }

}
