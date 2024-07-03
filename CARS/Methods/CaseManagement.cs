using CARS.Dao;
using CARS.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CARS.Dao.ICrimeAnalysisService;

namespace CARS.Methods
{
    public class CaseManagement
    {
        CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
        CrudFunctionsImpl crudFunctionsImpl = new CrudFunctionsImpl();


        int caseID = 0;

        public void CaseManagaementUpdateCase()
        {
            bool victimExists = false;
            bool primaryKeyExists = false;
            while (!victimExists)
            {
                Console.WriteLine("\nEnter the Case ID of the Case to be updated:");
                caseID = Convert.ToInt32(Console.ReadLine());
                if (crimeAnalysisServiceImpl.doesIDExist("Cases", "CaseID", caseID))
                {
                    victimExists = true;
                }
            }

            Console.WriteLine("\n===> Arribute List:");
            Console.WriteLine("\n1. Case ID\n2. Description\n3. Status\n4. IncidentID");
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
                        attributeName = "CaseID";
                        isValidInput = true;
                        break;
                    case 2:
                        attributeName = "Description";
                        isValidInput = true;
                        break;
                    case 3:
                        attributeName = "Status";
                        isValidInput = true;
                        break;
                    case 4:
                        attributeName = "IncidentID";
                        isValidInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }


            if (input == 1)
            {
                int newCaseID;
                while (true)
                {
                    Console.WriteLine("\nEnter the new Case ID:");
                    newCaseID = Convert.ToInt32(Console.ReadLine());
                    primaryKeyExists = crimeAnalysisServiceImpl.doesIDExist("Cases", "CaseID", newCaseID);
                    if (!primaryKeyExists)
                    {
                        crudFunctionsImpl.updateCasesDetails(caseID, attributeName, newCaseID);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Entered Case ID already exist. Please enter a different Case ID:");
                    }
                }
            }
            else if (input == 2)
            {
                Console.WriteLine("\nEnter new Description:");
                string newDescription = Console.ReadLine();
                crudFunctionsImpl.updateCasesDetails(caseID, attributeName, newDescription);
            }
            else if (input == 3)
            {
                Console.WriteLine("\nEnter new Status:");
                string newStatus = Console.ReadLine();
                crudFunctionsImpl.updateCasesDetails(caseID, attributeName, newStatus);
            }
            else if (input == 4)
            {
                int newIncidentID;
                while (true)
                {
                    Console.WriteLine("\nEnter the new Incident ID:");
                    newIncidentID = Convert.ToInt32(Console.ReadLine());
                    primaryKeyExists = crimeAnalysisServiceImpl.doesIDExist("Incidents", "IncidentID", newIncidentID);
                    if (!primaryKeyExists)
                    {

                        Console.WriteLine("Entered Incident ID does not exist. Please enter a different Incident ID:");
                    }
                    else
                    {
                        crudFunctionsImpl.updateCasesDetails(caseID, attributeName, newIncidentID);
                        break;
                    }
                }
            }
        }
        public void generateCase()
        {
            int caseID, incidentID;
            bool primaryKeyExists = false;

            caseID = crimeAnalysisServiceImpl.GetLatestID("CaseID", "Cases");
            ++caseID;

            Console.WriteLine("\nEnter the Description:");
            string newDescription = Console.ReadLine();
            
            Console.WriteLine("\nEnter the new Status:");
            string newStatus = Console.ReadLine();

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

            Incident incident = new Incident()
            {
                CaseID = caseID,
                Description = newDescription,
                Status = newStatus,
                IncidentID = incidentID
            };

            crudFunctionsImpl.createCase(incident);

        }
    }
}
    
