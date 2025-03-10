﻿using System.Collections.Generic;

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
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public IList<PlaementDataYearWiseVM> Data { get; set; }
        public IList<BranchWisePercentage> Pie { get; set; }

        public PlacementDataVM()
        {
            Data = new List<PlaementDataYearWiseVM>();
            Pie = new List<BranchWisePercentage>();
        }
       
    }

    public class PlacementTeamVM
    {
        public int ID { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Pic { get; set; }
    }

    public class PlacementPageData
    {
        public IList<PlacementDataVM> PlacementDataVMs { get; set; }
        public IList<PlacementTeamVM> PlacementTeamVMs { get; set; }

        public PlacementPageData()
        {
            PlacementDataVMs = new List<PlacementDataVM>();
            PlacementTeamVMs = new List<PlacementTeamVM>();
        }
    }

    public class PlacementPieChart
    {
        public int ID { get; set; }
        public string year { get; set; }
        public IList<BranchWisePercentage> Data { get; set; }

        public PlacementPieChart()
        {
            Data=new List<BranchWisePercentage>();
        }
    }

    public class BranchWisePercentage
    {
        public string year { get; set; }
        public float Percentage { get; set; }

        public string BranchName { get; set; }
    }
}
