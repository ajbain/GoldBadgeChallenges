using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repository
{
    public class Badge_Repo
    {
        private List<Badge> _badgeDirectory = new List<Badge>();
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
        public List<Badge> GetBadges()
        {
            return _badgeDirectory;
        }



        //updateBadge



        //deleteBadge
    }
}
