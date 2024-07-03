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

namespace CARS.MainModule
{
    public class Login
    {
        static void Main(string[] args)
        {
            int choice = 0;
            LoginLogout objLoginLogout = new LoginLogout();

            Console.WriteLine("Welcome to Crime Analysis & Reporting System \nSelect your login type");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n1. Admin\n2. User\n3. Exit");
                //Console.WriteLine("\n1. Admin\n2. Exit");
                try
                {
                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\nEnter your username:");
                            string username = Console.ReadLine();

                            while (string.IsNullOrEmpty(username))
                            {
                                Console.WriteLine("Username cannot be empty. \nPlease enter your username:");
                                username = Console.ReadLine();
                            }

                            Console.WriteLine("Enter your password:");
                            string password = Console.ReadLine();

                            while (string.IsNullOrEmpty(password))
                            {
                                Console.WriteLine("Password cannot be empty. \nPlease enter your password:");
                                password = Console.ReadLine();
                            }

                            objLoginLogout.adminLogin(username, password);
                            break;

                        case 2:
                            Console.WriteLine("\nEnter your username:");
                            username = Console.ReadLine();

                            while (string.IsNullOrEmpty(username))
                            {
                                Console.WriteLine("Username cannot be empty. \nPlease enter your username:");
                                username = Console.ReadLine();
                            }

                            Console.WriteLine("Enter your password:");
                            password = Console.ReadLine();

                            while (string.IsNullOrEmpty(password))
                            {
                                Console.WriteLine("Password cannot be empty. \nPlease enter your password:");
                                password = Console.ReadLine();
                            }

                            objLoginLogout.userLogin(username, password);

                            break;
                        case 3:
                            exit = true;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
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
