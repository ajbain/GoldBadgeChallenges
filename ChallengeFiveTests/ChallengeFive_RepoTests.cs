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
    }
}
