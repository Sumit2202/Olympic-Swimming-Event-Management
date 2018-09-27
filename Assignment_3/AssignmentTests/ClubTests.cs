using NUnit.Framework;
using System;
using Assignment_1;
namespace AssignmentTests
{
    [TestFixture()]
    public class ClubTests
    {
		[Test()]
		public void ParameterlessConstructorClubNumberCheck()
		{

			//arrange
			Club aClub = new Club();
			int expected = Club.count;
			//act

			//assert
			int actual = aClub.ClubNumber;
			Assert.AreEqual(expected, actual, "wrong");
		}
		[Test()]
		public void UniqueClubNumberValidatorWhenClubNumberAlreadyPresent()
		{

			//arrange
			Club.count = 0;
			Club aClub = new Club();
            int clubNumToCheck = 101;
            int[] uniqueClubNumberCollection = { 1, 2, 3, 101, 4 };

            //act
			bool actual = aClub.UniqueClubNumberValidator(clubNumToCheck, uniqueClubNumberCollection);
			//assert
			Assert.IsFalse(actual);
		}

		[Test()]
        public void UniqueClubNumberValidatorWhenClubNumberisUnique()
        {

			//arrange
			Club.count = 0;
			Club aClub = new Club();
            int clubNumToCheck = 201;
            int[] uniqueClubNumberCollection = { 1, 2, 3, 101, 4 };

            //act
			bool actual = aClub.UniqueClubNumberValidator(clubNumToCheck, uniqueClubNumberCollection);
            //assert
			Assert.IsTrue(actual);
        }
		[Test()]
		public void ConstructorInputingCorrectClubNumber()
		{
			//arrange
			Address aAddress=new Address();
			Club aClub = new Club(111,"my club",aAddress,1234567891);
			int expected = 111;
			//act

			//assert
			int actual = aClub.ClubNumber;
			Assert.AreEqual(expected,actual,"wrong");
		}
		[Test()]
        public void ConstructorInputingCorrectClubName()
        {
            //arrange
            Address aAddress = new Address();
			Club aClub = new Club(112, "my club", aAddress, 1234567891);
            string expected = "my club";
            //act

            //assert
			string actual = aClub.Name;
            Assert.AreEqual(expected, actual, "wrong");
        }
		[Test()]
        public void ConstructorInputingCorrectAddressStreetName()
        {
            //arrange
            Address aAddress = new Address("progress","toronto","ontario","m1b0c4");
			Club aClub = new Club(113, "Sam", aAddress, 1234567891);
			string expected = "progress";
            //act

            //assert
			string actual = aAddress.StreetName;
            Assert.AreEqual(expected, actual, "wrong");
        }
		[Test()]
        public void ConstructorInputingCorrectAddressCity()
        {
            //arrange
            Address aAddress = new Address("progress", "toronto", "ontario", "m1b0c4");
			Club aClub = new Club(114, "Sam", aAddress, 1234567891);
            string expected = "toronto";
            //act

            //assert
			string actual = aAddress.City;
            Assert.AreEqual(expected, actual, "wrong");
        }
		[Test()]
        public void ConstructorInputingCorrectAddressProvince()
        {
            //arrange
            Address aAddress = new Address("progress", "toronto", "ontario", "m1b0c4");
			Club aClub = new Club(115, "Sam", aAddress, 1234567891);
            string expected = "ontario";
            //act

            //assert
			string actual = aAddress.Province;
            Assert.AreEqual(expected, actual, "wrong");
        }
		[Test()]
        public void ConstructorInputingCorrectAddressZipCode()
        {
            //arrange
            Address aAddress = new Address("progress", "toronto", "ontario", "m1b0c4");
			Club aClub = new Club(116, "Sam", aAddress, 1234567891);
            string expected = "m1b0c4";
            //act

            //assert
			string actual = aAddress.ZipCode;
            Assert.AreEqual(expected, actual, "wrong");
        }

		[Test()]
		[ExpectedException(typeof(Exception))]
        public void SimilarClubNumberInputingAgainThrowError()
		{
			//arrange
			Address aAddress = new Address();
			Club aClub = new Club(117, "my club", aAddress, 1234567891);
			//act

			//assert   
		}

		[Test()]
        public void ConstructorInputingCorrectPhoneNumber()
        {
            //arrange
            Address aAddress = new Address();
			Club aClub = new Club(117, "my club", aAddress, 1234567891);
            long expected = 1234567891;
            //act

            //assert
			long actual = aClub.PhoneNumber;
            Assert.AreEqual(expected, actual, "wrong");
            
        }  
		[Test()]
        [ExpectedException(typeof(Exception))]
		public void PhoneNumberIncorrectFormatExceptionThrow()
		{
			//arrange
            Address aAddress = new Address();
			Club aClub = new Club(118, "my club", aAddress, 123456789);
            //act

            //assert
		}
   
    }
}
