using CARS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CARS.Dao.ICrimeAnalysisService;

namespace CARS.Dao
{
    public interface ICrudFunctions
    {
        ICollection<Incident> displayAllIncidents();
        bool updateIncidentsAttribute(int incidentID, string attributeName, string attributeValue);
        bool updateIncidentsAttribute(int incidentID, string attributeName, int attributeValue);
        bool updateIncidentsAttribute(int incidentID, string attributeName, double attributeValue1, double attributeValue2);
        bool deleteIncidents(int incidentID);


        ICollection<Victims> displayAllVictims();
        bool updateVictimAttribute(int victimID, string attributeName, int attributeValue);
        bool updateVictimAttribute(int victimID, string attributeName, string attributeValue);
        bool deleteVictim(int victimID);



        ICollection<Suspects>  displayAllSuspects();
        bool updateSuspectAttribute(int suspectID, string attributeName, string attributeValue);
        bool deleteSuspect(int suspectID);



        ICollection<LawEnforcementAgencies>  displayAllAgencies();
        bool updateAgenciesAttribute(int agencyID, string attributeName, string attributeValue);
        bool updateAgenciesAttribute(int agencyID, string attributeName, int attributeValue);
        bool deleteAgencies(int AgencyID);



        ICollection<Officers>  displayAllOfficers();
        bool updateOfficersAttribute(int officerID, string attributeName, string attributeValue);
        bool updateOfficersAttribute(int officerID, string attributeName, int attributeValue);
        bool deleteOfficers(int OfficerID);



        ICollection<Evidence>  displayAllEvidence();
        bool updateEvidenceAttribute(int evidenceID, string attributeName, string attributeValue);
        bool updateEvidenceAttribute(int evidenceID, string attributeName, int attributeValue);
        bool updateEvidenceAttribute(int incidentID, string attributeName, double attributeValue1, double attributeValue2);
        bool deleteEvidence(int EvidenceID);



        ICollection<Reports>  displayAllReports();
        bool updateReportsAttribute(int reportID, string attributeName, string attributeValue);
        bool updateReportsAttribute(int reportID, string attributeName, int attributeValue);
        bool deleteReports(int ReportID);


        ICollection<Cases> getAllCases();
        Cases createCase(Incident incident);
        Cases getCaseDetails(int caseID);
        bool updateCasesDetails(int caseID, string attributeName, string attributeValue);
        bool updateCasesDetails(int caseID, string attributeName, int attributeValue);
        bool deleteCases(int caseID);

    }
}
