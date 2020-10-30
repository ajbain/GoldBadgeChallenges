using System;
using System.Collections.Generic;
using ChallengeOne_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOneTests
{
    [TestClass]
    public class ChallengeOne_RepoTests
    {
        [TestMethod]
        public void AddItemToMenu_ShouldReturnTrue()
        {
            Menu menu = new Menu();
            Menu_Repo repo = new Menu_Repo();

            bool addResult = repo.AddToMenu(menu);

            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void ShowMenuDirectory_ShouldReturnTrue()
        {
            Menu menu = new Menu();
            Menu_Repo repo = new Menu_Repo();
            repo.AddToMenu(menu);

            List<Menu> directory = repo.GetItems();

            bool directoryHasContent = directory.Contains(menu);

            Assert.IsTrue(directoryHasContent);

        }

        [TestMethod]
        public void GetMenuByMenuNumber_ShouldBeEqual()
        {
            Menu menu = new Menu(001, "the burg", "Saucy with spice",
                "Pepperjack and oranges",  12.00);
            Menu_Repo repo = new Menu_Repo();
            repo.AddToMenu(menu);
            int menuNum = 001;
            Menu searchNumber = repo.GetMenuItemByNumber(menuNum);

            Assert.AreEqual(menuNum, searchNumber.MealNumber);

        }
        [TestMethod]
        public void DeleteAMenuItem_ShouldReturnTrue()
        {
            Menu menu = new Menu(001, "the burg", "Saucy with spice",
                "pepperJack and oranges", 12.00);
            Menu_Repo repo = new Menu_Repo();
            repo.AddToMenu(menu);

            Menu oldMenu = repo.GetMenuItemByNumber(001);
            bool removeResults = repo.DeleteItem(oldMenu);
            Assert.IsTrue(removeResults);
        }
    }
}
