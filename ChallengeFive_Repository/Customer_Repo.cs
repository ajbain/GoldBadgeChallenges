using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive_Repository
{
    public class Customer_Repo
    {
        private List<Customer> _customerDirectory = new List<Customer>();
        //crud methods

        //CREATE
        public bool AddCustomer(Customer customer)
        {
            int startingCount = _customerDirectory.Count;
            _customerDirectory.Add(customer);
            bool wasAdded = (_customerDirectory.Count > startingCount) ? true : false;
            return wasAdded;

        }

        //READ
        public List<Customer> GetCustomers()
        {
            return _customerDirectory;
        }

        public Customer GetCustomerByLastName(string lastName)
        {
            foreach (Customer customer in _customerDirectory)
            {
                if (customer.LastName.ToLower() == lastName.ToLower())
                {
                    return customer;
                }

            }
            return null;
        }
        //UPDATE

        public bool UpdateCustomer(string lastName, Customer updatedCust)
        {
            Customer oldName = GetCustomerByLastName(lastName);
            if (oldName != null)
            {
                oldName.FirstName = updatedCust.FirstName;
                oldName.LastName = updatedCust.LastName;
                oldName.CustType = updatedCust.CustType;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE

        public bool DeleteCustomer(Customer existingCustomer)
        {
            bool deleteResult = _customerDirectory.Remove(existingCustomer);
            return deleteResult;
        }
    }
}
