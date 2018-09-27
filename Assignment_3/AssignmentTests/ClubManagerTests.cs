using System;
using NUnit.Framework;
using Assignment_1;
using System.Collections.Generic;

namespace AssignmentTests
{
	[TestFixture()]
    public class ClubManagerTests
    {
		[Test()]
		public void ClubAreGettingAddedByClubProperty()
		{
			//arrange
			ClubsManager aClubManager = new ClubsManager();
			Club aClub = new Club();
			Club anotherClub = new Club();
            
			//act
			Club expected =aClub;
			aClubManager.Clubs.Add(aClub);
			//assert
			List<Club> actual = new List<Club>();
            
			actual = aClubManager.Clubs;
			Assert.AreEqual(expected, actual[0]);
		}

		[Test()]
		public void NumberOfClubsAreGettingAddedByNumberProperty()
		{
			//arrange
			ClubsManager aClubManager = new ClubsManager();
            Club aClub = new Club();
            Club anotherClub = new Club();

			//act
			aClubManager.Add(aClub);
			aClubManager.Add(anotherClub);
			int expexted = 2;

			//assert
			int actual = aClubManager.Number;
			Assert.AreEqual(expexted, actual);		
		}


		[Test()]
		public void GetByRegNoWorkingProperly()
		{
			//arrange
			ClubsManager aClubManager = new ClubsManager();
			Address aAddress = new Address();
			Club aClub = new Club(118, "my club", aAddress, 1234567890);

            //act
			aClubManager.Add(aClub);
			Club expected = aClub;
			//assert
			Club actual = aClubManager.GetByRegNum(118);
			Assert.AreEqual(expected, actual);
            
		}
		[Test()]
		public void AddProperlyWorkingProperly()
		{
			//arrange
			ClubsManager aClubManager = new ClubsManager();
            Club aClub = new Club();
            //act
			aClubManager.Add(aClub);
			Club expected = aClub;
            //assert
            Club actual =aClubManager.Clubs[0];
			Assert.AreEqual(expected,actual);
		}
    }
}
