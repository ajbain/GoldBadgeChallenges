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
            List<Badge> directory = repo.GetBadges();
            bool directoryHasContent = directory.Contains(badge);
            Assert.IsTrue(directoryHasContent);
        }
    }


}