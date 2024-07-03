using CARS.Dao;
using CARS.Exceptions;
using CARS.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static CARS.Dao.ICrimeAnalysisService;

namespace CARS.Methods
{
    public class ReportManagement
    {
        CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
        CrudFunctionsImpl crudFunctionsImpl = new CrudFunctionsImpl();

        int reportID = 0;

        public void ReportsManagaementUpdateReports()
        {
            bool victimExists = false;
            bool primaryKeyExists = false;
            while (!victimExists)
            {
                Console.WriteLine("\nEnter the Report ID of the Report to be updated:");
                reportID = Convert.ToInt32(Console.ReadLine());
                if (crimeAnalysisServiceImpl.doesIDExist("Reports", "ReportID", reportID))
                {
                    victimExists = true;
                }
            }

            Console.WriteLine("\n===> Arribute List:");
            Console.WriteLine("\n1. Incident ID\n2. Reporting Officer\n3. Report Date\n4. Report Details\n5. Status");
            string attributeName = "";
            bool isValidInput = false;
            int input = 0;
            while (!isValidInput)
            {
                Console.Write("\nSelect the attribute to be updated: ");
                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        attributeName = "IncidentID";
                        isValidInput = true;
                        break;
                    case 2:
                        attributeName = "ReportingOfficer";
                        isValidInput = true;
                        break;
                    case 3:
                        attributeName = "ReportDate";
                        isValidInput = true;
                        break;
                    case 4:
                        attributeName = "ReportDetails";
                        isValidInput = true;
                        break;
                    case 5:
                        attributeName = "Status";
                        isValidInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }


            if (input == 1)
            {
                int newIncidentID;
                while (true)
                {
                    Console.WriteLine("\nEnter new Incident ID:");
                    newIncidentID = Convert.ToInt32(Console.ReadLine());
                    primaryKeyExists = crimeAnalysisServiceImpl.doesIDExist("Incidents", "IncidentID", newIncidentID);
                    if (!primaryKeyExists)
                    {

                        Console.WriteLine("Entered Incident ID does notexist. Please enter a different Incident ID:");
                    }
                    else
                    {
                        crudFunctionsImpl.updateReportsAttribute(reportID, attributeName, newIncidentID);
                        break;
                    }
                }
            }
            else if (input == 2)
            {
                Console.WriteLine("\nEnter new Last Name:");
                string newLastName = Console.ReadLine();
                crudFunctionsImpl.updateReportsAttribute(reportID, attributeName, newLastName);
            }
            else if (input == 3)
            {
                Console.WriteLine("\nEnter new Badge Number:");
                int badgeNumber = Convert.ToInt32(Console.ReadLine());
                crudFunctionsImpl.updateReportsAttribute(reportID, attributeName, badgeNumber);
            }
            else if (input == 4)
            {
                Console.WriteLine("\nEnter new Rank:");
                string Rank = Console.ReadLine();
                crudFunctionsImpl.updateReportsAttribute(reportID, attributeName, Rank);
            }
            else if (input == 5)
            {
                Console.WriteLine("\nEnter new Contact Inforation:");
                string newContactInfo = Console.ReadLine();
                crudFunctionsImpl.updateReportsAttribute(reportID, attributeName, newContactInfo);
            }
        }

        public void generateIncidentReport()
        {
            int reportID, incidentID, reportingOfficer;
            bool primaryKeyExists = false;
           
            reportID = crimeAnalysisServiceImpl.GetLatestID("ReportID", "Reports");
            ++reportID;

            while (true)
            {
                Console.WriteLine("\nEnter the Incident ID:");
                incidentID = Convert.ToInt32(Console.ReadLine());
                primaryKeyExists = crimeAnalysisServiceImpl.doesIDExist("Incidents", "IncidentID", incidentID);
                if (!primaryKeyExists)
                {

                    Console.WriteLine("Entered Incident ID does notexist. Please enter a different Incident ID:");
                }
                else break;
            }

            while (true)
            {
                Console.WriteLine("\nEnter the Reporting Officer ID:");
                reportingOfficer = Convert.ToInt32(Console.ReadLine());
                primaryKeyExists = crimeAnalysisServiceImpl.doesIDExist("Officers", "OfficerID", reportingOfficer);
                if (!primaryKeyExists)
                {

                    Console.WriteLine("Entered Officer ID does notexist. Please enter a different Officer ID:");
                }
                else break;
            }

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

            Console.WriteLine("\nEnter the Report Status:");
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

            Console.WriteLine("Generated Incident Report:\n");
            Console.WriteLine($"Report ID: {incident.ReportID}");
            Console.WriteLine($"Incident ID: {incident.IncidentID}");
            Console.WriteLine($"Reporting Officer: {incident.ReportingOfficer}");
            Console.WriteLine($"Report Date: {incident.ReportDate}");
            Console.WriteLine($"Report Details: {incident.ReportDetails}");
            Console.WriteLine($"Report Status: {incident.ReportStatus}");
        }
    }
}
