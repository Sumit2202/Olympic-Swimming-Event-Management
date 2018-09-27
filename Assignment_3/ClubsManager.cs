using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment_1
{
	interface IClubsRepository 
	{
		 List<Club>Clubs
		{
			set;
			get;
		}

		int Number
		{
			get;
		}

		void Add(Club club);

		Club GetByRegNum(int clubNumber);

		void Load(string fileName, char delimiter);

		void Save(string fileName,char delimiter);

		void Load(string fileName);

	}
	public class ClubsManager:IClubsRepository
	{

		public List <Club> clubs = new List<Club>();
		public int numberOfClubs;

		public ClubsManager()
		{

		}
      
		public List<Club> Clubs
		{
			set
			{
				clubs = value;
			}

			get
			{
				return clubs;
			}

		}
		public int Number
		{
         
			get
			{
				return numberOfClubs;
			}
            
		}

		public void Add(Club club)
		{
			Clubs.Add(club);
			numberOfClubs++;
		}

		public Club GetByRegNum(int clubNumber)
		{
			for (int i = 0; i < Number;i++)
			{
				if (clubs[i].ClubNumber == clubNumber)
					return clubs[i];
			}
			return null;

		}

		public void Load(string fileName,char delimiter)
		{
			string recordIn ;
			FileStream fileIn = new FileStream(fileName,FileMode.Open,FileAccess.Read);
			StreamReader reader = new StreamReader(fileIn);
			recordIn = reader.ReadLine();
			while (recordIn != null)
			{
				try
				{
					Add(new Club(Convert.ToInt32(recordIn.Split(delimiter)[0]),
								 recordIn.Split(delimiter)[1],
								 new Address(recordIn.Split(delimiter)[2],
											 recordIn.Split(delimiter)[3],
											 recordIn.Split(delimiter)[4],
											 recordIn.Split(delimiter)[5]),
								 Convert.ToInt64(recordIn.Split(delimiter)[6])
								)
					   );
				}

				catch (Exception ex)
				{
					int resultA;
					long resultB;
					if (Int32.TryParse(recordIn.Split(delimiter)[0], out resultA) == false)
					{
						Console.WriteLine("Invalid club record. Club number is not valid:");
						Console.WriteLine("\t" + recordIn);
					}

					else if (Int64.TryParse(recordIn.Split(delimiter)[6], out resultB) == false)
					{
						Console.WriteLine("Invalid club record. Phone number wrong format:");
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

		public void Save(string fileName,char delimiter)
		{
			FileStream fileOut = null;
			BinaryFormatter binFormatter = new BinaryFormatter();

			try
			{
				fileOut = new FileStream(fileName, FileMode.Create, FileAccess.Write);

				for (int i = 0; i < numberOfClubs ; i++)
					binFormatter.Serialize(fileOut, clubs[i]);
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
				while(fileIn.Position<fileIn.Length)
				{
					Add((Club)binFormatter.Deserialize(fileIn));     
				}
			}
			catch(Exception ex)
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
		

