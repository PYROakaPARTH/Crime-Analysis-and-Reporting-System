using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Cases
    {
        public int CaseID { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int IncidentID { get; set; }

        public Cases() { }
        public Cases(int caseID, string description, string status, int incidentID)
        {
            CaseID = caseID;
            Description = description;
            Status = status;
            IncidentID = incidentID;
        }
    }
}