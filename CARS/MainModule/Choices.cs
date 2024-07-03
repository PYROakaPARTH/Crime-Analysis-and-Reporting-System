using CARS.Dao;
using CARS.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CARS.Dao.ICrimeAnalysisService;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CARS.Model;
using System.Reflection;
using CARS.Exceptions;

namespace CARS.MainModule
{
    public class Choices
    {
        CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();

        public void choice1()
        {
            string inputDate;
            string dateOfBirth;

            //TAKING VICTIM DETAILS

            Console.WriteLine("\nEnter the details of the Victim:");
            Console.WriteLine("\nFirst Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("\nLast Name:");
            string lastName = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("\nEnter a Date of Birth in 'YYYY-MM-DD' format:");
                dateOfBirth = Console.ReadLine();
                DateTime dateValue;
                try
                {
                    if (DateTime.TryParseExact(dateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidDateFormat();
                    }
                }
                catch (InvalidDateFormat)
                {
                    Console.WriteLine("\nInvalid date format! Please enter a valid date.");
                }
            }
            
            Console.WriteLine("\nGender:");
            string gender = Console.ReadLine();
            Console.WriteLine("\nContact Information:");
            string contactInformation = Console.ReadLine();

            Victims victims = new Victims()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                ContactInformation = contactInformation
            };

            int victimID;
            (bool exists, victimID) = crimeAnalysisServiceImpl.victimAlreadyExists(victims);
            if (exists)
            {
                Console.WriteLine("\nA victim with entered details already exists. Existing Victim ID will be used.");
            }
            else
            {
                victimID = crimeAnalysisServiceImpl.createVictim(victims);
            }

            Console.WriteLine("\n==========================================");
            //TAKING SUSPECT DETAILS

            Console.WriteLine("\nEnter the details of the Suspect:");
            Console.WriteLine("\nFirst Name:");
            firstName = Console.ReadLine();
            Console.WriteLine("\nLast Name:");
            lastName = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("\nEnter a Date of Birth in 'YYYY-MM-DD' format:");
                dateOfBirth = Console.ReadLine();
                DateTime dateValue;
                try
                {
                    if (DateTime.TryParseExact(dateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidDateFormat();
                    }
                }
                catch (InvalidDateFormat)
                {
                    Console.WriteLine("\nInvalid date format! Please enter a valid date.");
                }
            }

            Console.WriteLine("\nGender:");
            gender = Console.ReadLine();
            Console.WriteLine("\nContact Information:");
            contactInformation = Console.ReadLine();

            Suspects suspects = new Suspects()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                ContactInformation = contactInformation
            };

            int suspectID;
            (exists, suspectID) = crimeAnalysisServiceImpl.suspectAlreadyExists(suspects);
            if (exists)
            {
                Console.WriteLine("\nA suspect with entered details already exists. Existing Suspect ID will be used.");
            }
            else
            {
                suspectID = crimeAnalysisServiceImpl.createSuspect(suspects);
            }

            Console.WriteLine("\n==========================================");
            //TAKING INCIDENT DETAILS

            Console.WriteLine("\nEnter the details of the Incident:");
            Console.WriteLine("\nEnter the incident type(e.g. Robbery, Homicide, Theft):");
            string incidentType = Console.ReadLine();

            
            while (true)
            {
                Console.WriteLine("\nEnter a date in 'YYYY-MM-DD' format:");
                inputDate = Console.ReadLine();
                DateTime dateValue;
                try
                {
                    if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidDateFormat();
                    }
                }
                catch (InvalidDateFormat)
                {
                    Console.WriteLine("\nInvalid date format! Please enter a valid date.");
                }
            }

            double latitude;
            double longitude;

            while (true)
            {
                Console.WriteLine("\nEnter the Latitude:");
                latitude = Convert.ToDouble(Console.ReadLine());

                try
                {
                    if (latitude >= -90 && latitude <= 90)
                    {
                        break;
                    }
                    else
                    {
                        throw new latitudeOutOfRange("Enter Latitude witin range of -90 to 90.");
                    }
                }
                catch (latitudeOutOfRange ex)
                {
                    Console.WriteLine("latitudeOutOfRange caught: " + ex.Message);
                }
            }

            while (true)
            {
                Console.WriteLine("\nEnter the Longitude:");
                longitude = Convert.ToDouble(Console.ReadLine());

                try
                {
                    if (longitude >= -180 && longitude <= 180)
                    {
                        break;
                    }
                    else
                    {
                        throw new longitudeOutOfRange("Enter Longitude witin range of -180 to 180.");
                    }
                }
                catch (longitudeOutOfRange ex)
                {
                    Console.WriteLine("longitudeOutOfRange caught: " + ex.Message);
                }
            }

            Console.WriteLine("\nEnter description of the incident in few words:");
            string description = Console.ReadLine();

            Console.WriteLine("\nEnter status of the incident (e.g, Open, Closed, Under Inverstigation):");
            string status = Console.ReadLine();

            Incidents incidents = new Incidents()
            {
                IncidentType = incidentType,
                IncidentDate = inputDate,
                Latitude = latitude,
                Longitude = longitude,
                Description = description,
                Status = status,
                VictimID = victimID,
                SuspectId = suspectID
            };

            crimeAnalysisServiceImpl.createIncident(incidents);

            //TAKING INCIDENT DETAILS

            Console.WriteLine("\nEnter the details of the incident:");
        }

        public void choice2()
        {

            int incidentID = 0;
            bool incidentExists = false;
            while (!incidentExists)
            {
                Console.WriteLine("\nEnter the Incident ID for the incident:");
                incidentID = Convert.ToInt32(Console.ReadLine());
                if (crimeAnalysisServiceImpl.doesIDExist("Incidents", "IncidentID", incidentID))
                {
                    incidentExists = true;
                }
            }

            Console.WriteLine("\nEnter the updated status of the incident:");
            string newStatus = Console.ReadLine();

            crimeAnalysisServiceImpl.updateIncidentStatus(newStatus, incidentID);

        }

        public void choice3()
        {
            string inputDate;
            while (true)
            {
                Console.WriteLine("\nEnter the from date in 'YYYY-MM-DD' format:");
                inputDate = Console.ReadLine();
                DateTime dateValue;
                try
                {
                    if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidDateFormat();
                    }
                }
                catch (InvalidDateFormat)
                {
                    Console.WriteLine("\nInvalid date format! Please enter a valid date.");
                }
            }

            string inputDate1;
            while (true)
            {
                Console.WriteLine("\nEnter the to date in 'YYYY-MM-DD' format:");
                inputDate1 = Console.ReadLine();
                DateTime dateValue1;
                try
                {
                    if (DateTime.TryParseExact(inputDate1, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue1))
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidDateFormat();
                    }
                }
                catch(InvalidDateFormat)
                {
                    Console.WriteLine("\nInvalid date format! Please enter a valid date.");
                }
            }

            ICollection<Incident> incidents = crimeAnalysisServiceImpl.getIncidentsInDateRange(inputDate, inputDate1);

        }

        public void choice4()
        {
            Console.WriteLine("Enter the incident type:");
            string incidentType = Console.ReadLine();

            if (Enum.TryParse(incidentType, out IncidentType searchCriteria))
            {
                ICollection<Incident> searchResults = crimeAnalysisServiceImpl.searchIncidents(searchCriteria);
            }
            else
            {
                Console.WriteLine("\nInvalid incident type!");
            }
        }

        public void choice5()
        {
            Console.WriteLine("Enter the Report ID:");
            int reportID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter the Incident ID:");
            int incidentID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter the Reporting Officer ID:");
            int reportingOfficer = Convert.ToInt32(Console.ReadLine());

            string reportDate;
            while (true)
            {
                Console.WriteLine("\nEnter a date in 'YYYY-MM-DD' format:");
                reportDate = Console.ReadLine();
                DateTime dateValue;

                if (DateTime.TryParseExact(reportDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format! Please enter a valid date.");
                }
            }

            Console.WriteLine("\nEnter the Report details:");
            string reportDetails = Console.ReadLine();

            Console.WriteLine("\nEnter the Reportstatus:");
            string reportStatus = Console.ReadLine();

            Incident incident = new Incident()
            {
                ReportID = reportID,
                IncidentID = incidentID,
                ReportingOfficer = reportingOfficer,
                ReportDate = reportDate,
                ReportDetails = reportDetails,
                ReportStatus = reportStatus
            };
           
            Report incidentReport = crimeAnalysisServiceImpl.generateIncidentReport(incident);

            Console.WriteLine("Generated Incident Report:");
            Console.WriteLine($"Report ID: {incident.ReportID}");
            Console.WriteLine($"Incident ID: {incident.IncidentID}");
            Console.WriteLine($"Reporting Officer: {incident.ReportingOfficer}");
            Console.WriteLine($"Report Date: {incident.ReportDate}");
            Console.WriteLine($"Report Details: {incident.ReportDetails}");
            Console.WriteLine($"Report Status: {incident.ReportStatus}");
            
        }
        public void choice6()
        {
            
        }

        public void choice7()
        {
            Console.WriteLine("Enter the Case id:");
            int incidentID = Convert.ToInt32(Console.ReadLine());
            crimeAnalysisServiceImpl.getCaseDetails(incidentID);
        }
        public void choice8()
        {
            Console.WriteLine("Enter the Case id to update:");
            int incidentID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new case details:");
            string newDetails = Console.ReadLine();
            Case updatedCase = new Case
            {
                CaseID = incidentID,
                Description = newDetails
            };

            bool updateResult = crimeAnalysisServiceImpl.updateCaseDetails(updatedCase);

            if (updateResult)
            {
                Console.WriteLine("Case details updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update case details.");
            }
        }
        public void choice9()
        {
            crimeAnalysisServiceImpl.GetAllCases();
            crimeAnalysisServiceImpl.DisplayAllCases();
        }
    }
}