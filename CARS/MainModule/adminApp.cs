using CARS.Dao;
using CARS.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using CARS.Methods;
using CARS.Model;

namespace CARS.MainModule
{
    public class adminApp
    {
        CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
        CrudFunctionsImpl crudFunctionsImpl = new CrudFunctionsImpl();
        IncidentManagement incidentManagement = new IncidentManagement();
        VictimManagement victimManagement = new VictimManagement();  
        SuspectManagement suspectManagement = new SuspectManagement();
        LawEnforcementAgenciesManagement lawEnforcementAgenciesManagement = new LawEnforcementAgenciesManagement();
        OfficerManagement officerManagement = new OfficerManagement();
        EvidenceManagement evidenceManagement = new EvidenceManagement();
        ReportManagement reportManagement = new ReportManagement();
        CaseManagement caseManagement = new CaseManagement();   
        Choices choices = new Choices();
        public void adminOptions()
        {
            bool logout = false;

            while (!logout)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("\nCrime Analysis and Reporting System:\n");
                Console.WriteLine("1. Incident Management");
                Console.WriteLine("2. Victim Management");
                Console.WriteLine("3. Suspect Management");
                Console.WriteLine("4. Law Enforcement Agencies Management");
                Console.WriteLine("5. Officers Management");
                Console.WriteLine("6. Evidence Management");
                Console.WriteLine("7. Reports Management");
                Console.WriteLine("8. Cases Management");
                Console.WriteLine("9. Logout");
                try
                {
                    Console.Write("\nEnter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            IncidentManagementMenu();
                            break;
                        case 2:
                            VictimManagementMenu();
                            break;
                        case 3:
                            SuspectManagementMenu();
                            break;
                        case 4:
                            LawEnforcementAgenciesManagementMenu();
                            break;
                        case 5:
                            OfficersManagementMenu();
                            break;
                        case 6:
                            EvidenceManagementMenu();
                            break;
                        case 7:
                            ReportsManagementMenu();
                            break;
                        case 8:
                            CaseManagementMenu();
                            break;
                        case 9:
                            logout = true;
                            Console.WriteLine("Logged out successfully.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }

        public void IncidentManagementMenu()
        {
            string inputDate;
            string dateOfBirth;
            bool backToMainMenu = false;
            int incidentID = 0;

            while (!backToMainMenu)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Incident Management Menu:");
                Console.WriteLine("1. Display all Incidents");
                Console.WriteLine("2. Create new Incident");
                Console.WriteLine("3. Update Incidents");
                Console.WriteLine("4. Delete Incidents");
                Console.WriteLine("5. Update Incident Status");
                Console.WriteLine("6. Get Incidents in a date range");
                Console.WriteLine("7. Get Incidents based on Incident Type");
                Console.WriteLine("8. Back to Main Menu");
                try
                {
                    Console.Write("\nEnter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            crudFunctionsImpl.displayAllIncidents();
                            break;
                        case 2:
                            choices.choice1();
                            break;
                        case 3:
                            incidentManagement.IncidentManagementUpdateIncidents();
                            break;
                        case 4:
                            Console.WriteLine("Enter the Incident ID of the Incident that you want to delete:");
                            incidentID = Convert.ToInt32(Console.ReadLine());   
                            crudFunctionsImpl.deleteIncidents(incidentID);
                            break;
                        case 5:
                            choices.choice2();
                            break;
                        case 6:
                            choices.choice3();
                            break;
                        case 7:
                            choices.choice4();
                            break;
                        case 8:
                            backToMainMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }

        public void VictimManagementMenu()
        {
            string inputDate;
            string dateOfBirth;
            bool backToMainMenu = false;
            //int victimID = 0;

            while (!backToMainMenu)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Victim Management Menu:");
                Console.WriteLine("1. Display all Victims");
                Console.WriteLine("2. Update Victims");
                Console.WriteLine("3. Delete Victims");
                Console.WriteLine("4. Back to Main Menu");
                try
                {
                    Console.Write("\nEnter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            crudFunctionsImpl.displayAllVictims();
                            break;
                        case 2:
                            victimManagement.VictimManagaementUpdateVictims();
                            break;
                        case 3:
                            Console.WriteLine("Enter the Victim ID of the Victim that you want to delete:");
                            int victimID = Convert.ToInt32(Console.ReadLine());
                            crudFunctionsImpl.deleteVictim(victimID);
                            break;
                        case 4:
                            backToMainMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }

        public void SuspectManagementMenu()
        {
            string inputDate;
            string dateOfBirth;
            bool backToMainMenu = false;
            //int incidentID = 0;

            while (!backToMainMenu)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Suspect Management Menu:");
                Console.WriteLine("1. Display all Suspects");
                Console.WriteLine("2. Update Suspects");
                Console.WriteLine("3. Delete Suspects");
                Console.WriteLine("4. Back to Main Menu");
                try
                {
                    Console.Write("\nEnter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            crudFunctionsImpl.displayAllSuspects();
                            break;
                        case 2:
                            suspectManagement.SuspectManagaementUpdateSuspects();
                            break;
                        case 3:
                            Console.WriteLine("Enter the Suspect ID of the Suspect that you want to delete:");
                            int suspectID = Convert.ToInt32(Console.ReadLine());
                            crudFunctionsImpl.deleteSuspect(suspectID);
                            break;
                        case 4:
                            backToMainMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }

        public void LawEnforcementAgenciesManagementMenu()
        {
            bool backToMainMenu = false;
            //int incidentID = 0;

            while (!backToMainMenu)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Law Enforcement Agencies Management Menu:");
                Console.WriteLine("1. Display all Agencies");
                Console.WriteLine("2. Update Agencies");
                Console.WriteLine("3. Delete Agencies");
                Console.WriteLine("4. Back to Main Menu");
                try
                {
                    Console.Write("\nEnter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            crudFunctionsImpl.displayAllAgencies();
                            break;
                        case 2:
                            lawEnforcementAgenciesManagement.AgenciesManagementUpdateAgencies();
                            break;
                        case 3:
                            Console.WriteLine("Enter the Agency ID of the Agency that you want to delete:");
                            int suspectID = Convert.ToInt32(Console.ReadLine());
                            crudFunctionsImpl.deleteSuspect(suspectID);
                            break;
                        case 4:
                            backToMainMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }
        public void OfficersManagementMenu()
        {
            bool backToMainMenu = false;
            //int incidentID = 0;

            while (!backToMainMenu)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Officers Management Menu:");
                Console.WriteLine("1. Display all Officers");
                Console.WriteLine("2. Update Officers");
                Console.WriteLine("3. Delete Officers");
                Console.WriteLine("4. Back to Main Menu");
                try
                {
                    Console.Write("\nEnter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            crudFunctionsImpl.displayAllOfficers();
                            break;
                        case 2:
                            officerManagement.OfficersManagaementUpdateOfficers();
                            break;
                        case 3:
                            Console.WriteLine("Enter the Suspect ID of the Suspect that you want to delete:");
                            int officerID = Convert.ToInt32(Console.ReadLine());
                            crudFunctionsImpl.deleteOfficers(officerID);
                            break;
                        case 4:
                            backToMainMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }
        public void EvidenceManagementMenu()
        {
            bool backToMainMenu = false;
            //int incidentID = 0;

            while (!backToMainMenu)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Evidence Management Menu:");
                Console.WriteLine("1. Display all Evidence");
                Console.WriteLine("2. Update Evidence");
                Console.WriteLine("3. Delete Evidence");
                Console.WriteLine("4. Back to Main Menu");
                try
                {
                    Console.Write("\nEnter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            crudFunctionsImpl.displayAllEvidence();
                            break;
                        case 2:
                            evidenceManagement.EvidenceManagaementUpdateEvidence();
                            break;
                        case 3:
                            Console.WriteLine("Enter the Evidence ID of the Evidence that you want to delete:");
                            int evidenceID = Convert.ToInt32(Console.ReadLine());
                            crudFunctionsImpl.deleteEvidence(evidenceID);
                            break;
                        case 4:
                            backToMainMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }

        }

        public void ReportsManagementMenu()
        {
            bool backToMainMenu = false;
            //int incidentID = 0;

            while (!backToMainMenu)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Report Management Menu:");
                Console.WriteLine("1. Display all Reports");
                Console.WriteLine("2. Generate Reports");
                Console.WriteLine("3. Update Report");
                Console.WriteLine("4. Delete Report");
                Console.WriteLine("5. Back to Main Menu");
                try
                {
                    Console.Write("\nEnter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            crudFunctionsImpl.displayAllReports();
                            break;
                        case 2:
                            reportManagement.generateIncidentReport();
                            break;
                        case 3:
                            reportManagement.ReportsManagaementUpdateReports();
                            break;
                        case 4:
                            Console.WriteLine("Enter the Report ID of the Report that you want to delete:");
                            int reportID = Convert.ToInt32(Console.ReadLine());
                            crudFunctionsImpl.deleteReports(reportID);
                            break;
                        case 5:
                            backToMainMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }
        public void CaseManagementMenu()
        {
            bool backToMainMenu = false;
            int caseID = 0;
            while (!backToMainMenu)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Case Management Menu:");
                Console.WriteLine("1. Display all Cases");
                Console.WriteLine("2. Create new Case");
                Console.WriteLine("3. Get details of a specific Case");
                Console.WriteLine("4. Update Case");
                Console.WriteLine("5. Delete Case");
                Console.WriteLine("6. Back to Main Menu");
                try
                {
                    Console.Write("\nEnter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            crudFunctionsImpl.getAllCases();
                            break;
                        case 2:
                            caseManagement.generateCase();
                            break;
                        case 3:
                            bool primaryKeyExists = false;
                            while (true)
                            {
                                Console.WriteLine("\nEnter the Case ID of the Case:");
                                caseID = Convert.ToInt32(Console.ReadLine());
                                primaryKeyExists = crimeAnalysisServiceImpl.doesIDExist("Cases", "CaseID", caseID);
                                if (!primaryKeyExists)
                                {
                                    Console.WriteLine("Entered Case ID does not exist. Please enter a different Case ID:");
                                }
                                else
                                {
                                    crudFunctionsImpl.getCaseDetails(caseID);
                                    break;
                                }
                            }
                            break;
                        case 4:
                            caseManagement.CaseManagaementUpdateCase();
                            break;
                        case 5:
                            while (true)
                            {
                                Console.WriteLine("\nEnter the Case ID of the Case that you want to delete:");
                                caseID = Convert.ToInt32(Console.ReadLine());
                                primaryKeyExists = crimeAnalysisServiceImpl.doesIDExist("Cases", "CaseID", caseID);
                                if (!primaryKeyExists)
                                {
                                    Console.WriteLine("Entered Case ID does not exist. Please enter a different Case ID:");
                                }
                                else
                                {
                                    crudFunctionsImpl.deleteCases(caseID);
                                    break;
                                }
                            }
                            break;
                        case 6:
                            backToMainMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }
    }
}

