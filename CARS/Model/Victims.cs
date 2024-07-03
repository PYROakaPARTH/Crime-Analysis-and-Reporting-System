using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Victims
    {
        public int VictimID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? ContactInformation { get; set; }

        public Victims() { }

        public Victims(string firstName, string lastName, string? dateOfBirth, string gender, string contactInformation)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ContactInformation = contactInformation;
        }

        public Victims(int victimId, string firstName, string lastName, string? dateOfBirth, string gender, string contactInformation)
        {
            VictimID = victimId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ContactInformation = contactInformation;
        }
    }
}
