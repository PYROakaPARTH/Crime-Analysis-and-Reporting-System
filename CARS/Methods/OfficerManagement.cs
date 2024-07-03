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
    public class OfficerManagement
    {
        CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
        CrudFunctionsImpl crudFunctionsImpl = new CrudFunctionsImpl();

        string inputDate;
        string dateOfBirth;
        int officerID = 0;

        public void OfficersManagaementUpdateOfficers()
        {
            bool victimExists = false;
            bool primaryKeyExists = false;
            while (!victimExists)
            {
                Console.WriteLine("\nEnter the Officer ID of the Officer to be updated:");
                officerID = Convert.ToInt32(Console.ReadLine());
                if (crimeAnalysisServiceImpl.doesIDExist("Officers", "OfficerID", officerID))
                {
                    victimExists = true;
                }
            }

            Console.WriteLine("\n===> Arribute List:");
            Console.WriteLine("\n1. First Name\n2. Last Name\n3. BadgeNumber\n4. Rank\n5. Contact Information\n6. Agency ID");
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
                        attributeName = "FirstName";
                        isValidInput = true;
                        break;
                    case 2:
                        attributeName = "LastName";
                        isValidInput = true;
                        break;
                    case 3:
                        attributeName = "BadgeNumber";
                        isValidInput = true;
                        break;
                    case 4:
                        attributeName = "Rank";
                        isValidInput = true;
                        break;
                    case 5:
                        attributeName = "ContactInfo";
                        isValidInput = true;
                        break;
                    case 6:
                        attributeName = "AgencyID";
                        isValidInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }


            if (input == 1)
            {
                Console.WriteLine("\nEnter new First Name:");
                string newFirstName = Console.ReadLine();
                crudFunctionsImpl.updateOfficersAttribute(officerID, attributeName, newFirstName);
            }
            else if (input == 2)
            {
                Console.WriteLine("\nEnter new Last Name:");
                string newLastName = Console.ReadLine();
                crudFunctionsImpl.updateOfficersAttribute(officerID, attributeName, newLastName);
            }
            else if (input == 3)
            {
                Console.WriteLine("\nEnter new Badge Number:");
                int badgeNumber = Convert.ToInt32(Console.ReadLine());
                crudFunctionsImpl.updateOfficersAttribute(officerID, attributeName, badgeNumber);
            }
            else if (input == 4)
            {
                Console.WriteLine("\nEnter new Rank:");
                string Rank = Console.ReadLine();
                crudFunctionsImpl.updateOfficersAttribute(officerID, attributeName, Rank);
            }
            else if (input == 5)
            {
                Console.WriteLine("\nEnter new Contact Inforation:");
                string newContactInfo = Console.ReadLine();
                crudFunctionsImpl.updateOfficersAttribute(officerID, attributeName, newContactInfo);
            }
            else if (input == 6)
            {
                Console.WriteLine("\nEnter new Agency ID:");
                int newAgencyID = Convert.ToInt32(Console.ReadLine());
                crudFunctionsImpl.updateOfficersAttribute(officerID, attributeName, newAgencyID);
            }
        }
    }
}
