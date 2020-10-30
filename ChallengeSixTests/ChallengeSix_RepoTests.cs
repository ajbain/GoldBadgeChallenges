 using System;
using System.Collections.Generic;
using ChallengeSix_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeSixTests
{
    [TestClass]
    public class ChallengeSix_RepoTests
    {
        [TestMethod]
        public void AddContentToCustDirect_ShouldReturnTrue()
        {
            //arrange
            Vehicle vehicle = new Vehicle();
            Vehicle_Repo repo = new Vehicle_Repo();

            //act
            bool addResult = repo.AddVehicle(vehicle);


     
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void ShowVehicleDirectory_ShouldReturnVehicles()
        {
            Vehicle vehicle = new Vehicle();
            Vehicle_Repo repo = new Vehicle_Repo();

            repo.AddVehicle(vehicle);

            List<Vehicle> directory = repo.GetVehicles();

            bool directoryHasContent = directory.Contains(vehicle);

            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void GetVehicleByMake_ShouldReturnCorrectString()
        {
            {
                Vehicle vehicle = new Vehicle("Honda", "Civic", "2002", 27.3, VehicleType.Gas);
                Vehicle_Repo repo = new Vehicle_Repo();

                repo.AddVehicle(vehicle);
                string make = "Honda";

                Vehicle searchResult = repo.GetVehicleByMake(make);


                Assert.AreEqual(make, searchResult.Make);

            }
       }
        [TestMethod]
        public void UpdateExistingVehicle_ShouldReturnTrue()
        {
            Vehicle_Repo repo = new Vehicle_Repo();
            Vehicle oldVehicle = new Vehicle("Honda", "Civic", "2002", 27.3, VehicleType.Gas);

            repo.AddVehicle(oldVehicle);
            Vehicle newVehicle = new Vehicle("Honda", "Accord", "2002", 27.3, VehicleType.Gas);

            bool updateResult = repo.UpdateVehicle(oldVehicle.Make, newVehicle);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {

            Vehicle_Repo repo = new Vehicle_Repo();
            Vehicle vehicle = new Vehicle("Honda", "Accord", "2002", 34.8, VehicleType.Gas);
            repo.AddVehicle(vehicle);

            Vehicle oldVehicle = repo.GetVehicleByMake("Honda");

            bool removeResults = repo.DeleteVehicle(oldVehicle);

            Assert.IsTrue(removeResults);
        }
    }
}
