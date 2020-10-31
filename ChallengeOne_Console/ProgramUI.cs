using ChallengeOne_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Console
{
    public class ProgramUI
    {
        private Menu_Repo _repo = new Menu_Repo();
        public void Run()
        {
            SeedContent();
            Menu();
        }
        private void SeedContent()
        {
            Menu mealOne = new Menu(
                001, "The Plain Jane", "This is for the picky eaters out there, nothing in this meal will surprise you.", "Hamburger, Fries", 3.00);
            _repo.AddToMenu(mealOne);
            Menu mealTwo = new Menu(
                002, "Adventurous Jane", "This is for the slightly more adventurous janes--the ones that like dairy.", "Cheeseburger, Fries", 3.50);
            _repo.AddToMenu(mealTwo);
            Menu mealThree = new Menu(
                003, "The reg", "This is the regular", "Cheeseburgers, pickles, onions, lettuce, tomatoes", 4.50);
            _repo.AddToMenu(mealThree);


        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.Clear();
                Console.WriteLine(" ___   _  _______  __   __  _______  ______   _______    _______  _______  _______  _______  __  ");
                Console.WriteLine("|   | | ||       ||  |_|  ||       ||      | |       |  |       ||   _   ||       ||       ||  | ");
                Console.WriteLine("|   |_| ||   _   ||       ||   _   ||  _    ||   _   |  |       ||  |_|  ||    ___||    ___||  | ");
                Console.WriteLine("|      _||  | |  ||       ||  | |  || | |   ||  | |  |  |       ||       ||   |___ |   |___ |  | ");
                Console.WriteLine("|     |_ |  |_|  ||       ||  |_|  || |_|   ||  |_|  |  |      _||       ||    ___||    ___||__| ");
                Console.WriteLine("|    _  ||       || ||_|| ||       ||       ||       |  |     |_ |   _   ||   |    |   |___  __  ");
                Console.WriteLine("|___| |_||_______||_|   |_||_______||______| |_______|  |_______||__| |__||___|    |_______||__| ");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("Welcome to Komodo Cafe Menu Organizer!");
                Console.WriteLine("Please select the option you would like to use.".PadRight(3,' '));
                Console.WriteLine("1. Show All Items on Menu".PadLeft(3, ' '));
                Console.WriteLine("2. Find Items by Menu Number".PadLeft(3, ' '));
                Console.WriteLine("3. Add a New Item".PadLeft(3, ' '));
                Console.WriteLine("4. Delete a Menu Item".PadLeft(3, ' '));
                Console.WriteLine("5. Exit".PadLeft(3, ' '));

               
                

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllItems();
                        //need to put in alphabetical order
                        break;
                    case "2":
                        ShowItemsByMenuNumber();
                        //finds customers by last name
                        break;
                    case "3":
                        AddNewItem();
                        //adds a new customer
                        break;
                    case "4":
                        DeleteItemFromMenu();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response (1-5)");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void DisplayItems(Menu  menu)
        {

            Console.WriteLine($"{menu.MealNumber}        {menu.MealName}        {menu.Description}           {menu.Ingredients}          {menu.Price}  ");
        }

        private void ShowAllItems()
        {
            Console.Clear();
            List<Menu> listOfItems = _repo.GetItems();
            foreach (Menu menu in listOfItems)
            {
                DisplayItems(menu);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }


        private void ShowItemsByMenuNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of the menu item that you are looking for:");
            string menuNumAsString = Console.ReadLine();
            int menuNumAsInt = int.Parse(menuNumAsString);

            Menu menu = _repo.GetMenuItemByNumber(menuNumAsInt);
            if (menu != null)
            {
                DisplayItems(menu);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("I'm not sure what menu item you are looking for. That item either 1.) Does not exist, or 2.) Something was spelled incorrectly.");
                Console.WriteLine("Please ensure the number is correct and try again. Press any key to return to main menu.");
                Console.ReadKey();
            }


        }
        private void AddNewItem()
        {
            Console.Clear();
            Menu newMenu = new Menu();

            Console.WriteLine("You are entering information for a NEW Menu Item!");
            Console.WriteLine("Please verify all information is correct when entering");
            Console.WriteLine("Please enter a Meal Number:");
            newMenu.MealNumber = Convert.ToInt32(Console.ReadLine());
             

            Console.WriteLine("Please enter a Meal Name:");
            newMenu.MealName = Console.ReadLine();

            Console.WriteLine("Please enter a description of the meal:");
            newMenu.Description = Console.ReadLine();

            Console.WriteLine("Please enter the ingredients of the meal:");
            newMenu.Ingredients = Console.ReadLine();

            Console.WriteLine("Please enter the price of the item:");
            string priceAsString = Console.ReadLine();
            double priceAsDouble = double.Parse(priceAsString);
            newMenu.Price = priceAsDouble;

            bool itemAdded = _repo.AddToMenu(newMenu);
            if (itemAdded == true)
            {
                Console.WriteLine("Menu item was successfully added!");
            }
            else
            {
                Console.WriteLine("Oops! Something went wrong. Please try again.");
            }

        }
        
        public void DeleteItemFromMenu()
        {
            Console.WriteLine("Here's a list of what is currently on the menu:");
            ShowAllItems();
            //Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Enter the menu number of the item you'd like to delete:");
            string itemToDeleteAsString = Console.ReadLine();
            
            int itemToDeleteAsInt = int.Parse(itemToDeleteAsString);

            Menu itemToDelete = _repo.GetMenuItemByNumber(itemToDeleteAsInt);
            bool wasDeleted = _repo.DeleteItem(itemToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("This item was sucessfully deleted");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Oops! Something went wrong, please try again.");
            }
        }

    }
}


