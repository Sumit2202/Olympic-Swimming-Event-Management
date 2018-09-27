using System;
namespace Assignment_1
{
	[Serializable]
	public class Swimmer:Registrant
    {

		Coach assignedCoach;
		public Swimmer(string name,DateTime dateOfBirth,Address aAddress,long phonenumber):base(name,dateOfBirth,aAddress,phonenumber)
		{
			
		}
		public Swimmer()
		{
			
		}
		public TimeSpan GetBestTime(PoolType aPoolType,Stroke aStroke,EventDistance aEventDistance)
		{
			 int indexOfSwimmerInCollection = 0;
            for (int i = 0; i < (CollOfEvents.Find((Event aEvent) => (aEvent.Distance == aEventDistance &&
                                                aEvent.Stroke == aStroke &&
                                                aEvent.PoolTypeOfEvent == aPoolType
                                                )
                                                  ).NumOfRegisterant); i++)
            {
                if (CollOfEvents.Find((Event aEvent) => (aEvent.Distance == aEventDistance &&
                                                aEvent.Stroke == aStroke &&
                                                aEvent.PoolTypeOfEvent == aPoolType
                                                )
                                     ).CollOfRegisterants[i] == this)
                    indexOfSwimmerInCollection = i;
            }


			return CollOfEvents.Find((Event aEvent) => (aEvent.Distance == aEventDistance &&
											   aEvent.Stroke == aStroke &&
											   aEvent.PoolTypeOfEvent == aPoolType
											           )
									 ).CollOfSwims[indexOfSwimmerInCollection].bestTime;
			                                        
		}
		public void AddAsBestTime(PoolType aPoolType, Stroke aStroke, EventDistance aEventDistance, TimeSpan time)
		{
			int indexOfSwimmerInCollection = 0;
			for (int i = 0; i < (CollOfEvents.Find((Event aEvent) => (aEvent.Distance == aEventDistance &&
												aEvent.Stroke == aStroke &&
												aEvent.PoolTypeOfEvent == aPoolType
												)
												  ).NumOfRegisterant); i++)
			{
				if (CollOfEvents.Find((Event aEvent) => (aEvent.Distance == aEventDistance &&
												aEvent.Stroke == aStroke &&
												aEvent.PoolTypeOfEvent == aPoolType
												)
							 ).CollOfRegisterants[i] == this)
					indexOfSwimmerInCollection = i;
			}
			if (time < GetBestTime(aPoolType, aStroke, aEventDistance) ||
				GetBestTime(aPoolType, aStroke, aEventDistance) == new TimeSpan(0, 0, 0))
			{

				CollOfEvents.Find((Event aEvent) => (aEvent.Distance == aEventDistance &&
													aEvent.Stroke == aStroke &&
													aEvent.PoolTypeOfEvent == aPoolType
													)
								 ).CollOfSwims[indexOfSwimmerInCollection].bestTime = time;
			}
		}

		public Coach Coach
		{
			set
			{
				if(coachRegisteredInClubOfSwimmer==false)
				{
					throw (new Exception("coach not registered with the club"));
				}
				else
				{
					assignedCoach = value;
					value.AssignedClubToCoach = AssignedClub;
					value.listOfSwimmers.Add(this);
				}
				
			}
			get
			{
				return assignedCoach;

			}
            
		}
		public override  string ToString()
		{
			return base.ToString();
		}
    }
}