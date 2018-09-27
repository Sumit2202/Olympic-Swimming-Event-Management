using NUnit.Framework;
using System;
using Assignment_1;
namespace AssignmentTests
{
	[TestFixture()]
    public class SwimMeetTests
    {
		[Test()]
        public void NameOfSwimMeetInputingCorrectly()
        {
			//arrange
			SwimMeet aSwimMeet = new SwimMeet("leagues",new DateTime(2018,06,21),new DateTime(2018,07,12),PoolType.LCM,3);
			string expected = "leagues";

			//act

			//assert
			string actual = aSwimMeet.Name;
			Assert.AreEqual(expected,actual);

        }  

		[Test()]
		public void EndDateOfSwimMeetInputingCorrectly()
        {
            //arrange
            SwimMeet aSwimMeet = new SwimMeet("leagues",new DateTime(2018,06,21),new DateTime(2018,07,12),PoolType.LCM,3);
			DateTime expected = new DateTime(2018, 07, 12);

            //act

            //assert
			DateTime actual = aSwimMeet.EndDate;
            Assert.AreEqual(expected,actual);

        } 

		[Test()]
		public void StartDateOfSwimMeetInputingCorrectly()
        {
            //arrange
            SwimMeet aSwimMeet = new SwimMeet("leagues",new DateTime(2018,06,21),new DateTime(2018,07,12),PoolType.LCM,3);
			DateTime expected = new DateTime(2018,06,21);

            //act

            //assert
			DateTime actual = aSwimMeet.StartDate;
            Assert.AreEqual(expected,actual);

        } 

		[Test()]
		public void PoolTypeOfSwimMeetInputingCorrectly()
        {
            //arrange
            SwimMeet aSwimMeet = new SwimMeet("leagues",new DateTime(2018,06,21),new DateTime(2018,07,12),PoolType.LCM,3);
			PoolType expected = PoolType.LCM;

            //act

            //assert
			PoolType actual = aSwimMeet.APoolType;
            Assert.AreEqual(expected,actual);

        } 
		[Test()]
		public void NoOfLanesOfSwimMeetInputingCorrectly()
        {
            //arrange
            SwimMeet aSwimMeet = new SwimMeet("leagues",new DateTime(2018,06,21),new DateTime(2018,07,12),PoolType.LCM,3);
            int expected = 3;

            //act

            //assert
			int actual = aSwimMeet.NoOfLanes;
            Assert.AreEqual(expected,actual);

        }
		[Test()]
        public void AddEventOfSwimMeetInputingEventCorrectly()
        {
            //arrange
            SwimMeet aSwimMeet = new SwimMeet("leagues",new DateTime(2018,06,21),new DateTime(2018,07,12),PoolType.LCM,3);
			Event aEvent = new Event();
			Event expected = aEvent;
			//act
			aSwimMeet.AddEvent(aEvent);
			//assert
			Event actual = aSwimMeet.collOfEvents[aSwimMeet.noOfEvents-1];
            Assert.AreEqual(expected,actual);
        }  


    }
}
