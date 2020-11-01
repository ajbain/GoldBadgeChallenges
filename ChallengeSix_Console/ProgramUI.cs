using ChallengeSix_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSix_Console
{
    public class ProgramUI
    {
        private Vehicle_Repo _repo = new Vehicle_Repo();
        public void Run()
        {
            SeedContent();
            Menu();

        }

        private void SeedContent()
        {
            Vehicle modelS = new Vehicle(
               "Tesla", "Model S", "2020", 402.0, VehicleType.Electric);
            _repo.AddVehicle(modelS);

            Vehicle clarity = new Vehicle(
                "Honda", "Clarity", "2021", 340.0, VehicleType.Hybrid);
            _repo.AddVehicle(clarity);

            Vehicle prius = new Vehicle(
                "Toyota", "Prius", "2020", 519.2, VehicleType.Hybrid);
            _repo.AddVehicle(prius);

            Vehicle fusion = new Vehicle(
                "Ford", "Fusion", "2020", 400.0, VehicleType.Gas);
            _repo.AddVehicle(fusion);


        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.Clear();

                Console.WriteLine("Welcome to Komodo Insurance Green Initiative Database.");
                Console.WriteLine("Please select the option you would like to use.");
                Console.WriteLine("1. Show All Vehicles");
                Console.WriteLine("2. Find Vehicle by Make");
                Console.WriteLine("3. Add a New Vehicle");
                Console.WriteLine("4. Update a Vehicle");
                Console.WriteLine("5. Delete a Vehicle");
                Console.WriteLine("6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Console.WriteLine(String.Format("{0,-10} | {1,5} | {2,5} | {3,5} | {4,5} | {5,5)", "Vehicle Make", "Vehicle Model", "Vehicle Year", "Vehicle Mileage per Fill", "Vehicle Type", "Is Vehicle Green T/F"));
                        ShowAllVehicles();
                        //need to put in alphabetical order
                        break;
                    case "2":
                        ShowVehiclesByMake();
                        //finds vehicles by make
                        break;
                    case "3":
                        AddNewVehicle();
                        //adds a new vehicle
                        break;
                    case "4":
                        UpdateExistingVehicle();
                        //updates a vehicle
                        break;
                    case "5":
                        //deletes a vehicle
                        DeleteVehicle();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response (1-6");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void DisplayVehicles(Vehicle vehicle)
        {

            
            Console.WriteLine(String.Format("{0,-10} | {1, 5} | {2, 5} | {3, 5} | {4, 5} | {5, 5}" , vehicle.Make, vehicle.Model, vehicle.Year, vehicle.MileagePerGallon, vehicle.VehicleType, vehicle.isGreen) );
        }

        /// <summary>
        ///  below does not need to be in alphaveticl order?
        /// </summary>

        private void ShowAllVehicles()
        {
            Console.Clear();
            List<Vehicle> listOfVehicles = _repo.GetVehicles();
            List<Vehicle> alphabetizedByMake = new List<Vehicle>();
            listOfVehicles.Sort((x, y) => string.Compare(x.Make, y.Make));
            foreach (Vehicle vehicle in listOfVehicles)
            {
                DisplayVehicles(vehicle);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }


        private void ShowVehiclesByMake()
        {
            Console.Clear();
            Console.WriteLine("Enter the make of the vehicle that you are looking for:");
            string make = Console.ReadLine();

            Vehicle vehicle = _repo.GetVehicleByMake(make);
            if (vehicle != null)
            {
                DisplayVehicles(vehicle);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("I'm not sure what vehicle you are looking for. That vehicle either 1.) Does not exist, or 2.) Something was spelled incorrectly.");
                Console.WriteLine("Please ensure the spelling is correct and try again. Press any key to return to main menu.");
                Console.ReadKey();
            }


        }
        private void AddNewVehicle()
        {
            Console.Clear();
            Vehicle newVehicle = new Vehicle();

            Console.WriteLine("You are entering information for a NEW vehicle");
            Console.WriteLine("Please verify all information is correct when entering");
            Console.WriteLine("Please enter a Make");
            newVehicle.Make = Console.ReadLine();

            Console.WriteLine("Please enter a Model");
            newVehicle.Model = Console.ReadLine();

            Console.WriteLine("Please enter a Year for the vehicle");
            newVehicle.Year = Console.ReadLine();

            Console.WriteLine("Please enter the mileage per TANK that this vehicle gets. If it is an electric car, please enter the miles per charge.");
            string mileageAsString = Console.ReadLine();
            double mileageAsDouble = double.Parse(mileageAsString);
            newVehicle.MileagePerGallon = mileageAsDouble;


            Console.WriteLine("Please select the numbers listed below to indicate what type of category this vehicle falls under:");
            Console.WriteLine("1. Gas");
            Console.WriteLine("2. Hybrid");
            Console.WriteLine("3. Electric");
            string vehicleType = Console.ReadLine();

            int vehicleTypeInt = int.Parse(vehicleType);
            newVehicle.VehicleType = (VehicleType)vehicleTypeInt;


            bool custAdded = _repo.AddVehicle(newVehicle);
            if (custAdded == true)
            {
                Console.WriteLine("Vehicle was successfully added!");
            }
            else
            {
                Console.WriteLine("Oops! Something went wrong. Please try again.");
            }

        }
        private void UpdateExistingVehicle()
        {
            Console.Clear();
            Console.WriteLine("Enter the MAKE of the vehicle you'd like to update.");
            string make = Console.ReadLine();
            Vehicle oldVehicle = _repo.GetVehicleByMake(make);

            Vehicle newVehicle = new Vehicle(
                oldVehicle.Make,
                oldVehicle.Model,
                oldVehicle.Year,
                oldVehicle.MileagePerGallon,
                oldVehicle.VehicleType);

            if (oldVehicle == null)
            {
                Console.WriteLine("Vehicle not found. Are you sure you searched by the MAKE of the vehicle?");
                Console.WriteLine("Please try again");
                Console.ReadKey();
                return;
            }

            Console.WriteLine(" Enter the number of the option you'd like to update:");
            Console.WriteLine("1. Make");
            Console.WriteLine("2. Model");
            Console.WriteLine("3. Year");
            Console.WriteLine("4. Mileage per Gallon/Charge");
            Console.WriteLine("5. Vehicle Type");

            string itemToUpdate = Console.ReadLine();
            switch (itemToUpdate)
            {
                case "1":
                    Console.WriteLine("Enter a new Make");
                    string newMake = Console.ReadLine();
                    oldVehicle.Make = newMake;
                    bool isChangingMake = _repo.UpdateVehicle(make, newVehicle);

                    if (!isChangingMake)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: could not update {make}");
                    }
                    Console.WriteLine("Press Any Key to Continue");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Enter a new Model");
                    string newModel = Console.ReadLine();
                    oldVehicle.Model = newModel;
                    bool isChangingModel = _repo.UpdateVehicle(newModel, newVehicle);

                    if (!isChangingModel)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: could not update {newModel}");
                    }
                    Console.WriteLine("Press Any Key to Continue");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Enter a new Year as YYYY ");
                    string newYear = Console.ReadLine();
                    oldVehicle.Year = newYear;
                    bool isChangingYear = _repo.UpdateVehicle(newYear, newVehicle);

                    if (!isChangingYear)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: could not update {newYear}");
                    }
                    Console.WriteLine("Press Any Key to Continue");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Enter the mileage per gallon/charge of this vehicle:");
                    string mileageAsString = Console.ReadLine();
                    double mileageAsDouble = double.Parse(mileageAsString);
                    oldVehicle.MileagePerGallon = mileageAsDouble;
                    bool isChangingMileage = _repo.UpdateVehicle(mileageAsString, newVehicle);

                    if (!isChangingMileage)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: could not update {mileageAsString}");
                    }
                    Console.WriteLine("Press Any Key to Continue");
                    Console.ReadLine();
                    break;
                case "5":

                    Console.WriteLine("Enter a number for the Vehicle Type:");
                    Console.WriteLine("1. Gas");
                    Console.WriteLine("2. Hybrid");
                    Console.WriteLine("3. Electric");

                    string vehicleType = Console.ReadLine();
                    switch (vehicleType)
                    {
                        case "1":
                            oldVehicle.VehicleType = VehicleType.Gas;
                            break;
                        case "2":
                            oldVehicle.VehicleType = VehicleType.Hybrid;
                            break;
                        case "3":
                            oldVehicle.VehicleType = VehicleType.Electric;
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
        public void DeleteVehicle()
        {
            ShowAllVehicles();
            Console.Clear();
            Console.WriteLine("Enter the make of the vehicle you would like to delete");
            string makeToDelete = Console.ReadLine();
            Vehicle vehicleToDelete = _repo.GetVehicleByMake(makeToDelete);
            bool wasDeleted = _repo.DeleteVehicle(vehicleToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("This vehicle was sucessfully deleted");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Oops! Something went wrong, please try again.");
            }
        }

    }
}

