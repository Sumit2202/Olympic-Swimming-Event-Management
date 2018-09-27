using System;
using System.Collections.Generic;

namespace Assignment_1
{
	[Serializable]
	public class Coach:Registrant
    {
		public bool CoachIsAssignedToClub;
		public Club AssignedClubToCoach;
		public List<Swimmer> listOfSwimmers = new List<Swimmer>();

		public string Credentials
		{
            set;
            get;
        }
      
		public void AddSwimmer(Swimmer aSwimmer)
		{

			if(CoachIsAssignedToClub)
			{
				if (aSwimmer.Club == AssignedClubToCoach)
				{
					listOfSwimmers.Add(aSwimmer);
				}
				else
				{
					throw (new Exception("swimmer and the coach not in the same club"));
				}
			}
			else
			{
				throw (new Exception("Coach is not assigned to a club"));
			}

		}
		public Coach(string name,DateTime dateOfBirth,Address aAddress,long phoneNumber):base(name,dateOfBirth,aAddress,phoneNumber)
		{
			
		}
        
		public override string ToString()
        {
			Console.WriteLine(listOfSwimmers.Count);
			string outputA;
			string outputB="";
			outputA = string.Format("Name: {0} \nAddress:\n\t{1}\n\t{2}\n\t{3}\n\t{4}\nPhoneNumber:" +
								  " {5}\nDOB: {6}\nreg number: {7}\nClub: {8}\nCredentials:{9}\nSwimmers:\n\t",
								 Name, Address.StreetName, Address.City, Address.Province,
								  Address.ZipCode, PhoneNumber, DateOfBirth, RegistrationNumber,
			                        listOfSwimmers.Count==0?"not assigned":AssignedClubToCoach.Name, Credentials
								 );
			for (int i = 0; i < listOfSwimmers.Count;i++)
			{
				outputB +=listOfSwimmers[i].Name+"\n\t";
			}
			return outputA+outputB ; 
        }
    }
}
