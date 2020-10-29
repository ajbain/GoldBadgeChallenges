using System;
using ChallengeThree_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThreeTests
{
    [TestClass]
    public class ChallengeThree_Tests
    {
        [TestMethod]
        public void SetBadge_ShouldReturnCorrectItem()
        {
            Badge badge = new Badge();
            badge.BadgeID = 001;
            Assert.AreEqual(badge.BadgeID, 001);
        }
    }
}
