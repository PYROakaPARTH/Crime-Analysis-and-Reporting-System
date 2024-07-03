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
    public class EvidenceManagement
    {
        CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
        CrudFunctionsImpl crudFunctionsImpl = new CrudFunctionsImpl();

        int evidenceID = 0;

        public void EvidenceManagaementUpdateEvidence()
        {
            bool victimExists = false;
            bool primaryKeyExists = false;
            while (!victimExists)
            {
                Console.WriteLine("\nEnter the Evidence ID of the Evidence to be updated:");
                evidenceID = Convert.ToInt32(Console.ReadLine());
                if (crimeAnalysisServiceImpl.doesIDExist("Evidence", "EvidenceID", evidenceID))
                {
                    victimExists = true;
                }
            }

            Console.WriteLine("\n===> Arribute List:");
            Console.WriteLine("\n1. Description\n2. LocationFound\n3. IncidentID");
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
                        attributeName = "Description";
                        isValidInput = true;
                        break;
                    case 2:
                        attributeName = "LocationFound";
                        isValidInput = true;
                        break;
                    case 3:
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
                Console.WriteLine("\nEnter new Description:");
                string newDescription = Console.ReadLine();
                crudFunctionsImpl.updateEvidenceAttribute(evidenceID, attributeName, newDescription);
            }
            else if (input == 2)
            {
                double latitude;
                double longitude;

                while (true)
                {
                    Console.WriteLine("\nEnter the new Latitude:");
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
                    Console.WriteLine("\nEnter the new Longitude:");
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
                crudFunctionsImpl.updateEvidenceAttribute(evidenceID, attributeName, latitude, longitude);
            }
            else if (input == 3)
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
                        crudFunctionsImpl.updateEvidenceAttribute(evidenceID, attributeName, newIncidentID);
                        break;
                    }
                }
            }
        }
    }
}
