using System;
using NUnit.Framework;
using Assignment_1;
using System.Collections.Generic;

namespace AssignmentTests
{
	[TestFixture()]
	public class SwimmerManagerTests
	{
		[Test()]
		public void RegisterantsAreGettingAddedBySwimmersProperty()
		{
			//arrange
			ClubsManager aClubManager = new ClubsManager();
			SwimmersManager aSwimmerManager = new SwimmersManager(aClubManager);
			Registrant aRegisterant = new Registrant(); 

			//act
			Registrant expected = aRegisterant;
			aSwimmerManager.Swimmers.Add(aRegisterant);
			//assert
			List<Registrant> actual = new List<Registrant>();

			actual = aSwimmerManager.Swimmers;
			Assert.AreEqual(expected, actual[0]);
		}

		[Test()]
		public void NumberOfSwimmersAreGettingAddedByNumberProperty()
		{
			//arrange
			ClubsManager aClubManager = new ClubsManager();
			SwimmersManager aSwimmerManager = new SwimmersManager(aClubManager);
            Registrant aRegisterant = new Registrant();


			//act
			aSwimmerManager.Add(aRegisterant);
			int expexted = 1;

			//assert
			int actual = aSwimmerManager.Number;
			Assert.AreEqual(expexted, actual);
		}


		[Test()]
		public void GetByRegNoWorkingProperly()
		{
			//arrange
			Registrant.count2 = 0;
			Registrant.count1 = 0;
            
			ClubsManager aClubManager = new ClubsManager();
			SwimmersManager aSwimmerManager = new SwimmersManager(aClubManager);
            Registrant aRegisterant = new Registrant(); 

			//act
			aSwimmerManager.Add(aRegisterant);
			Registrant expected = aRegisterant;
			//assert
			Registrant actual = aSwimmerManager.GetByRegNum(1);
			Assert.AreEqual(expected, actual);

		}
		[Test()]
		public void AddProperlyWorkingProperly()
		{
			//arrange
			ClubsManager aClubManager = new ClubsManager();
			SwimmersManager aSwimmerManager = new SwimmersManager(aClubManager);
            Registrant aRegisterant = new Registrant(); 
			//act
            aSwimmerManager.Add(aRegisterant);
            Registrant expected = aRegisterant;
			//assert
			Registrant actual =aSwimmerManager.Swimmers[0];
			Assert.AreEqual(expected, actual);
		}
	}
}