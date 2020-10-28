using System;
using System.Globalization;
using ChallengeFive_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeFiveTests
{
    [TestClass]
    public class ChallengeFiveTests
    {
        [TestMethod]
        public void SetCustomer_ShouldReturnCorrectCustomer()
        {
            //arrange
            Customer customer = new Customer();

            //act
            customer.FirstName = "John";


            //assert
            Assert.AreEqual(customer.FirstName, "John");
        }
    }
}
