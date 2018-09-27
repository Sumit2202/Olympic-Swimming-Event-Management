using System;
namespace Assignment_1
{
	[Serializable]
    public class Swim
    {
		public TimeSpan bestTime;

		public Swim(int heat,int lane,string timeSwam)
        {
			Heat = heat;
			Lane = lane;
			TimeSwam = timeSwam;
        }
		public Swim()
        {
			TimeSwam="no time";
        }
        
		public int Heat
		{
			set;
			get;
		}
			public int Lane
        {
			get;
			set;
		}

		public string TimeSwam
        {
			get;
			set;
        }

		public override string ToString()
        {
			return string.Format("Heat:{0}, Lane:{1}, Time-Swam:{2}",Heat,Lane,TimeSwam);
        }
    }
}
