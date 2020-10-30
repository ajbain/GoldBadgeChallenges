using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repository
{
     public class Menu_Repo
    {
        private List<Menu> _menuDirectory = new List<Menu>();
         

        public bool AddToMenu(Menu menu)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(menu);
            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Menu> GetItems()
        {
            return _menuDirectory;
        }

        public Menu GetMenuItemByNumber(int menuNum)
        {
            foreach (Menu menu in _menuDirectory)
            {
                if (menu.MealNumber == menuNum)
                {
                    return menu;
                }
            }
            return null;
        }

        public bool DeleteItem(Menu existingItem)
        {
            bool deleteResult = _menuDirectory.Remove(existingItem);
            return deleteResult;
        }
    }
}
