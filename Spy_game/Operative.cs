using System;
using System.Collections;
using System.Collections.Generic;


namespace Spy_game
{
	[Serializable]
	public class Operative
	{
		//personal info
		//public string realName = "Unknown";

		//public string lastName;
		//public string FirstName;

		public Name realName;
		public int agentNumber;


		public enum assetTask { gatheringIntel, investigating, slandering, intimidating, grantingAutoLicense, improvingResidence };

		public assetTask currentTask = assetTask.gatheringIntel;

		//employment info
		public Institution Employer;
		public int Rank;
		public Operative Boss;

		static int minNewAgentRank = 1;
		static int maxNewAgentRank = 3;

		static int minNewLoyalty = 2;
		static int maxNewLoyalty = 9;

		static int minNewParanoia = 1;
		static int maxNewParanoia = 10;

		public enum MarriageStatus { Unknown, Married, Single };
		public enum Vice {Drinking, Gambling, Adultery }

		public List<Vice> Vices = new List<Vice>();

		//biographic info
		public MarriageStatus Married = MarriageStatus.Unknown;
		public int NumberChildren;
		public float BankBalance;

		//secrets (blackmail info)
		public List<PersonalSecret> secrets;

		//personality traits
		public int Loyalty;
		public float Greed;
		public int Paranoia;


		public Operative(GameState gameState)
		{
			Employer = gameState.getRandomInstitution();
			initOperative();
		}



		public Operative(GameState gameState, Institution i)
		{
			Employer = i;
			initOperative();
		}

		public int getDailyIntelProduct()
		{
			//rank * loyalty * random

			Random r = new Random();

			double randomMod = r.NextDouble();

			int intelDelivered = (int)(Rank * Loyalty * randomMod);

			return intelDelivered;

		}

		void initOperative()
		{
			Random r = new Random();

			int randomCodeNumber = r.Next(1, 100);

			agentNumber = randomCodeNumber;
			Rank = r.Next(minNewAgentRank, maxNewAgentRank);
			Loyalty = r.Next(minNewLoyalty, maxNewLoyalty);

			Paranoia = r.Next(minNewParanoia, maxNewParanoia);

			realName = NameGenerator.generateRandomName();

		}

		public void printOperativeDetails()
		{
			string[] headers = { "Name", "Employer", "Rank", "Marriage Status", "Loyalty", "Paranoia", "Current Task" };
			string[] values = { realName.ToString(), Employer.Name.ToString(), Rank.ToString(), Married.ToString(), Loyalty.ToString(), Paranoia.ToString(), currentTask.ToString()};                

			Console.WriteLine();
			for (int i = 0; i < headers.Length; i++)
			{
				Console.WriteLine(headers[i] + ":  " + values[i]);
			}
			Console.WriteLine();

			/*
			Console.WriteLine();
			Console.WriteLine("Name: " + Name);
			Console.WriteLine("Rank: " + Rank);
			Console.WriteLine("Employer: " + Employer.Name);
			Console.WriteLine("Loyalty: " + Loyalty);
			Console.WriteLine();
			*/
		}

	}
}

