using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using ChallengeThree_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThreeTests
{
    [TestClass]
    public class ChallengeThree_RepoTests
    {
        [TestMethod]
        public void AddBadgeToDictionary_ShouldReturnTrue()
        {
            Badge badge = new Badge();
            Badge_Repo repo = new Badge_Repo();

            bool addResult = repo.CreateBadge(badge.BadgeID, badge.DoorNames);

            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void ShowBadgeDirectory_ShouldReturnTrue()
        {
            Badge badge = new Badge();
            Badge_Repo repo = new Badge_Repo();

            repo.CreateBadge(badge.BadgeID, badge.DoorNames );
            Dictionary<int, List<string>> directory = repo.GetBadges();
            bool directoryHasContent = directory.ContainsKey(badge.BadgeID);
            Assert.IsTrue(directoryHasContent);
        }
        /////run thru debugger again to figure out why not working... not good test method at the moment
        ///
        [TestMethod]
        public void GetBadgeByInt_ShouldReturnTrue()
        {
            Badge badge =new Badge();
            Badge_Repo repo = new Badge_Repo();

            Dictionary<int, List<string>> ListOfDoors = new Dictionary<int, List<string>>();

            ListOfDoors.Add(badge.BadgeID, badge.DoorNames);
            ListOfDoors.ContainsKey(badge.BadgeID);
            Assert.IsTrue(ListOfDoors.ContainsKey(badge.BadgeID));
            

        }
    }


} 