using System;
using System.Collections.Generic;

namespace GECP_Front_End_Static.Models
{
    public class PrincipalViewModel
    {
        // Tab 1: Personal Details
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string AreaOfInterest { get; set; }
        public string Email { get; set; }

        public List<PrincipalMessage> PrincipalMessages { get; set; }

        // Tab 2: Educational Qualifications
        public List<EducationQualification> EducationalQualifications { get; set; }

        // Tab 3: Publications Summary
        public List<PublicationSummary> PublicationsSummary { get; set; }

        // Tab 4: Selected Publications
        public List<SelectedPublication> SelectedPublications { get; set; }

        // Tab 5: Experience
        public List<ExperienceDetail> Experiences { get; set; }

        // Tab 6: Achievements
        public List<string> Achievements { get; set; }

        // Tab 7: Book Publication
        public BookPublication Book { get; set; }

        // Tab 8: Expert Talks
        public List<ExpertTalk> ExpertTalks { get; set; }

        // Tab 9: Memberships
        public List<string> Memberships { get; set; }
    }

    // Supporting Models
    public class PrincipalMessage
    {
        public string Message { get; set; }         // For principal's message
        public string ImagePath { get; set; }       // For principal's photo (relative URL)

    }

    public class EducationQualification
    {
        public string Qualification { get; set; }
        public string University { get; set; }
        public string Year { get; set; }
        public string Result { get; set; }
    }

    public class PublicationSummary
    {
        public string Category { get; set; }
        public int Count { get; set; }
    }

    public class SelectedPublication
    {
        public string Title { get; set; }
        public string JournalOrConference { get; set; }
        public string Type { get; set; } // International Journal, Conference, etc.
    }

    public class ExperienceDetail
    {
        public string Designation { get; set; }
        public string DateOfJoining { get; set; }
        public string DateOfLeave { get; set; }
        public string Department { get; set; }
        public string Duration { get; set; }
        public string Place { get; set; }
    }

    public class BookPublication
    {
        public string Title { get; set; }
        public string BookCode { get; set; }
        public string University { get; set; }
        public string Branch { get; set; }
        public string Semester { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public List<string> ContentTopics { get; set; }
    }

    public class ExpertTalk
    {
        public string Year { get; set; }
        public string Subject { get; set; }
        public string Place { get; set; }
        public string Details { get; set; }
    }

}
