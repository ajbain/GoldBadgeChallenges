using System;
using System.Collections.Generic;
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
    }


    }