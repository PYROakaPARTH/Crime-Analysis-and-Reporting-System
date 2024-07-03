using CARS.Model;
using CARS.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static CARS.Dao.ICrimeAnalysisService;

namespace CARS.Dao
{
    public class CrudFunctionsImpl : ICrudFunctions
    {
        string ConString = PropertyUtil.getPropertyString();

        public ICollection<Incident> displayAllIncidents()
        {
            List<Incident> incidents = new List<Incident>();

            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT IncidentID, IncidentType, IncidentDate, CONCAT(Location.Long, ', ', Location.Lat) AS Location, Description, Status, VictimID, SuspectID FROM Incidents";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Incident incident = new Incident
                    {
                        IncidentID = Convert.ToInt32(reader["IncidentID"]),
                        IncidentType = reader["IncidentType"].ToString(),
                        IncidentDate = reader["IncidentDate"].ToString(),
                        Location = reader["Location"].ToString(),
                        Description = reader["Description"].ToString(),
                        Status = reader["Status"].ToString(),
                        VictimID = Convert.ToInt32(reader["VictimID"]),
                        SuspectID = Convert.ToInt32(reader["SuspectID"])
                    };
                    incidents.Add(incident);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }

            void PrintIncident(Incident incident)
            {
                Console.WriteLine($"IncidentID: {incident.IncidentID}");
                Console.WriteLine($"IncidentType: {incident.IncidentType}");
                Console.WriteLine($"IncidentDate: {incident.IncidentDate}");
                Console.WriteLine($"Location: {incident.Location}");
                Console.WriteLine($"Description: {incident.Description}");
                Console.WriteLine($"Status: {incident.Status}");
                Console.WriteLine($"VictimID: {incident.VictimID}");
                Console.WriteLine($"SuspectID: {incident.SuspectID}");
                Console.WriteLine();
            }


            foreach (var incident in incidents)
            {
                PrintIncident(incident);
            }
            return incidents;
        }

        public bool updateIncidentsAttribute(int incidentID, string attributeName, string attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Incidents SET {attributeName} = '{attributeValue}' WHERE IncidentID = {incidentID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Incident updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public bool updateIncidentsAttribute(int incidentID, string attributeName, int attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Incidents SET {attributeName} = {attributeValue} WHERE IncidentID = {incidentID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Incident updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public bool updateIncidentsAttribute(int incidentID, string attributeName, double attributeValue1, double attributeValue2)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Incidents SET {attributeName} = geography::Point({attributeValue1}, {attributeValue2}, 4326) WHERE IncidentID = {incidentID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Incident updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public bool deleteIncidents(int incidentID)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"DELETE FROM Incidents WHERE IncidentID = {incidentID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Incident deleted successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public ICollection<Victims> displayAllVictims()
        {
            List<Victims> victimsList = new List<Victims>();

            SqlConnection con = new SqlConnection(ConString);
            string queryString = "SELECT * FROM Victims";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Victims victimsObj = new Victims
                    {
                        VictimID = Convert.ToInt32(reader["VictimID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DateOfBirth = reader["DateOfBirth"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        ContactInformation = reader["ContactInformation"].ToString(),
                    };
                    victimsList.Add(victimsObj);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }

            void PrintVictims(Victims victimsObj)
            {
                Console.WriteLine($"VictimID: {victimsObj.VictimID}");
                Console.WriteLine($"FirstName: {victimsObj.FirstName}");
                Console.WriteLine($"LastName: {victimsObj.LastName}");
                Console.WriteLine($"DateOfBirth: {victimsObj.DateOfBirth}");
                Console.WriteLine($"Gender: {victimsObj.Gender}");
                Console.WriteLine($"ContactInformation: {victimsObj.ContactInformation}");
                Console.WriteLine();
            }


            foreach (var victimsObj in victimsList)
            {
                PrintVictims(victimsObj);
            }
            return victimsList;
        }

        public bool updateVictimAttribute(int victimID, string attributeName, int attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Victims SET {attributeName} = {attributeValue} WHERE VictimID = {victimID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Victim updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public bool updateVictimAttribute(int victimID, string attributeName, string attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Victims SET {attributeName} = '{attributeValue}' WHERE VictimID = {victimID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Victim updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public bool deleteVictim(int victimID)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"DELETE FROM Victims WHERE VictimID = {victimID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Incident deleted successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public ICollection<Suspects> displayAllSuspects()
        {
            List<Suspects> suspectsList = new List<Suspects>();

            SqlConnection con = new SqlConnection(ConString);
            string queryString = "SELECT * FROM Suspects";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Suspects suspectsObj = new Suspects
                    {
                        SuspectID = Convert.ToInt32(reader["SuspectID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DateOfBirth = reader["DateOfBirth"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        ContactInformation = reader["ContactInformation"].ToString(),
                    };
                    suspectsList.Add(suspectsObj);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }

            void PrintSuspects(Suspects suspectsObj)
            {
                Console.WriteLine($"VictimID: {suspectsObj.SuspectID}");
                Console.WriteLine($"FirstName: {suspectsObj.FirstName}");
                Console.WriteLine($"LastName: {suspectsObj.LastName}");
                Console.WriteLine($"DateOfBirth: {suspectsObj.DateOfBirth}");
                Console.WriteLine($"Gender: {suspectsObj.Gender}");
                Console.WriteLine($"ContactInformation: {suspectsObj.ContactInformation}");
                Console.WriteLine();
            }


            foreach (var suspectsObj in suspectsList)
            {
                PrintSuspects(suspectsObj);
            }
            return suspectsList;
        }

        public bool updateSuspectAttribute(int suspectID, string attributeName, string attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Suspects SET {attributeName} = '{attributeValue}' WHERE SuspectID = {suspectID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Suspect updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public bool deleteSuspect(int suspectID)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"DELETE FROM Victims WHERE VictimID = {suspectID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Suspect deleted successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public ICollection<LawEnforcementAgencies> displayAllAgencies()
        {
            List<LawEnforcementAgencies> lawEnforcementAgenciesList = new List<LawEnforcementAgencies>();

            SqlConnection con = new SqlConnection(ConString);
            string queryString = "SELECT * FROM LawEnforcementAgencies";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LawEnforcementAgencies lawEnforcementAgenciesObj = new LawEnforcementAgencies
                    {
                        AgencyID = Convert.ToInt32(reader["AgencyID"]),
                        AgencyName = reader["AgencyName"].ToString(),
                        Jurisdiction = reader["Jurisdiction"].ToString(),
                        ContactInformation = reader["ContactInformation"].ToString(),
                        OfficerID = Convert.ToInt32(reader["OfficerID"])
                    };
                    lawEnforcementAgenciesList.Add(lawEnforcementAgenciesObj);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }

            void PrintAgencies(LawEnforcementAgencies lawEnforcementAgenciesObj)
            {
                Console.WriteLine($"Agency ID: {lawEnforcementAgenciesObj.AgencyID}");
                Console.WriteLine($"Agency Name: {lawEnforcementAgenciesObj.AgencyName}");
                Console.WriteLine($"Jurisdiction: {lawEnforcementAgenciesObj.Jurisdiction}");
                Console.WriteLine($"Contact Information: {lawEnforcementAgenciesObj.ContactInformation}");
                Console.WriteLine($"Officer ID: {lawEnforcementAgenciesObj.OfficerID}");
                Console.WriteLine();
            }


            foreach (var lawEnforcementAgenciesObj in lawEnforcementAgenciesList)
            {
                PrintAgencies(lawEnforcementAgenciesObj);
            }
            return lawEnforcementAgenciesList;
        }

        public bool updateAgenciesAttribute(int agencyID, string attributeName, string attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE LawEnforcementAgencies SET {attributeName} = '{attributeValue}' WHERE AgencyID = {agencyID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Law Enforcement Agency updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public bool updateAgenciesAttribute(int agencyID, string attributeName, int attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE LawEnforcementAgencies SET {attributeName} = {attributeValue} WHERE AgencyID = {agencyID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Law Enforcement Agency updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
        public bool deleteAgencies(int AgencyID)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"DELETE FROM LawEnforcementAgencies WHERE AgencyID = {AgencyID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Agency deleted successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public ICollection<Officers> displayAllOfficers()
        {
            List<Officers> officersList = new List<Officers>();

            SqlConnection con = new SqlConnection(ConString);
            string queryString = "SELECT * FROM Officers";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Officers officersObj = new Officers
                    {
                        OfficerID = Convert.ToInt32(reader["OfficerID"]),
                        FirstName = reader["FisrtName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        BadgeNumber = Convert.ToInt32(reader["BadgeNumber"]),
                        Rank = reader["Rank"].ToString(),
                        ContactInformation = reader["ContactInfo"].ToString(),
                        AgencyID = Convert.ToInt32(reader["AgencyID"])
                    };
                    officersList.Add(officersObj);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }

            void PrintOfficers(Officers officersObj)
            {
                Console.WriteLine($"Officer ID: {officersObj.OfficerID}");
                Console.WriteLine($"Fisrt Name: {officersObj.FirstName}");
                Console.WriteLine($"Last Name: {officersObj.LastName}");
                Console.WriteLine($"Badge Number: {officersObj.BadgeNumber}");
                Console.WriteLine($"BadgeNumber: {officersObj.BadgeNumber}");
                Console.WriteLine($"Contact Information: {officersObj.ContactInformation}");
                Console.WriteLine($"Officer ID: {officersObj.OfficerID}");
                Console.WriteLine();
            }


            foreach (var officersObj in officersList)
            {
                PrintOfficers(officersObj);
            }
            return officersList;
        }
        public bool updateOfficersAttribute(int officerID, string attributeName, string attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Officers SET {attributeName} = '{attributeValue}' WHERE OfficerID = {officerID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Officer updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public bool updateOfficersAttribute(int officerID, string attributeName, int attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Officers SET {attributeName} = {attributeValue} WHERE OfficerID = {officerID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Officer updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
        public bool deleteOfficers(int OfficerID)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"DELETE FROM Officers WHERE OfficerID = {OfficerID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Officer deleted successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public ICollection<CARS.Model.Evidence> displayAllEvidence()
        {
            List<CARS.Model.Evidence> evidenceList = new List<CARS.Model.Evidence>();

            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT EvidenceID, Description, CONCAT(LocationFound.Long, ', ', LocationFound.Lat) AS LocationFound, IncidentID FROM Evidence";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CARS.Model.Evidence evidence = new CARS.Model.Evidence
                    {
                        EvidenceID = Convert.ToInt32(reader["EvidenceID"]),
                        Description = reader["Description"].ToString(),
                        LocationFound = reader["LocationFound"].ToString(),
                        IncidentID = Convert.ToInt32(reader["IncidentID"])
                    };
                    evidenceList.Add(evidence);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }

            void PrintEvidence(CARS.Model.Evidence evidence)
            {
                Console.WriteLine($"Evidence ID: {evidence.EvidenceID}");
                Console.WriteLine($"Description: {evidence.Description}");
                Console.WriteLine($"Location Found: {evidence.LocationFound}");
                Console.WriteLine($"IncidentID: {evidence.IncidentID}");
                Console.WriteLine();
            }


            foreach (var evidence in evidenceList)
            {
                PrintEvidence(evidence);
            }
            return evidenceList;
        }
        public bool updateEvidenceAttribute(int evidenceID, string attributeName, string attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Evidence SET {attributeName} = '{attributeValue}' WHERE EvidenceID = {evidenceID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Evidence updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
        public bool updateEvidenceAttribute(int evidenceID, string attributeName, int attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Evidence SET {attributeName} = {attributeValue} WHERE EvidenceID = {evidenceID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Evidence updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
        public bool updateEvidenceAttribute(int evidenceID, string attributeName, double attributeValue1, double attributeValue2)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Evidence SET {attributeName} = geography::Point({attributeValue1}, {attributeValue2}, 4326) WHERE EvidenceID = {evidenceID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Evidence updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
        public bool deleteEvidence(int EvidenceID)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"DELETE FROM Evidence WHERE EvidenceID = {EvidenceID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Evidence deleted successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public ICollection<Reports> displayAllReports()
        {
            List<Reports> reportsList = new List<Reports>();

            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT ReportID, IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status FROM Reports";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reports reports = new Reports
                    {
                        ReportID = Convert.ToInt32(reader["ReportID"]),
                        IncidentID = Convert.ToInt32(reader["IncidentID"]),
                        ReportingOfficer = Convert.ToInt32(reader["ReportingOfficer"]),
                        ReportDate = reader["ReportDate"].ToString(),
                        ReportDetails = reader["ReportDetails"].ToString(),
                        Status = reader["Status"].ToString(),
                    };
                    reportsList.Add(reports);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }

            void PrintReport(Reports reports)
            {
                Console.WriteLine($"Report ID: {reports.ReportID}");
                Console.WriteLine($"Incident ID: {reports.IncidentID}");
                Console.WriteLine($"Reporting Officer: {reports.ReportingOfficer}");
                Console.WriteLine($"Report Date: {reports.ReportDate}");
                Console.WriteLine($"Report Details: {reports.ReportDetails}");
                Console.WriteLine($"Status: {reports.Status}");
                Console.WriteLine();
            }


            foreach (var reports in reportsList)
            {
                PrintReport(reports);
            }
            return reportsList;
        }
        public bool updateReportsAttribute(int reportID, string attributeName, string attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Reports SET {attributeName} = '{attributeValue}' WHERE ReportID = {reportID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Report updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
        public bool updateReportsAttribute(int reportID, string attributeName, int attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Reports SET {attributeName} = {attributeValue} WHERE ReportID = {reportID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Report updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
        public bool deleteReports(int ReportID)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"DELETE FROM Reports WHERE ReportID = {ReportID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Report deleted successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public ICollection<Cases> getAllCases()
        {
            List<Cases> caseList = new List<Cases>();

            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT CaseID, Description, Status, IncidentID FROM Cases";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cases cases = new Cases
                    {
                        CaseID = Convert.ToInt32(reader["CaseID"]),
                        Description = reader["Description"].ToString(),
                        Status = reader["Status"].ToString(),
                        IncidentID = Convert.ToInt32(reader["IncidentID"])
                    };
                    caseList.Add(cases);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }

            void PrintCases(Cases cases)
            {
                Console.WriteLine($"Case ID: {cases.CaseID}");
                Console.WriteLine($"Description: {cases.Description}");
                Console.WriteLine($"Status: {cases.Status}");
                Console.WriteLine($"Incident ID: {cases.IncidentID}");
                Console.WriteLine();
            }


            foreach (var cases in caseList)
            {
                PrintCases(cases);
            }
            return caseList;
        }

        public Cases createCase(Incident incident)
        {   
            Cases cases = null;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"INSERT INTO Cases VALUES ({incident.CaseID}, '{incident.Description}', '{incident.Status}', {incident.IncidentID})";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Case created successfully! <--:::::::\n");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
            }
            finally
            {
                con.Close();
            }
            return cases;
        }

        public Cases getCaseDetails(int caseID)
        {
            Cases Cases = null;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT CaseID, Description, Status, IncidentID FROM Cases WHERE CaseID = {caseID}";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cases cases = new Cases
                    {
                        CaseID = Convert.ToInt32(reader["CaseID"]),
                        Description = reader["Description"].ToString(),
                        Status = reader["Status"].ToString(),
                        IncidentID = Convert.ToInt32(reader["IncidentID"])
                    };
                    Console.WriteLine($"Case ID: {cases.CaseID}");
                    Console.WriteLine($"Description: {cases.Description}");
                    Console.WriteLine($"Status: {cases.Status}");
                    Console.WriteLine($"Incident ID: {cases.IncidentID}");
                    Console.WriteLine();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
            return Cases;
        }

        public bool updateCasesDetails(int caseID, string attributeName, string attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Cases SET {attributeName} = '{attributeValue}' WHERE CaseID = {caseID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Case updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public bool updateCasesDetails(int caseID, string attributeName, int attributeValue)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Cases SET {attributeName} = {attributeValue} WHERE CaseID = {caseID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Case updated successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public bool deleteCases(int caseID)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"DELETE FROM Cases WHERE CaseID = {caseID};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Case deleted successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
    }
}
