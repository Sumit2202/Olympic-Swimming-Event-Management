using System;
using System.Collections.Generic;

namespace Assignment_1
{

	public enum EventDistance
    {
        _50, _100, _200, _400, _800, _1500
	};

	public enum Stroke
    {
        Butterfly , Backstroke, Breaststroke, Freestyle, Individualmedley
    };
	[Serializable]
	public class Event
	{
		public List<Registrant> CollOfRegisterants = new List<Registrant>();
        
		public int NumOfRegisterant;
		public bool IsAssignedToEvent;

		public List<Swim> CollOfSwims = new List<Swim>();

		public PoolType PoolTypeOfEvent;
		Swimmer aSwimmer;
		public bool SwimTimeEntered;
		public int NumOfSwims;

		public bool AlreadyEntered(Registrant swimmer,List <Registrant> collOfRegisterants)
		{
			for (int i = 0; i < NumOfRegisterant;i++)
			{
				if (collOfRegisterants[i] == swimmer)
					return true;
			}
			return false;
		}
        

		public Event(EventDistance distance, Stroke stroke)
		{
			Distance = distance;
			Stroke = stroke;
			SwimTimeEntered = false;
			IsAssignedToEvent = false;
		}

		public Event()
		{
			SwimTimeEntered = false;
            IsAssignedToEvent = false;

		}
		public EventDistance Distance
		{
            set;
            get;
        }
      

		public  Stroke Stroke
		{
            set;
            get;
        }
      

		public void AddSwimmer(Registrant swimmer)
		{
			if (!(AlreadyEntered(swimmer, CollOfRegisterants)))
			{

				swimmer.CollOfEvents.Add(this);
				CollOfRegisterants.Add(swimmer);
				CollOfSwims.Add(new Swim());
				NumOfRegisterant++;
				NumOfSwims++;
                
			}
			else
				throw(new Exception(String.Format("Swimmer {0}, {1} is already entered",swimmer.Name,swimmer.RegistrationNumber)));

		}
       
		public void EnterSwimmersTime(Registrant swimmer,string time)
		{
			int indexOfSwimmerInCollection = 0;
			SwimTimeEntered = true;
			for (int i = 0; i < NumOfRegisterant;i++)
			{
				if (CollOfRegisterants[i] == swimmer)
					indexOfSwimmerInCollection = i;
			}
			if (AlreadyEntered(swimmer,CollOfRegisterants)==true)
			{
				aSwimmer = (Swimmer)swimmer;
				CollOfSwims[indexOfSwimmerInCollection].TimeSwam = time;
				time = "0:" + time;
				aSwimmer.AddAsBestTime(PoolTypeOfEvent,Stroke,Distance,TimeSpan.Parse(time));

			}
			else
				throw (new Exception("Swimmer has not entered the event"));
		}

		public void Seed(int noOfLanes)
		{

			int heat =  1;
			int lane = 1;
			int helper = lane;

			for (int i = 0; i < NumOfRegisterant;i++)
			{
				if (lane > noOfLanes)
				{
					helper = lane;
					lane = 1;
				}

				CollOfSwims[i].Lane = lane;
				if (helper > noOfLanes)
				{
					heat++;
				}
				CollOfSwims[i].Heat = heat;
				lane++;
			}
		}
      
	    public override string ToString()
		{
			return string.Format("Distance :{0} meters, Stroke :{1}",Distance,Stroke);
		}

    }
}
