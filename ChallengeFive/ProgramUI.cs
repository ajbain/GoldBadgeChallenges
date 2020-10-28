using ChallengeFive_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace _ChallengeFive_Console
{
    public class ProgramUI
    {
        private Customer_Repo _repo = new Customer_Repo();

        public void Run()
        {
            SeedContent();
            Menu();

        }
        private void SeedContent()
        {
            Customer jane = new Customer(
                "Jane", "Doe", CustType.Present);
            _repo.AddCustomer(jane);

            Customer abby = new Customer(
                "Abby", "Smith", CustType.Past);
            _repo.AddCustomer(abby);

            Customer emma = new Customer(
                "Emma", "Johnson", CustType.Potential);
            _repo.AddCustomer(emma);

            Customer josh = new Customer(
                "Josh", "Adamson", CustType.Present);
            _repo.AddCustomer(josh);

            Customer leo = new Customer(
                "Leo", "McGary", CustType.Past);
            _repo.AddCustomer(leo);

            Customer adam = new Customer(
                "Adam", "Zeta", CustType.Potential);
            _repo.AddCustomer(adam);

            Customer brittney = new Customer(
                "Brittney", "Bond", CustType.Present);
            _repo.AddCustomer(brittney);
        }
        
        private void Menu()
        {
            Console.Clear();

            Console.WriteLine("Welcome to Komodo Insurance Customer Database.");
            Console.WriteLine("Please select the option you would like to use.");
            Console.WriteLine("1. Show All Customers");
            Console.WriteLine("2. Find Customers by Last Name");
            Console.WriteLine("3. Add a New Customer");
            Console.WriteLine("4. Update a Customer");
            Console.WriteLine("5. Delete a Customer");

            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    ShowAllCustomers();
                    //need to put in alphabetical order
                    break;
                case "2":
                    //finds customers by last name
                    break;
                case "3":
                    //adds a new customer
                    break;
                case "4":
                    //updates a customer
                    break;
                case "5":
                    //deletes a customer
                    break;
                default:
                    Console.WriteLine("Please enter a valid response (1-5)");
                    Console.ReadKey();
                    break;
            }
        }

        private void DisplayCustomers(Customer customer)
        {
             
            Console.WriteLine($"{customer.FirstName}        {customer.LastName}        {customer.CustType}           {customer.EmailType}    ");
        }

        private void ShowAllCustomers()
        {
            Console.Clear();
            List<Customer> listOfCustomers = _repo.GetCustomers();
            List<Customer> alphabetizedCusts = new List<Customer>();
            listOfCustomers.Sort((x, y) => string.Compare(x.LastName, y.LastName));
            foreach(Customer customer in listOfCustomers)
            {
                DisplayCustomers(customer);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }


        
       
    }


}
