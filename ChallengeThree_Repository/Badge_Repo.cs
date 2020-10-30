using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repository
{
    public class Badge_Repo
    {
        //private List<Badge> _badgeDirectory = new List<Badge>();
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        
        //create
        public bool CreateBadge(int badgeId, List<string> doorNames)
        {
            int startingCount = _badgeDictionary.Count;
            Badge badge = new Badge(badgeId, doorNames);
            _badgeDictionary.Add(badge.BadgeID, badge.DoorNames);
            bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }
        
        //read badge
        public Dictionary<int, List<string>> GetBadges()
        {
            return _badgeDictionary;
        }

        //read badge by id??

        public List<string> GetBadgeByID(int ID)
        {
            if (_badgeDictionary.ContainsKey(ID))
            {
                return _badgeDictionary[ID];
            }
            else
            {
                return null;
            }
            //foreach (Badge badge in _badgeDirectory)
            //{
            //    if (badge.BadgeID == ID)
            //    {
            //        return badge;
            //    }
            //}
            
        }
        //updateBadge
        public void UpdateDictionaryEntry(int idNum, List<string> values)
        {
            //List<string> doorNames = GetBadgeByID(idNum); 
            if(_badgeDictionary.ContainsKey(idNum))
            {
                _badgeDictionary[idNum] = values;
                
            }
            else
            {
                _badgeDictionary.Add(idNum, values);
            }
        }







        //public Badge GetBadgeID (int idNum)
        //{
        //    foreach (KeyValuePair<int, List<string>> badges in _badgeDictionary)
        //    {
        //        if(badges.Key == idNum)
        //        {
        //            return badges;
        //        }
        //    }
        //    return null;
        //}






        //deleteBadge
    }
}
