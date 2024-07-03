using CARS.Dao;
using CARS.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Methods
{
    public class IncidentManagement
    {
        CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
        CrudFunctionsImpl crudFunctionsImpl = new CrudFunctionsImpl();

        string inputDate;
        string dateOfBirth;
        int incidentID = 0;
        public void IncidentManagementUpdateIncidents() 
        {
            bool incidentExists = false;
            bool primaryKeyExists = false;
            while (!incidentExists)
            {
                Console.WriteLine("\nEnter the Incident ID of the Incident to be updated:");
                incidentID = Convert.ToInt32(Console.ReadLine());
                if (crimeAnalysisServiceImpl.doesIDExist("Incidents", "IncidentID", incidentID))
                {
                    incidentExists = true;
                }
            }

            Console.WriteLine("\n===> Arribute List:");
            Console.WriteLine("\n1. Incident ID\n2. Incident Type\n3. Incident Date\n4. Location\n5. Description\n6. Status\n7.Victim ID\n8. Suspect ID");
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
                        attributeName = "IncidentType";
                        isValidInput = true;
                        break;
                    case 3:
                        attributeName = "IncidentDate";
                        isValidInput = true;
                        break;
                    case 4:
                        attributeName = "Location";
                        isValidInput = true;
                        break;
                    case 5:
                        attributeName = "Description";
                        isValidInput = true;
                        break;
                    case 6:
                        attributeName = "Status";
                        isValidInput = true;
                        break;
                    case 7:
                        attributeName = "VictimID";
                        isValidInput = true;
                        break;
                    case 8:
                        attributeName = "SuspectID";
                        isValidInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }

            if (input == 1)
            {
                while (true)
                {
                    Console.WriteLine("\nEnter new Incident ID:");
                    int newIncidentID = Convert.ToInt32(Console.ReadLine());
                    primaryKeyExists = crimeAnalysisServiceImpl.doesIDExist("Incidents", "IncidentID", newIncidentID);
                    if (primaryKeyExists)
                    {

                        Console.WriteLine("Entered Incident ID already exists. Please enter a different Incident ID:");
                    }
                    else
                    {
                        crudFunctionsImpl.updateIncidentsAttribute(incidentID, attributeName, newIncidentID);
                        break;
                    }
                }
            }
            else if (input == 2)
            {
                Console.WriteLine("\nEnter new Incident Type:");
                string newIncidentType = Console.ReadLine();
                crudFunctionsImpl.updateIncidentsAttribute(incidentID, attributeName, newIncidentType);
            }
            else if (input == 3)
            {
                while (true)
                {
                    Console.WriteLine("\nEnter new Incident Date in 'YYYY-MM-DD' format:");
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
                crudFunctionsImpl.updateIncidentsAttribute(incidentID, attributeName, inputDate);
            }
            else if (input == 4)
            {
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
                            throw new latitudeOutOfRange("\nEnter Latitude witin range of -90 to 90.");
                        }
                    }
                    catch (latitudeOutOfRange ex)
                    {
                        Console.WriteLine("\nlatitudeOutOfRange caught: " + ex.Message);
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
                            throw new longitudeOutOfRange("\nEnter Longitude witin range of -180 to 180.");
                        }
                    }
                    catch (longitudeOutOfRange ex)
                    {
                        Console.WriteLine("\nlongitudeOutOfRange caught: " + ex.Message);
                    }
                }
                crudFunctionsImpl.updateIncidentsAttribute(incidentID, attributeName, latitude, longitude);
            }
            else if (input == 5)
            {
                Console.WriteLine("\nEnter new Incident Description:");
                string newIncidentDescription = Console.ReadLine();
                crudFunctionsImpl.updateIncidentsAttribute(incidentID, attributeName, newIncidentDescription);
            }
            else if (input == 6)
            {
                Console.WriteLine("\nEnter new Incident Status:");
                string newIncidentStatus = Console.ReadLine();
                crudFunctionsImpl.updateIncidentsAttribute(incidentID, attributeName, newIncidentStatus);
            }
            else if (input == 7)
            {
                while (true)
                {
                    Console.WriteLine("\nEnter new Suspect ID:");
                    int newVictimID = Convert.ToInt32(Console.ReadLine());
                    primaryKeyExists = crimeAnalysisServiceImpl.doesIDExist("Victims", "VictimID", newVictimID);
                    if (!primaryKeyExists)
                    {

                        Console.WriteLine("Entered Suspect ID does notexist. Please enter a different Suspect ID:");
                    }
                    else
                    {
                        crudFunctionsImpl.updateIncidentsAttribute(incidentID, attributeName, newVictimID);
                        break;
                    }
                }
            }
            else if (input == 8)
            {
                while (true)
                {
                    Console.WriteLine("\nEnter new Suspect ID:");
                    int newSuspectID = Convert.ToInt32(Console.ReadLine());
                    primaryKeyExists = crimeAnalysisServiceImpl.doesIDExist("Suspects", "SuspectID", newSuspectID);
                    if (!primaryKeyExists)
                    {

                        Console.WriteLine("Entered Suspect ID does notexist. Please enter a different Suspect ID:");
                    }
                    else
                    {
                        crudFunctionsImpl.updateIncidentsAttribute(incidentID, attributeName, newSuspectID);
                        break;
                    }
                }
            }
        }
    }
}
