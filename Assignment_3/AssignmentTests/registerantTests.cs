using NUnit.Framework;
using System;
using Assignment_1;
namespace AssignmentTests
{
	[TestFixture()]
    public class registerantTests
    {
		[Test()]
        public void AddressStructInputingCorrectStreetname()
        {
			//arrange
			Address aAddress = new Address("Progress", "toronto", "ontario", "m1b0c4");
			string expected = "Progress";
			//act

			//assert
			string actual = aAddress.StreetName;
			Assert.AreEqual(expected, actual,"wrong");
            
        }

		[Test()]
		public void AddressStructInputingCorrectCity()
		{
			//arrange
            Address aAddress = new Address("progress", "toronto", "ontario", "m1b0c4");
            string expected = "toronto";
            //act

            //assert
            string actual = aAddress.City;
            Assert.AreEqual(expected, actual, "wrong");

		}

		[Test()]
        public void AddressStructInputingCorrectProvince()
        {
            //arrange
            Address aAddress = new Address("progress", "toronto", "ontario", "m1b0c4");
            string expected = "ontario";
            //act

            //assert
			string actual = aAddress.Province;
            Assert.AreEqual(expected, actual, "wrong");

        }

		[Test()]
        public void AddressStructInputingCorrectZipcode()
        {
            //arrange
            Address aAddress = new Address("progress", "toronto", "ontario", "m1b0c4");
            string expected = "m1b0c4";
            //act

            //assert
			string actual = aAddress.ZipCode;
            Assert.AreEqual(expected, actual, "wrong");

        }
        
        [Test()]
        public void ConstructorInputingCorrectName()
        {
            //arrange
			Registrant.count2 = 0;
            
            Address aAddress = new Address();
			Registrant aRegisterant = new Registrant("Sam", new DateTime(), aAddress, 1234567891);
            string expected = "Sam";
            //act

            //assert
			string actual = aRegisterant.Name;
            Assert.AreEqual(expected, actual, "wrong");
        }

		[Test()]
        public void ConstructorInputingCorrectPhoneNumber()
        {
            //arrange
            Address aAddress = new Address();
			Registrant aRegisterant = new Registrant("Sam", new DateTime(), aAddress, 1234567891); 
            long expected = 1234567891;
            //act

            //assert
			long actual = aRegisterant.PhoneNumber;
            Assert.AreEqual(expected, actual, "wrong");

        }
        [Test()]
        [ExpectedException(typeof(Exception))]
        public void PhoneNumberIncorrectFormatExceptionThrow()
        {
            //arrange
            Address aAddress = new Address();
			Registrant aRegisterant = new Registrant("Sam", new DateTime(), aAddress, 123456789);
            //act

            //assert
        }

		[Test()]
		public void ConstructorInputingCorrectDateTime()
        {
            //arrange
			Registrant.count2 = 0;
            Address aAddress = new Address();
			Registrant aRegisterant = new Registrant("Sam", new DateTime(2000,6,22), aAddress, 1234567891);
			DateTime expected = new DateTime(2000,6,22);
            //act

            //assert
			DateTime actual = aRegisterant.DateOfBirth;
            Assert.AreEqual(expected, actual, "wrong");
        }

		[Test()]
		public void ClubPropertyWorkingProperlyWhenRegisterantIsNotAssignedToAnyClub()
		{
			//arrange
			Registrant.count2 = 0;
			Club.count = 0;
			Address aAddress = new Address();
			Club aClub = new Club();
			Registrant aRegisterant = new Registrant("Sam", new DateTime(2000, 6, 22), aAddress, 1234567891);
			Club expected = aClub;
			//act
			aRegisterant.AssignedClub = aClub;
			//assert
			Club actual =aRegisterant.Club;
			Assert.AreEqual(expected,actual,"wrong");

		}

		[Test()]
		[ExpectedException(typeof(Exception))]
        public void ClubPropertyThrowingExxceptionWhenRegisterantIsAlreadyAssignedToAnotherClub()
        {
            //arrange
            Address aAddress = new Address();
            Club aClub = new Club();
			Club anotherClub = new Club();
            
			Registrant aRegisterant = new Registrant("Sam", new DateTime(2000, 6, 22), aAddress, 1234567891);
			//act
			aRegisterant.Club = aClub;
			aRegisterant.Club = anotherClub;

            //assert

        }
    }
}
