using CARS.Exceptions;
using CARS.Dao;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace CARS.MainModule
{
    public class userApp
    {
        CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl(); 
        public void userOptions()
        {
            bool logout = false;

            while (!logout)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("\nCrime Analysis and Reporting System:\n");
                Console.WriteLine("1. Show registered cases");
                Console.WriteLine("2. Logout");
                try
                {
                    Console.Write("\nEnter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            while (true)
                            {
                                Console.WriteLine("\nEnter Person details:");
                                Console.WriteLine("\nEnter first name:");
                                string firstName = Console.ReadLine();

                                Console.WriteLine("Enter last name:");
                                string lastName = Console.ReadLine();

                                Console.WriteLine("Enter gender:");
                                string gender = Console.ReadLine();

                                string inputDate;

                                while (true)
                                {
                                    Console.WriteLine("\nEnter Birth Date in 'YYYY-MM-DD' format:\n");
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
                                
                                if (crimeAnalysisServiceImpl.doesPersonExist(firstName, lastName, gender, inputDate))
                                {
                                    
                                    bool x = crimeAnalysisServiceImpl.getUserCases(crimeAnalysisServiceImpl.getIncidentIDforUsers(firstName, lastName, gender, inputDate));
                                    if (x)
                                    {
                                        Console.WriteLine("User cases were retrieved successfully.");
                                        //Console.WriteLine("No cases found.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No cases found.");
                                        //Console.WriteLine("No cases found.");
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nEntered person does not exist. Please enter valid details.");
                                }

                                /*if (crimeAnalysisServiceImpl.doesPersonExist(firstName, lastName, gender, inputDate))
                                {
                                    crimeAnalysisServiceImpl.getUserCases(crimeAnalysisServiceImpl.getIncidentIDforUsers(firstName, lastName, gender, inputDate));
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nEntered person does not exist. Please enter valid details.");
                                }*/
                            }
                            break;
                        case 2:
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

        
    }
}
