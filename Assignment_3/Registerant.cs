using System;
using System.Collections.Generic;

namespace Assignment_1
{
	[Serializable]
	public struct Address
	{

		public Address(string streetName, string city, string province, string zipCode) : this()
		{
			StreetName = streetName;
			City = city;
			Province = province;
			ZipCode = zipCode;
		}
		public string StreetName { set; get; }


		public string Province { set; get; }


		public string City { set; get; }


		public string ZipCode { set; get; }


		public string GetAddress()
		{
			return string.Format("Address of registerant is : {0}, {1}, {2}, {3}", StreetName, City, Province, ZipCode);
		}

	};

	[Serializable]
	public class Registrant
	{
		TimeSpan aTime = new TimeSpan(12, 0, 0);
		int registrationNumber;
		string name;

		long phoneNumber;

		public bool IsAssignedToClub;
		public TimeSpan BestTime;
		const long MINVALUEOFPHONENO= 1000000000;
		const long MAXVALUEOFPHONENO = 9999999999;
        
		public List <Event> CollOfEvents = new List<Event>();
        
		static int[] uniqueRegistrantNumberCollection = new int[1];
		public static int count1;
		public static int count2;
		public Club AssignedClub;

		string clubName;
		public bool EnteredEvent;
		public static int RegNumCount;

		public bool coachRegisteredInClubOfSwimmer;


		public bool UniqueRegistrantNumberValidator(int registerantNumberToCheck, int[] uniqueRegisterantNumber)
		{
			for (int i = 0; i < uniqueRegisterantNumber.Length; i++)
			{
				if (uniqueRegisterantNumber[i] == registerantNumberToCheck)
					return false;
			}
			return true;
		}

		public Registrant(string name, DateTime dateOfBirth, Address address, long phoneNumber)
		{
			Name = name;
			DateOfBirth = dateOfBirth;
			Address = address;
			count1++;
			count2++;
			PhoneNumber = phoneNumber;
			RegistrationNumber = count1;
			RegNumCount++;

		}

		public Registrant(int registerationNumber, string name, DateTime dateOfBirth, Address address, long phoneNumber, string clubName)
		{
			count2++;
			RegistrationNumber = registerationNumber;
			PhoneNumber = phoneNumber;
			Name = name;
			DateOfBirth = dateOfBirth;
			Address = address;

			this.clubName = clubName;
			if (clubName!="not Assigned")
			{
				IsAssignedToClub =true;
			}
		}

		public Registrant()
		{
			count1++;
			count2++;
			RegistrationNumber = count1;
			RegNumCount++;
		}

		public Address Address
		{
            set;
            get;
        }
      

		public int RegistrationNumber
		{

			set
			{
				if (UniqueRegistrantNumberValidator(value, uniqueRegistrantNumberCollection))
				{
					Array.Resize(ref uniqueRegistrantNumberCollection, uniqueRegistrantNumberCollection.Length + 1);
					uniqueRegistrantNumberCollection[count2 - 1] = value;
					registrationNumber = value;
				}
				else if (count2 == 1)
				{
					uniqueRegistrantNumberCollection[0] = value;
					registrationNumber = value;
				}
				else
				{
					Console.WriteLine("Invalid swimmer record. Swimmer with the registration number already exists:");
				}

			}
			get
			{
				return registrationNumber;
			}
		}

		public string Name
		{

			set
			{
				if (value.Length == 0)
				{
					throw (new Exception("Invalid swimmer record. Invalid swimmer name: "));
				}
				name = value;

			}
			get
			{
				return name;
			}
		}

		public DateTime DateOfBirth
		{
            set;
            get;
        }
      

		public long PhoneNumber
		{

			set
			{
				if (value >= 1000000000 && value <= 9999999999)
				{
					phoneNumber = value;
				}
				else
				{
					throw (new Exception("Please enter a valid 10 digit phone number"));
				}

			}
			get
			{
				return phoneNumber;
			}
		}

		public Club Club
		{

			set
			{
				if (IsAssignedToClub == false)
				{
					AssignedClub = value;
					AssignedClub.NumOfRegisterant += 1;
					AssignedClub.CollOfRegisterant.Add(this);
					IsAssignedToClub = true;
				}
				else
					throw (new Exception("Swimmer is registered with different club"));
			}
			get
			{
				return AssignedClub;
			}
		}

		public override string ToString()
		{
			return string.Format("Name: {0} \nAddress:\n\t{1}\n\t{2}\n\t{3}\n\t{4}\nPhoneNumber:" +
								 " {5}\nDOB: {6}\nreg number: {7}\nClub: {8}\nCoach: not assigned",
			                     name,
								 Address.StreetName, Address.City, Address.Province, Address.
								 ZipCode, phoneNumber, DateOfBirth + aTime, registrationNumber,
			                     IsAssignedToClub ? (AssignedClub==null?clubName:AssignedClub.Name) : " not assigned");
		}
	}
}
