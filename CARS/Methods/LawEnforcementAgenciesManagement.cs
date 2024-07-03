using CARS.Dao;
using CARS.Exceptions;
using CARS.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CARS.Dao.ICrimeAnalysisService;

namespace CARS.Methods
{
    public class LawEnforcementAgenciesManagement
    {
        CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
        CrudFunctionsImpl crudFunctionsImpl = new CrudFunctionsImpl();

        string inputDate;
        string dateOfBirth;
        int agencyID = 0;

        public void AgenciesManagementUpdateAgencies()
        {
            bool victimExists = false;
            bool primaryKeyExists = false;
            while (!victimExists)
            {
                Console.WriteLine("\nEnter the Agency ID of the Agency to be updated:");
                agencyID = Convert.ToInt32(Console.ReadLine());
                if (crimeAnalysisServiceImpl.doesIDExist("LawEnforcementAgencies", "AgencyID", agencyID))
                {
                    victimExists = true;
                }
            }

            Console.WriteLine("\n===> Arribute List:");
            Console.WriteLine("\n1. Agency Name\n2. Jurisdiction\n3. Contact Information\n4. Officer ID\n");
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
                        attributeName = "AgencyName";
                        isValidInput = true;
                        break;
                    case 2:
                        attributeName = "Jurisdiction";
                        isValidInput = true;
                        break;
                    case 3:
                        attributeName = "ContactInformation";
                        isValidInput = true;
                        break;
                    case 4:
                        attributeName = "OfficerID";
                        isValidInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }


            if (input == 1)
            {
                Console.WriteLine("\nEnter new Agency Name:");
                string newAgencyName = Console.ReadLine();
                crudFunctionsImpl.updateAgenciesAttribute(agencyID, attributeName, newAgencyName);
            }
            else if (input == 2)
            {
                Console.WriteLine("\nEnter new Jurisdiction:");
                string newJurisdiction = Console.ReadLine();
                crudFunctionsImpl.updateAgenciesAttribute(agencyID, attributeName, newJurisdiction);
            }
            else if (input == 3)
            {
                Console.WriteLine("\nEnter new ContactInformation:");
                string newContactInformation = Console.ReadLine();
                crudFunctionsImpl.updateAgenciesAttribute(agencyID, attributeName, newContactInformation);
            }
            else if (input == 4)
            {
                Console.WriteLine("\nEnter new OfficerID:");
                int newOfficerID = Convert.ToInt32(Console.ReadLine());
                crudFunctionsImpl.updateAgenciesAttribute(agencyID, attributeName, newOfficerID);
            }
        }
    }
}
