using System;
using ChallengeSix_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeSixTests
{
    [TestClass]
    public class ChallengeSix_Tests
    {

        [TestMethod]
        public void SetMake_ShouldReturnCorrectString()
        {
            Vehicle vehicle = new Vehicle();

            vehicle.Make = "Honda";
            
            Assert.AreEqual(vehicle.Make, "Honda");
        }

    }
}

