using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Suspects
    {
        public int SuspectID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? ContactInformation { get; set; }

        public Suspects() { }
        
        public Suspects(string firstName, string lastName, string dateOfBirth, string gender, string contactInformation) 
        {
            FirstName = firstName;  
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ContactInformation = contactInformation;
        }

        public Suspects(int suspectID, string firstName, string lastName, string dateOfBirth, string gender, string contactInformation)
        {
            SuspectID = suspectID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ContactInformation = contactInformation;
        }
    }
}
