using ChallengeFive_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
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
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.Clear();

                Console.WriteLine("Welcome to Komodo Insurance Customer Database.");
                Console.WriteLine("Please select the option you would like to use.");
                Console.WriteLine("1. Show All Customers");
                Console.WriteLine("2. Find Customers by Last Name");
                Console.WriteLine("3. Add a New Customer");
                Console.WriteLine("4. Update a Customer");
                Console.WriteLine("5. Delete a Customer");
                Console.WriteLine("6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllCustomers();
                        //need to put in alphabetical order
                        break;
                    case "2":
                        ShowCustomersByLastName();
                        //finds customers by last name
                        break;
                    case "3":
                        AddNewCustomer();
                        //adds a new customer
                        break;
                    case "4":
                        UpdateExistingCustomer();
                        //updates a customer
                        break;
                    case "5":
                        //deletes a customer
                        DeleteCustomer();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response (1-5)");
                        Console.ReadKey();
                        break;
                }
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


        private void ShowCustomersByLastName()
        {
            Console.Clear();
            Console.WriteLine("Enter the Last Name of the customer that you are looking for:");
            string lastName = Console.ReadLine();

            Customer customer = _repo.GetCustomerByLastName(lastName);
            if (customer != null)
            {
                DisplayCustomers(customer);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("I'm not sure what customer you are looking for. That customer either 1.) Does not exist, or 2.) Something was spelled incorrectly.");
                Console.WriteLine("Please ensure the spelling is correct and try again. Press any key to return to main menu.");
                Console.ReadKey();
            }

           
        }
        private void AddNewCustomer()
        {
            Console.Clear();
            Customer newCustomer = new Customer();

            Console.WriteLine("You are entering information for a NEW customer");
            Console.WriteLine("Please verify all information is correct when entering");
            Console.WriteLine("Please enter a First Name");
            newCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("Please enter a Last Name");
            newCustomer.LastName = Console.ReadLine();

            Console.WriteLine("Please select the numbers listed below to indicate if this is a past, present, or potential customer.");
            Console.WriteLine("1. Past");
            Console.WriteLine("2. Present");
            Console.WriteLine("3. Potential");
            string custType = Console.ReadLine();

            int custTypeInt = int.Parse(custType);
            newCustomer.CustType = (CustType)custTypeInt;


            bool custAdded = _repo.AddCustomer(newCustomer);
            if (custAdded == true)
            {
                Console.WriteLine("Customer was successfully added!");
            }
            else
            {
                Console.WriteLine("Oops! Something went wrong. Please try again.");
            }

        }
        private void UpdateExistingCustomer()
        {
            Console.Clear();
            Console.WriteLine("Enter the LAST NAME of the customer you'd like to update.");
            string lastName = Console.ReadLine();
            Customer oldCust = _repo.GetCustomerByLastName(lastName);

            Customer newCust = new Customer(
                oldCust.FirstName,
                oldCust.LastName,
                oldCust.CustType);

            if (oldCust == null)
            {
                Console.WriteLine("Customer not found. Are you sure you searched by Last Name?");
                Console.WriteLine("Please try again");
                Console.ReadKey();
                return;
            }

            Console.WriteLine(" Enter the number of the option you'd like to update:");
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. Customer Type");

            string itemToUpdate = Console.ReadLine();
            switch (itemToUpdate)
            {
                case "1":
                    Console.WriteLine("Enter a new First Name");
                    string newFirstName = Console.ReadLine();
                    oldCust.FirstName = newFirstName;
                    //bool wasSuccessful = _repo.UpdateCustomer(firstName, newFirstName);

                    //if (wasSuccessful)
                    //{
                    //    Console.WriteLine("Item successfully updated");
                    //}
                    //else
                    //{
                    //    Console.WriteLine($"Error: could not update {firstName}");
                    //}
                    break;
                case "2":
                    Console.WriteLine("Enter a new Last Name");
                    string newLastName = Console.ReadLine();
                    oldCust.LastName = newLastName;
                    break;
                case "3":
                    Console.WriteLine("Enter a number for the Customer Type:");
                    Console.WriteLine("1. Past");
                    Console.WriteLine("2. Present");
                    Console.WriteLine("3. Potential");

                    string custType = Console.ReadLine();
                    switch (custType)
                    {
                        case "1":
                            oldCust.CustType = CustType.Past;
                            break;
                        case "2":
                            oldCust.CustType = CustType.Present;
                            break;
                        case "3":
                            oldCust.CustType = CustType.Potential;
                            break;
                        default:
                            Console.WriteLine("You entered an incorrect number, please try again");
                            break;
                    }
                    break;
                default:
                    break;
            }
           
        }
        public void DeleteCustomer()
        {
            ShowAllCustomers();
            Console.Clear();
            Console.WriteLine("Enter the last name of the customer you would like to delete");
            string lastNameToDelete = Console.ReadLine();
            Customer customerToDelete = _repo.GetCustomerByLastName(lastNameToDelete);
            bool wasDeleted = _repo.DeleteCustomer(customerToDelete);

            if(wasDeleted)
            {
                Console.WriteLine("This customer was sucessfully deleted");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Oops! Something went wrong, please try again.");
            }
        }
       
    }


}
