/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CARS.MainModule
{
    public class adminModule
    {
        public void adminMenu()
        {
            Choices choices = new Choices();
            int choice = 0;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("\nCrime Analysis and Reporting System:\n");
                Console.WriteLine("1. Create incident");
                Console.WriteLine("2. Update incident status");
                Console.WriteLine("3. Get incidents in a date range ");
                Console.WriteLine("4. Search incidents by Type");
                Console.WriteLine("5. Generate incident report");
                Console.WriteLine("6. Create case");
                Console.WriteLine("7. Get details of a case");
                Console.WriteLine("8. Update case details");
                Console.WriteLine("9. Display of all cases");
                Console.WriteLine("10. Logout\n");
                try
                {
                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                }

                switch (choice)
                {
                    case 1:
                        choices.choice1();
                        break;
                    case 2:
                        choices.choice2();
                        break;
                    case 3:
                        choices.choice3();
                        break;
                    case 4:
                        choices.choice4();
                        break;
                    case 5:
                        choices.choice5();
                        break;
                    case 6:
                        choices.choice6();
                        break;
                    case 7:
                        choices.choice7();
                        break;
                    case 8:
                        choices.choice8();
                        break;
                    case 9:
                        choices.choice9();
                        break;
                    case 10:
                        exit = true;
                        Console.WriteLine("Logging out...");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
*/