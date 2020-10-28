using ChallengeFive_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveTests
{
    [TestClass]

    public class ChallengeFive_RepoTests
    {
        [TestMethod]
        public void AddContentToCustDirect_ShouldReturnTrue()
        {
            //arrange
            Customer customer = new Customer();
            Customer_Repo repo = new Customer_Repo();

            //act
            bool addResult = repo.AddCustomer(customer);


            //assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void ShowCustomerDirectory_ShouldReturnCustomers()
        {
            Customer customer = new Customer();
            Customer_Repo repo = new Customer_Repo();

            repo.AddCustomer(customer);

            List<Customer> directory = repo.GetCustomers();

            bool directoryHasContent = directory.Contains(customer);

            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void GetCustomerByLastName_ShouldReturnCorrectString()
        {
            {
                Customer customer = new Customer("John", "Doe", CustType.Past);
                Customer_Repo repo = new Customer_Repo();

                repo.AddCustomer(customer);
                string lastName = "Doe";

                Customer searchResult = repo.GetCustomerByLastName(lastName);


                Assert.AreEqual(lastName, searchResult.LastName);

            }

           
        }
        [TestMethod]
        public void UpdateExistingCustomer_ShouldReturnTrue()
        {
            Customer_Repo repo = new Customer_Repo();
            Customer oldCustomer = new Customer("John", "Doe", CustType.Past);

            repo.AddCustomer(oldCustomer);
            Customer newCustomer = new Customer("Jon", "Doe", CustType.Present);

            bool updateResult = repo.UpdateCustomer(oldCustomer.LastName, newCustomer);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {

            Customer_Repo repo = new Customer_Repo();
            Customer customer = new Customer("Jane", "Doe", CustType.Potential);
            repo.AddCustomer(customer);

            Customer oldCust = repo.GetCustomerByLastName("Doe");

            bool removeResults = repo.DeleteCustomer(oldCust);

            Assert.IsTrue(removeResults);
        }
        
    }
}
