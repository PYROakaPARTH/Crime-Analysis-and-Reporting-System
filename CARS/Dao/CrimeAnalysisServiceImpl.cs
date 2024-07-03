using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CARS.Dao.ICrimeAnalysisService;
using CARS.Model;
using CARS.Util;
using System.Data.SqlClient;
using System.Data;
using System.Security.Principal;
using CARS.Exceptions;

namespace CARS.Dao
{
    public class CrimeAnalysisServiceImpl : ICrimeAnalysisService
    {
        string ConString = PropertyUtil.getPropertyString();
        public int GetLatestID(string columnName, string tableName)
        {
            int maxID = 0;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT MAX({columnName}) FROM {tableName}";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    maxID = Convert.ToInt32(reader[0]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in GetLatestID: " + ex.Message);
            }
            return maxID;
        }

        public (bool, int) victimAlreadyExists(Victims victims)
        {
            int victimID = 0;
            bool exists = false;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT VictimID FROM Victims WHERE FirstName = '{victims.FirstName}' AND LastName = '{victims.LastName}' AND DateOfBirth = '{victims.DateOfBirth}' AND Gender = '{victims.Gender}' AND ContactInformation = '{victims.ContactInformation}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    victimID = Convert.ToInt32(reader[0]);
                    exists = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in GetLatestID: " + ex.Message);
            }
            return (exists, victimID);
        }

        public int createVictim(Victims victims)
        {
            string columnName = "VictimID";
            string tableName = "Victims";
            CrimeAnalysisServiceImpl obj = new CrimeAnalysisServiceImpl();
            int nextVictimID = obj.GetLatestID(columnName, tableName);
            ++nextVictimID;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"INSERT INTO Victims VALUES ({nextVictimID}, '{victims.FirstName}', '{victims.LastName}', '{victims.DateOfBirth}', '{victims.Gender}', '{victims.ContactInformation}')";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Victim created successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught in Create Victim " + e.ToString());
            }
            finally
            {
                con.Close();
            }

            return nextVictimID;
        }

        public (bool, int) suspectAlreadyExists(Suspects suspects)
        {
            int suspectID = 0;
            bool exists = false;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT SuspectID FROM Suspects WHERE FirstName = '{suspects.FirstName}' AND LastName = '{suspects.LastName}' AND DateOfBirth = '{suspects.DateOfBirth}' AND Gender = '{suspects.Gender}' AND ContactInformation = '{suspects.ContactInformation}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suspectID = Convert.ToInt32(reader[0]);
                    exists = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in GetLatestID: " + ex.Message);
            }
            return (exists, suspectID);
        }
        public int createSuspect(Suspects suspects)
        {
            string columnName = "SuspectID";
            string tableName = "Suspects";
            CrimeAnalysisServiceImpl obj = new CrimeAnalysisServiceImpl();
            int nextSuspectID = obj.GetLatestID(columnName, tableName);
            ++nextSuspectID;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"INSERT INTO Suspects VALUES ({nextSuspectID}, '{suspects.FirstName}', '{suspects.LastName}', '{suspects.DateOfBirth}', '{suspects.Gender}', '{suspects.ContactInformation}')";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Suspect created successfully! <--:::::::");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught Create Suspect " + e.ToString());
            }
            finally
            {
                con.Close();
            }

            return nextSuspectID;
        }
        public bool createIncident(Incidents incident)
        {
            string columnName = "IncidentID";
            string tableName = "Incidents";
            CrimeAnalysisServiceImpl obj = new CrimeAnalysisServiceImpl();
            int nextIncidentID = obj.GetLatestID(columnName, tableName);
            ++nextIncidentID;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"INSERT INTO Incidents VALUES ({nextIncidentID}, '{incident.IncidentType}', '{incident.IncidentDate}', geography::Point({incident.Latitude}, {incident.Longitude}, 4326), '{incident.Description}', '{incident.Status}', {incident.VictimID}, {incident.SuspectId})";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Incident created successfully! <--:::::::");
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

        public bool doesIDExist(string tableName, string attributeName, int Id)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT COUNT(*) FROM {tableName} WHERE  {attributeName} = {Id};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    throw new IncidentNumberNotFoundException($"{tableName} with ID {Id} not found.");
                }
                return true;
            }
            catch (IncidentNumberNotFoundException ex)
            {
                Console.WriteLine("\nIncidentNumberNotFoundException caught: " + ex.Message);
                return false;
            }
            catch (SqlException e)
            {
                Console.WriteLine("\nException caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /*public bool doesIncidentExist(int incidentId)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT COUNT(*) FROM Incidents WHERE  IncidentID = {incidentId};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    throw new IncidentNumberNotFoundException($"Incident with ID {incidentId} not found.");
                }
                return true;
            }
            catch (IncidentNumberNotFoundException ex)
            {
                Console.WriteLine("\nIncidentNumberNotFoundException caught: " + ex.Message);
                return false;
            }
            catch (SqlException e)
            {
                Console.WriteLine("\nException caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
        }*/
        public bool updateIncidentStatus(string status, int incidentId)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Incidents SET Status = '{status}' WHERE IncidentID = {incidentId};";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Incident status updated successfully! <--:::::::");
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
        public ICollection<Incident> getIncidentsInDateRange(string startDate, string endDate)
        {
            List<Incident> incidents = new List<Incident>();

            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT IncidentID, IncidentType, IncidentDate FROM Incidents WHERE IncidentDate BETWEEN '{startDate}' AND '{endDate}'";
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
                        IncidentDate = reader["IncidentDate"].ToString()
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
                Console.WriteLine();
            }

           
            foreach (var incident in incidents)
            {
                PrintIncident(incident);
            }
            return incidents;
        }
       
        public ICollection<Incident> searchIncidents(IncidentType criteria)
        {
            List<Incident> incidents = new List<Incident>();
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT IncidentID, IncidentType, IncidentDate FROM Incidents WHERE IncidentType = '{criteria.ToString()}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["IncidentID"].ToString());
                    Incident incident = new Incident
                    {
                        IncidentID = Convert.ToInt32(reader["IncidentID"]),
                        IncidentType = reader["IncidentType"].ToString(),
                        IncidentDate = reader["IncidentDate"].ToString()
                    };
                    incidents.Add(incident);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }

            foreach (var incident in incidents)
            {
                incident.PrintIncident(incident);
            }

            return incidents;
        }
        public Report generateIncidentReport(Incident incident)
        {
            Report report = new Report();
            report.ReportID = incident.ReportID;
            report.IncidentID = incident.IncidentID;
            report.ReportingOfficer = incident.ReportingOfficer;
            report.ReportDate = incident.ReportDate;
            report.ReportDetails = incident.ReportDetails;
            report.ReportStatus = incident.ReportStatus;

            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"INSERT INTO Reports VALUES ({report.ReportID}, {report.IncidentID}, '{report.ReportingOfficer}', '{report.ReportDate}', '{report.ReportDetails}', '{report.ReportStatus}')";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n:::::::--> Reports created successfully! <--:::::::\n");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception caught " + e.ToString());
            }
            finally
            {
                con.Close();
            }
            return report;
        }
        public Case createCase(string caseDescription, ICollection<Incident> incidents)
        {
            Case newCase = null;
             /*string ConString = PropertyUtil.getPropertyString();
            {
                SqlConnection con = new SqlConnection(ConString);
                string queryString = $"INSERT INTO Incidents VALUES ({incident.IncidentID}, '{incident.IncidentType}', '{incident.IncidentDate}', '{incident.Location}', '{incident.Description}', '{incident.Status}', {incident.VictimID}, {incident.SuspectId})";
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("\nIncident created successfully!");
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
            }*/
            return newCase;
        }
        public Case getCaseDetails(int caseId)
        {
            Case caseDetails = null;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT IncidentType , IncidentDate, Location, Description, Status FROM Incidents WHERE IncidentID ='{caseId}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write("IncidentType: " + reader[0].ToString() + "\nIncidentDate: " + reader[1].ToString() + "\nLocation: " + reader[2].ToString() + "\nDescription: " + reader[3].ToString());
                    Console.WriteLine();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
            return caseDetails;
        }
        public bool updateCaseDetails(Case updatedCase)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"UPDATE Incidents SET Description  = '{updatedCase.Description}' WHERE IncidentID = '{updatedCase.CaseID}'";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
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
           
        }
        public List<Case> GetAllCases()
        {
            List<Case> cases = new List<Case>();
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT IncidentID, IncidentType, Description FROM Incidents";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Case caseDetail = new Case
                    {
                        CaseID = Convert.ToInt32(reader["IncidentID"]),
                        //IncidentType = reader["IncidentType"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                    cases.Add(caseDetail);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
            return cases;
        }
        public void DisplayAllCases()
        {
            
            List<Case> cases = GetAllCases();

            
            foreach (Case caseDetail in cases)
            {
                Console.WriteLine($"Case ID: {caseDetail.CaseID}");
                Console.WriteLine($"Case Type: {caseDetail.IncidentType}");
                Console.WriteLine($"Description: {caseDetail.Description}");
                Console.WriteLine();
            }
        }

        public bool getUserCases(List<Incident> incidentIDList)
        {
            List<Case> casesList = new List<Case>();
            SqlConnection con = new SqlConnection(ConString);
            string incidentIDs = string.Join(",", incidentIDList.Select(incident => incident.IncidentID.ToString()));
            string queryString = $"SELECT CaseID, Description, Status FROM Cases WHERE IncidentID IN ({incidentIDs})";
            bool isSuccess = false;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Case caseObj = new Case
                    {
                        CaseID = Convert.ToInt32(reader["CaseID"]),
                        Description = reader["Description"].ToString(),
                        Status = reader["Status"].ToString()
                    };
                    casesList.Add(caseObj);
                }
                reader.Close();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in getUserCases: " + ex.Message);
            }
            foreach (Case caseDetail in casesList)
            {
                Console.WriteLine($"Case ID: {caseDetail.CaseID}");
                Console.WriteLine($"Description: {caseDetail.Description}");
                Console.WriteLine($"Status: {caseDetail.Status}");
                Console.WriteLine();
            }
            return isSuccess;
        }

        public List<Incident> getIncidentIDforUsers(string firstName, string lastName, string gender, string dateOfBirth)
        {
            List<Incident> incidentIDList = new List<Incident>();

            SqlConnection con = new SqlConnection(ConString);
            string queryString = "SELECT i.IncidentID as IncidentIDs FROM Incidents i JOIN Victims v ON i.VictimID = v.VictimID WHERE v.FirstName = @FirstName AND v.LastName = @LastName AND v.DateOfBirth = @DateOfBirth AND v.Gender = @Gender";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", gender);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Incident incidentObj = new Incident()
                    {
                        IncidentID = Convert.ToInt32(reader["IncidentIDs"])
                    };
                    incidentIDList.Add(incidentObj);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in getIncidentIDforUsers: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return incidentIDList;

        }

        public bool doesPersonExist(string firstName, string lastName, string gender, string dateOfBirth)
        {
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT COUNT(*) FROM Victims WHERE FirstName = '{firstName}' AND LastName = '{lastName}' AND DateOfBirth = '{dateOfBirth}' AND Gender = '{gender}'";
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    throw new NoSuchPersonFoundException("No such person not found.");
                }
                return true;
            }
            catch (NoSuchPersonFoundException ex)
            {
                Console.WriteLine("NoSuchPersonFoundException caught: " + ex.Message);
                return false;
            }
            catch (SqlException e)
            {
                Console.WriteLine("\nException caught " + e.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}

