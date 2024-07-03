using CARS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Dao
{
    public interface ICrimeAnalysisService
    {
        int GetLatestID(string columnName, string tableName);
        (bool, int) victimAlreadyExists(Victims victims);
        int createVictim(Victims victims);
        (bool, int) suspectAlreadyExists(Suspects suspects);
        int createSuspect(Suspects suspects);
        bool createIncident(Incidents incident);
        bool updateIncidentStatus(string status, int incidentId);
        ICollection<Incident> getIncidentsInDateRange(string startDate, string endDate);
        ICollection<Incident> searchIncidents(IncidentType criteria);
        Report generateIncidentReport(Incident incident);
        Case createCase(string caseDescription, ICollection<Incident> incidents);
        Case getCaseDetails(int caseId);
        bool updateCaseDetails(Case updatedCase);
        List<Case> GetAllCases();
        void DisplayAllCases();
        public class Incident
        {
            public int IncidentID { get; set; }
            public string IncidentType { get; set; }
            public string IncidentDate { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
            public int VictimID { get; set; }
            public int SuspectID { get; set; }
            
            public int ReportID { get; set; }
            public int ReportingOfficer {  get; set; }
            public string ReportDate { get; set; }
            public string ReportDetails { get; set; }
            public string ReportStatus { get; set; }
            public int CaseID { get; set; }

            public void PrintIncident(Incident incident)
            {
                Console.WriteLine($"IncidentID: {incident.IncidentID}");
                Console.WriteLine($"IncidentType: {incident.IncidentType}");
                Console.WriteLine($"IncidentDate: {incident.IncidentDate}");
                Console.WriteLine();
            }

        }

        public enum IncidentType
        {
            Robbery,
            Arson,
            Theft,
            Homicide,
            Assault,
            Burglary,
            Vandalism,
            Kidnapping, 
            Fraud,
            Forgery, 
            Extortion,
            Harassment,
            Stalking,
            Blackmail
        }

        public class Report
        {
            public int ReportID { get; set; }
            public int IncidentID { get; set; }
            public int ReportingOfficer { get; set; }
            public string ReportDate { get; set; }
            public string ReportDetails { get; set; }
            public string ReportStatus { get; set; }
        }

        public class Case
        {
            public int CaseID { get; set; }
            public int IncidentType { get; set; }
            public string Description { get; set;}
            public string Status { get; set; }
        }
    }
}
