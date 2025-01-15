using System.Collections.Generic;

namespace GECP_Front_End_Static.Models
{
    public class FacultyData
    {
        public PersonalDetails PersonalDetails { get; set; }
        public List<EducationalQualification> EducationalQualifications { get; set; }
        public List<ProfessionalExperience> ProfessionalExperiences { get; set; }
        public List<TrainingAndWorkshop> TrainingAndWorkshops { get; set; }
        public List<Publication> Publications { get; set; }
    }

    public class PersonalDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string image { get; set; }

        public string YearsOfExperience { get; set; }

        public string Area_of_Interest { get; set; }
        public string Qualification { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
    }

    public class EducationalQualification
    {
        public string Degree { get; set; }
        public string University { get; set; }
        public string Year { get; set; }
        public string Specialization { get; set; }
    }

    public class ProfessionalExperience
    {
        public string Position { get; set; }
        public string Organization { get; set; }
        public string Duration { get; set; }
    }

    public class TrainingAndWorkshop
    {
        public string Title { get; set; }
        public string OrganizedBy { get; set; }
        public string Date { get; set; }
    }

    public class Publication
    {
        public int SrNo { get; set; }
        public string Title { get; set; }
    }

}
