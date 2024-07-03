using CARS.Dao;
using static CARS.Dao.ICrimeAnalysisService;
using CARS.Model;
using CARS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NUnit.Framework;
using CARS.MainModule;
using System.Reflection;


namespace testing
{
    [TestFixture]
    class incidentTest
    {
        CrimeAnalysisServiceImpl obj = new CrimeAnalysisServiceImpl();
        [Test]
        public void TestCreateIncident()
        {
            Incidents incident1 = new Incidents("Arson", "2024-05-01", 514.5, 543.24, "Car burned by group of people", "Open", 5, 13);

            bool isSuccess = obj.createIncident(incident1);
            Assert.IsTrue(true, "Incident creation failed.");
        }

        [Test]
        public void TestUpdateIncident()
        {
            bool isSuccess = obj.updateIncidentStatus("Open", 1);
            Assert.IsTrue(isSuccess, "Incident creation failed.");
        }

        [Test]
        public void TestCreateSuspect()
        {
            Suspects suspects = new Suspects("Parth", "Patil", "2003-11-03", "Male", "Kolhapur");
            int result = obj.createSuspect(suspects);
            bool isSuccess = (result > 0);
            Assert.IsTrue(isSuccess, "Suspect creation failed.");
        }

        [Test]
        public void TestCreateVictim()
        {
            Victims victims = new Victims("Parth", "Patil", "2003-11-03", "Male", "Kolhapur");
            int result = obj.createVictim(victims);
            bool isSuccess = (result > 0);
            Assert.IsTrue(isSuccess, "Victim creation failed.");
        }

        [Test]
        public void TestSuspectAlreadyExists()
        {
            Suspects suspects = new Suspects
            {
                FirstName = "Michael",
                LastName = "Jones",
                DateOfBirth = "1988-04-18",
                Gender = "Male",
                ContactInformation = "789 Elm St, City21, Country21"
            };

            (bool exists, int suspectID) = obj.suspectAlreadyExists(suspects);
            Assert.That(exists, Is.True, "The suspect already exists.");
            Assert.That(suspectID, Is.EqualTo(1), "The suspect ID should be 1.");
        }

        [Test]
        public void TestVictimAlreadyExists()
        {
            Victims victims = new Victims
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = "1990-05-15",
                Gender = "Male",
                ContactInformation = "123 Main St, City, Country"
            };

            (bool exists, int victimID) = obj.victimAlreadyExists(victims);
            Assert.That(exists, Is.True, "The victim already exists.");
            Assert.That(victimID, Is.EqualTo(1), "The victim ID should be 1.");
        }

        [Test]
        public void TestUpdateIncidentsAttribute()
        {
            CrudFunctionsImpl crudFunctionsImpl = new CrudFunctionsImpl();
            bool isSuccess = crudFunctionsImpl.updateIncidentsAttribute(1, "IncidentType", "Theft");
            Assert.IsTrue(true, "Incident updation failed.");
        }
    }
}