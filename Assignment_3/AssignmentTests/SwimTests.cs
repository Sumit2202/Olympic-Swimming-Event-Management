using NUnit.Framework;
using System;
using Assignment_1;
namespace AssignmentTests
{
    [TestFixture()]
    public class SwimClassTest
    {
		[Test()]
		public void CorrectHeatIsInputtedInSwimClass()
		{
			//arrange
			Swim aSwim = new Swim(2,3,"1:9:00");
			//act
			int expected =2;
			//assert
			int actual =aSwim.Heat;
			Assert.AreEqual(expected,actual,"wrong");
		
		}

		[Test()]
        public void CorrectLaneIsInputtedInSwimClass()
        {
            //arrange
            Swim aSwim = new Swim(2, 3, "1:9:00");
            //act
            int expected =3;
            //assert
			int actual =aSwim.Lane;
            Assert.AreEqual(expected, actual, "wrong");

		}
        [Test()]
        public void CorrectTimeSwamIsInputtedInSwimClass()
        {
            //arrange
            Swim aSwim = new Swim(2, 3, "1:9:00");
            //act
			string expected ="1:9:00";
            //assert
			string actual =aSwim.TimeSwam;
            Assert.AreEqual(expected, actual, "wrong");

        }

        
    }
}
