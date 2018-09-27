using System;
using System.Collections.Generic;

namespace Assignment_1
{

	public enum PoolType
	{
		SCM = 1, SCY, LCM
	};
	[Serializable]
	public class SwimMeet
	{

		readonly PoolType aPoolType;
		public List<Event> collOfEvents = new List<Event>(); 

		public int noOfEvents;
		bool isSeeded;

		public SwimMeet(string name, DateTime startDate, DateTime endDate, PoolType aPoolType, int noOfLanes)
		{
			StartDate = startDate;
			EndDate = endDate;
			Name = name;
			this.aPoolType = aPoolType;
			NoOfLanes = noOfLanes;
			isSeeded = false;
		}

		public SwimMeet()
		{
			aPoolType = PoolType.SCM;
			NoOfLanes = 8;
			isSeeded = false;
		}

		public DateTime StartDate
		{
			set;
			get;
		}
      
		public DateTime EndDate
		{
            set;
            get;
        }
            
		public string Name
		{
            set;
            get;
        }
            
		public PoolType APoolType
		{
			get
			{
				return aPoolType;
			}
		}

		public int NoOfLanes
		{
            set;
            get;
        }
      

		public void AddEvent(Event aEvent)
		{
			noOfEvents++;
			collOfEvents.Add(aEvent);
			aEvent.PoolTypeOfEvent = APoolType;

		}

		public void Seed()
		{
			isSeeded = true;
			for (int i = 0; i < noOfEvents; i++)
			{
				collOfEvents[i].Seed(NoOfLanes);   
			}
		}

		public override string ToString()
		{
			string firstOutput = string.Format("Swim meet name: {0}\nFrom-to:{1} to {2}\nPool Type:" +
			                                   " {3}\nNo lanes:{4}\nEvents:\n  ", Name, StartDate.ToString("yyyy-MM-dd"),
			                                   EndDate.ToString("yyyy-MM-dd"), APoolType, NoOfLanes);
			string secondOutput = null;

			for (int i = 0; i < noOfEvents; i++)
			{
				if (collOfEvents[i].NumOfRegisterant == 0)
				{
					secondOutput += "\t" + collOfEvents[i].Distance + " " + collOfEvents[i].Stroke + "\n";
					secondOutput += "\tSwimmers:\n";
				}
			}

			for (int j = 0; j < noOfEvents; j++)
			{

				if (collOfEvents[j].NumOfRegisterant != 0)
				{
					if (isSeeded == false)
					{
						secondOutput += collOfEvents[j].Distance + " " + collOfEvents[j].Stroke + "\n";
						secondOutput += "\tSwimmers:\n\t";
						for (int k = 0; k < collOfEvents[j].NumOfRegisterant; k++)
						{
							secondOutput += collOfEvents[j].CollOfRegisterants[k].Name;
							secondOutput += "\n\t\tNot Seeded/no swim\n\t";
						}
					}
					else
					{

						secondOutput += "\t" + collOfEvents[j].Distance + " " + collOfEvents[j].Stroke + "\n";
						secondOutput += "\tSwimmers:\n";
						for (int p = 0; p < collOfEvents[j].NumOfRegisterant; p++)
						{
							secondOutput += "\t" + collOfEvents[j].CollOfRegisterants[p].Name;
							secondOutput += string.Format("\tH{0}L{1}", collOfEvents[j].CollOfSwims[p].Heat,
							                              collOfEvents[j].CollOfSwims[p].Lane);
                            if (collOfEvents[j].SwimTimeEntered == false)
                            {
                                secondOutput += "\ttime: no time\n";
                            }
                            else
                            {
								secondOutput += string.Format(" time: {0}\n", collOfEvents[j].CollOfSwims[p].TimeSwam);
                            }
                        }
					}


				}


			   }
			return (firstOutput + secondOutput);
			}
			
		}

        
    }

