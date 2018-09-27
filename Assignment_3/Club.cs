using System;
using System.Collections.Generic;

namespace Assignment_1
{    
	[Serializable]
	public class Club
	{
		
		int clubNumber;
		long phoneNumber;
		public int NumOfRegisterant;
		static int[] uniqueClubNumberCollection = new int[1];
		public List<Registrant> CollOfRegisterant = new List<Registrant>();
		public List<Coach> CollOfCoaches = new List<Coach>();
		public Club AssignedClubToCoach;
		const long MINVALUEOFPHONENO = 1000000000;
        const long MAXVALUEOFPHONENO = 9999999999;
		public static int count;

		public bool UniqueClubNumberValidator(int clubNumberToCheck, int[] uniqueClubNumberCollection)
		{
			for (int i = 0; i < uniqueClubNumberCollection.Length; i++)
			{
				if (uniqueClubNumberCollection[i] == clubNumberToCheck)
					return false;
			}
			return true;
		}

		public Club(string name,Address aAddress,long phoneNumber)
		{
			
			Name = name;
			AAddress = aAddress;
			PhoneNumber = phoneNumber;
			count++;
			ClubNumber = count + Registrant.RegNumCount;

		}

		public Club(int clubNumber,string name, Address aAddress, long phoneNumber)
        {
			count++;
            Name = name;
            AAddress = aAddress;
            PhoneNumber = phoneNumber;
			ClubNumber =clubNumber;

        }

		public Club()
		{
			count++;
			ClubNumber = count + Registrant.RegNumCount;
		}

		public Address AAddress
		{
            set;
            get;
        }
      
        
		public int ClubNumber
		{

			set
			{
				if (UniqueClubNumberValidator(value, uniqueClubNumberCollection))
                {
                    Array.Resize(ref uniqueClubNumberCollection, 1 + uniqueClubNumberCollection.Length);
					uniqueClubNumberCollection[count - 1] = value;
                    clubNumber=value;
                }
                else if (count == 1)
                {
					uniqueClubNumberCollection[0] = value;
					clubNumber=value;
                }
                else
                {
					throw(new Exception (value==0?"Invalid club record. Club number is not valid:"
					                     :"Invalid club record. Club with the registration number already exists: "
					                    )
					     );
                }
                
			}
			get
			{
				return clubNumber;
			}
		}

		public string Name
		{
            set;
            get;
        }
      

		public long PhoneNumber
		{
			set
			{
				if (value >= MINVALUEOFPHONENO && value <= MAXVALUEOFPHONENO)
                {
                    phoneNumber=value;
                }
                else
                {
					throw (new Exception("Invalid club record. Phone number wrong format:"));
                }
			}
			get
			{
				return phoneNumber;
			}
		}

		public void AddSwimmer(Registrant swimmer)
		{
			
			if (swimmer.IsAssignedToClub == false)
			{
				swimmer.Club = this;
				swimmer.IsAssignedToClub = true;
			}
			else
				throw (new Exception(string.Format("Swimmer already assigned to {0} club ",swimmer.Club.Name)));
		}

		public void AddCoach(Coach aCoach)
		{
			CollOfCoaches.Add(aCoach);

			for (int i = 0; i < CollOfRegisterant.Count;i++)
			{
				CollOfRegisterant[i].coachRegisteredInClubOfSwimmer = true;
			}
			aCoach.CoachIsAssignedToClub = true;
			aCoach.AssignedClubToCoach = this;
         
		}



		public override string ToString()
		{

			string Output= string.Format("Name: {0} \nAddress:\n\t{1}\n\t{2}\n\t{3}\n\t{4}\nPhoneNumber: {5}\nreg number:{6}\nSwimmers:\n\t",
			                                  Name, AAddress.StreetName, AAddress.City, AAddress.Province, AAddress.ZipCode, phoneNumber,
			                                  ClubNumber
			                                 );
			
			for (int i = 0; i < NumOfRegisterant; i++)
			{  
				Output+= CollOfRegisterant[i].Name+"\n\t";
			}

			Output += string.Format("\nCoaches:");

			for (int i = 0; i < CollOfCoaches.Count; i++)
            {
				Output+= CollOfCoaches[i].Name + "\n\t";
            }

			return Output;

		}

	}
}

