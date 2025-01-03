﻿using System.Collections.Generic;
namespace GECP_Front_End_Static.Models
{
    public class DepartmentVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string TitleImage { get; set; }
        public string TitleImageCSSClass { get; set; }
        public string About { get; set; }
        public List<string> About_Images { get; set; }
        public int Intake { get; set; }
        public int FacultyCount { get; set; }
        public int AnnualPlacementCount { get; set; }
        public int LabWorkshop { get; set; }
        public List<string> Vision { get; set; }
        public List<string> Mission { get; set; }
        public string HODMessage { get; set; }
        public string HODName { get; set; }
        public string HOD_Pic { get; set; }
        public string Tagline { get; set; }
        public bool showIntake { get; set; }
        public List<FacultyDetailsVM> FacultyList { get; set; } = new List<FacultyDetailsVM>();
    }
}
