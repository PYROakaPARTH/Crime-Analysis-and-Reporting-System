using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Incidents
    {
        //public int IncidentID { get;  set; }
        public string? IncidentType { get; set; }
        public string? IncidentDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int VictimID { get; set; }
        public int SuspectId  { get; set; }

        public Incidents()
        {
        }

        public Incidents(string incidentType, string incidentDate, double latitude, double longitude, string description, string status, int victimID, int suspectID)
        {
            IncidentType = incidentType;
            IncidentDate = incidentDate;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Status = status;
            VictimID = victimID;
            SuspectId = suspectID;

        }
    }
}
