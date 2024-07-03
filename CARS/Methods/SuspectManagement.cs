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
    public class SuspectManagement
    {
        CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
        CrudFunctionsImpl crudFunctionsImpl = new CrudFunctionsImpl();

        string inputDate;
        string dateOfBirth;
        int suspectID = 0;

        public void SuspectManagaementUpdateSuspects()
        {
            bool suspectExists = false;
            bool primaryKeyExists = false;
            while (!suspectExists)
            {
                Console.WriteLine("\nEnter the Suspect ID of the Suspect to be updated:");
                suspectID = Convert.ToInt32(Console.ReadLine());
                if (crimeAnalysisServiceImpl.doesIDExist("Suspects", "SuspectID", suspectID))
                {
                    suspectExists = true;
                }
            }

            Console.WriteLine("\n===> Arribute List:");
            Console.WriteLine("\n1. First Name\n2. Last Name\n3. Date Of Birth\n4. Gender\n5. ContactInformation");
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
                        attributeName = "DateOfBirth";
                        isValidInput = true;
                        break;
                    case 4:
                        attributeName = "Gender";
                        isValidInput = true;
                        break;
                    case 5:
                        attributeName = "ContactInformation";
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
                crudFunctionsImpl.updateSuspectAttribute(suspectID, attributeName, newFirstName);
            }
            else if (input == 2)
            {
                Console.WriteLine("\nEnter new Last Name:");
                string newLastName = Console.ReadLine();
                crudFunctionsImpl.updateSuspectAttribute(suspectID, attributeName, newLastName);
            }
            else if (input == 3)
            {
                while (true)
                {
                    Console.WriteLine("\nEnter new Birth Date in 'YYYY-MM-DD' format:");
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
                crudFunctionsImpl.updateSuspectAttribute(suspectID, attributeName, inputDate);
            }
            else if (input == 4)
            {
                Console.WriteLine("\nEnter new Gender:");
                string newGender = Console.ReadLine();
                crudFunctionsImpl.updateSuspectAttribute(suspectID, attributeName, newGender);
            }
            else if (input == 5)
            {
                Console.WriteLine("\nEnter new Contact Inforation:");
                string newContactInfo = Console.ReadLine();
                crudFunctionsImpl.updateSuspectAttribute(suspectID, attributeName, newContactInfo);
            }
        }
    }
}
