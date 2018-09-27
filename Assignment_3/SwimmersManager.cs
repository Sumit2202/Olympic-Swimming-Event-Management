using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment_1
{
	interface ISwimmersRepository
	{
		List<Registrant> Swimmers
		{
			set;
			get;
		}

		int Number
		{
			get;
		}

		void Add(Registrant registrant);

		Registrant GetByRegNum(int RegNumber);

		void Load(string fileName, char delimiter);

		void Save(string fileName, char delimiter);

		void Load(string fileName);
	}
	public class SwimmersManager : ISwimmersRepository
	{
		string clubName;
		List<Registrant> swimmers = new List<Registrant>();
		int numberOfRegisterants;
		ClubsManager aClubManager;
		public SwimmersManager(ClubsManager aClubManager)
		{
			this.aClubManager = aClubManager;            
		}

		public List<Registrant> Swimmers
		{
			set
			{
				swimmers = value;

			}
			get
			{
				return swimmers;
			}

		}

		public int Number
		{
			get
			{
				return numberOfRegisterants;
			}

		}

		public void Add(Registrant registrant)
		{
			swimmers.Add(registrant);
			numberOfRegisterants++;
		}

        
		public Registrant GetByRegNum(int registrantNumber)
		{
			for (int i = 0; i < Number; i++)
			{
				if (swimmers[i].RegistrationNumber == registrantNumber)
					return swimmers[i];
			}
			return null;

		}

		public void Load(string fileName, char delimiter)
		{
			string recordIn;
			FileStream fileIn = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			StreamReader reader = new StreamReader(fileIn);
			recordIn = reader.ReadLine();
			while (recordIn != null)
			{
				try
				{
					bool lastRec = Int32.TryParse(recordIn.Split(delimiter)[8], out int result);
					if (lastRec == false)
					{
						result = 0;
						clubName = "not Assigned";
					}
					else
					{
						 clubName =aClubManager.GetByRegNum(result).Name;
					}
					Add(new Registrant(Convert.ToInt32(recordIn.Split(delimiter)[0]),
									   recordIn.Split(delimiter)[1],
									   Convert.ToDateTime(recordIn.Split(delimiter)[2]),
									   new Address(recordIn.Split(delimiter)[3],
												 recordIn.Split(delimiter)[4],
												 recordIn.Split(delimiter)[5],
												 recordIn.Split(delimiter)[6]),
									   Convert.ToInt64(recordIn.Split(delimiter)[7]),
					                   clubName));
				}

				catch (Exception ex)
				{
					int resultA;
					long resultB;
					DateTime result;
					   
				     if (Int32.TryParse(recordIn.Split(delimiter)[0], out resultA) == false)
					{
						Console.WriteLine("Invalid swimmer record. Invalid registeration number:");
						Console.WriteLine("\t" + recordIn);
					}
					else if (DateTime.TryParse(recordIn.Split(delimiter)[2], out result) == false)
					{
						Console.WriteLine("Invalid swimmer record. Birth date is Invalid:");
						Console.WriteLine("\t" + recordIn);
					}
					else if (Int64.TryParse(recordIn.Split(delimiter)[7], out resultB) == false)
					{
						Console.WriteLine("Invalid registerant record. Phone number wrong format:");
						Console.WriteLine("\t" + recordIn);
					}
					else
					{
						Console.WriteLine(ex.Message);
						Console.WriteLine("\t" + recordIn);
					}
				}
				recordIn = reader.ReadLine();
			}
			reader.Close();
			fileIn.Close();

		}
      
		public void Save(string fileName, char delimiter)
		{
			FileStream fileOut = null;
			BinaryFormatter binFormatter = new BinaryFormatter();

			try
			{
				fileOut = new FileStream(fileName, FileMode.Create, FileAccess.Write);

				for (int i = 0; i < Number; i++)
					binFormatter.Serialize(fileOut, swimmers[i]);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				fileOut.Close();
			}
		}

		public void Load(string fileName)
		{
			FileStream fileIn = null;

			BinaryFormatter binFormatter = new BinaryFormatter();
			try
			{
				fileIn = new FileStream(fileName, FileMode.Open, FileAccess.Read);
				while (fileIn.Position < fileIn.Length)
				{
					Add((Registrant)binFormatter.Deserialize(fileIn));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				fileIn.Close();
			}
		}
	}

}


