using System;
using ChallengeOne_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOneTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetMenuItem_ShouldReturnCorrectItem()
        {
            
                //arrange
                Menu menu = new Menu();

                //act
                menu.MealNumber= 001;


                //assert
                Assert.AreEqual(menu.MealNumber, 001);
            
        }
    }
    
}
