using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class LawEnforcementAgencies
    {
        public int AgencyID { get; set; }
        public string? AgencyName { get; set; }
        public string? Jurisdiction { get; set; }
        public string? ContactInformation { get; set; }
        public int OfficerID { get; set; }

        public LawEnforcementAgencies() { }

        public LawEnforcementAgencies(int agencyID, string agencyName, string jurisdiction, string contactInformation, int officerID)
        {
            AgencyID = agencyID;
            AgencyName = agencyName;
            Jurisdiction = jurisdiction;
            ContactInformation = contactInformation;
            OfficerID = officerID;
        }
    }
}
