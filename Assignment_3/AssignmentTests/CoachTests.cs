using System;
using NUnit.Framework;
using Assignment_1;
using System.Collections.Generic;

namespace AssignmentTests
{
	[TestFixture()]
	public class CoachTests
	{
		[Test()]
		public void CoachIsAssignedToClubWorksCorrect()
		{
			//arrange
			Club.count = 0;
			Coach aCoach = new Coach("dave",new DateTime(),new Address(),1234567890);
			Club aClub = new Club();

            //act
			aClub.AddCoach(aCoach);
			bool expected = true;
			//Assert
			bool actual = aCoach.CoachIsAssignedToClub;
			Assert.AreEqual(expected, actual);
		}

		[Test()]
        public void AssignedClubToCoachGivesRightClubObject()
        {
            //arrange
			Club.count = 0;
            Coach aCoach = new Coach("dave", new DateTime(), new Address(), 1234567890);
            Club aClub = new Club();
            //act
            aClub.AddCoach(aCoach);
			Club expected = aClub;
            //Assert
			Club actual = aCoach.AssignedClubToCoach;
            Assert.AreEqual(expected, actual);
        }
		[Test()]
        public void CredentialsOfCoachAreCorrect()
        {
            //arrange
            Coach aCoach = new Coach("dave", new DateTime(), new Address(), 1234567890);
			//act
			aCoach.Credentials = "NNCA";
            string expected = "NNCA";
            //Assert
			string actual = aCoach.Credentials;
            Assert.AreEqual(expected, actual);
        }

		[Test()]
        public void AddSwimmerMethodWorkingProperly()
        {
            //arrange
			Club.count = 0;
			Swimmer aSwimmer = new Swimmer();
			Club aClub = new Club();
			Coach aCoach = new Coach("dave", new DateTime(), new Address(), 1234567890);
            //act
			aClub.AddCoach(aCoach);
			aClub.AddSwimmer(aSwimmer);
			aCoach.AddSwimmer(aSwimmer);
			Swimmer expected = aSwimmer;
            //Assert
			Swimmer actual = aCoach.listOfSwimmers[0];
            Assert.AreEqual(expected, actual);
        }

		[Test()]
		[ExpectedException(typeof(Exception))]
        public void AddSwimmerMethodGivingExceptionWhenCoachIsNotRegisteredToAClub()
        {
            //arrange
            Club.count = 0;
            Swimmer aSwimmer = new Swimmer();
            Club aClub = new Club();
            Coach aCoach = new Coach("dave", new DateTime(), new Address(), 1234567890);
            //act
           // aClub.AddCoach(aCoach);
            aClub.AddSwimmer(aSwimmer);
            aCoach.AddSwimmer(aSwimmer);
            Swimmer expected = aSwimmer;
            //Assert
        }

		[Test()]
        [ExpectedException(typeof(Exception))]
        public void AddSwimmerMethodGivingExceptionWhenCoachIsNotRegisteredToTheSameClubAsThatOfSwimmer()
        {
            //arrange
            Club.count = 0;
            Swimmer aSwimmer = new Swimmer();
            Club aClub = new Club();
            Coach aCoach = new Coach("dave", new DateTime(), new Address(), 1234567890);
            //act
            aClub.AddCoach(aCoach);
            //aClub.AddSwimmer(aSwimmer);
            aCoach.AddSwimmer(aSwimmer);
            Swimmer expected = aSwimmer;
            //Assert
        }

	}
}
   