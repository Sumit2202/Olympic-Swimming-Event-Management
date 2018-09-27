using NUnit.Framework;
using System;
using Assignment_1;
namespace AssignmentTests
{
	[TestFixture()]
	public class EventTests
	{
		[Test()]
		public void SwimmerAlreadyEnteredInEventTrue()
		{
			//arrange
			Registrant aRegisterant = new Registrant();
			Event aEvent = new Event();

			//act
			aEvent.AddSwimmer(aRegisterant);
			//assert
			bool actual = aEvent.AlreadyEntered(aRegisterant, aEvent.CollOfRegisterants);
			Assert.IsTrue(actual);
		}

		[Test()]
		public void SwimmerIsNotAlreadyEntered()
		{
			//arrange
			Registrant aRegisterant = new Registrant();
			Event aEvent = new Event();

			//act

			//assert
			bool actual = aEvent.AlreadyEntered(aRegisterant, aEvent.CollOfRegisterants);
			Assert.IsFalse(actual);
		}

		[Test()]
		public void CorrectStrokeIsAdded()
		{
			//arrange
			Event aEvent = new Event();
			Stroke aStroke = Stroke.Butterfly;
			aEvent.Stroke = aStroke;
			Stroke expected = Stroke.Butterfly;
			//act

			//assert
			Stroke actual = aEvent.Stroke;
			Assert.AreEqual(expected, actual, "Wrong");
		}

		[Test()]
		public void CorrectDistanceIsAdded()
		{
			//arrange
			Event aEvent = new Event();
			EventDistance aDistance = EventDistance._100;
			aEvent.Distance = aDistance;
			EventDistance expected = EventDistance._100;
			//act

			//assert
			EventDistance actual = aEvent.Distance;
			Assert.AreEqual(expected, actual, "Wrong");
		}

		[Test()]
		public void AddSwimmerIsCorrectlyAddingSwimmerToEvent()
		{
			//arrange
			Event aEvent = new Event();
			Registrant anotherRegisterant = new Registrant();
			aEvent.AddSwimmer(anotherRegisterant);
			Registrant expected = anotherRegisterant;

			//act

			//assert
			Registrant actual = aEvent.CollOfRegisterants[0];
			Assert.AreEqual(expected, actual, "wrong");
		}

		[Test()]
		[ExpectedException(typeof(Exception))]
		public void AddSwimmerIsThrowingExceptionwhenAAlreadyAddedSwimmerIsAddedAgainToSameEvent()
		{
			//arrange
			Event aEvent = new Event();
			Registrant anotherRegisterant = new Registrant();
			aEvent.AddSwimmer(anotherRegisterant);
			//act
			aEvent.AddSwimmer(anotherRegisterant);
			//assert
		}

		/*[Test()]
		public void CorrectTimeIsInputedInTimeSwamOfSwimClassObject()
		{
			//arrange
			Event aEvent = new Event();
			Swim aSwim = new Swim();
			Registrant anotherRegisterant = new Registrant();
			aEvent.AddSwimmer(anotherRegisterant);
			aEvent.EnterSwimmersTime(anotherRegisterant, "1:0:0");
			string expected = "1:0:0";

			//act

			//assert
			string actual = aEvent.CollOfSwims[aEvent.NumOfRegisterant - 1].TimeSwam;
			Assert.AreEqual(expected, actual, "wrong");
		}*/
		[Test()]
		[ExpectedException(typeof(Exception))]
		public void ExceptionIsThrownWhenTimeSwamOfASwimmerIsTriedToInputWhoHasNotEnteredThatEvent()
		{
			//arrange
			Event aEvent = new Event();
			Swim aSwim = new Swim();
			Registrant anotherRegisterant = new Registrant();
			//act
			aEvent.EnterSwimmersTime(anotherRegisterant, "1:0:0");
			//assert
		}
		[Test()]
		public void SeedingMethodGivesCorrectHeat()
		{
			//arrange
            Event aEvent = new Event();
			Registrant aRegisterant = new Registrant();
			Registrant anotherRegisterant = new Registrant();
			aEvent.AddSwimmer(aRegisterant);
			aEvent.AddSwimmer(anotherRegisterant);
			aEvent.Seed(5);
			int expected =1;
			//act

			//assert
			int actual =aEvent.CollOfSwims[aEvent.NumOfRegisterant-1].Heat;
			Assert.AreEqual(expected, actual, "wrong");
		}

		[Test()]
        public void SeedingMethodGivesCorrectLane()
        {
			//arrange
			Registrant.count1 = 0;
            Event aEvent = new Event();
            Registrant aRegisterant = new Registrant();
            Registrant anotherRegisterant = new Registrant();
            aEvent.AddSwimmer(aRegisterant);
            aEvent.AddSwimmer(anotherRegisterant);
            aEvent.Seed(5);
            int expected =2;
            //act

            //assert
			int actual =aEvent.CollOfSwims[aEvent.NumOfRegisterant-1].Lane;
            Assert.AreEqual(expected, actual, "wrong");
        }

	}
}
