using System;
using System.Collections;
using System.Collections.Generic;


namespace Spy_game
{
	[Serializable]
	public class Operative
	{
		//personal info
		public string realName = "Unknown";
		public int agentNumber;

		//employment info
		public Institution Employer;
		public int Rank;
		public Operative Boss;

		static int minNewAgentRank = 1;
		static int maxNewAgentRank = 3;

		static int minNewLoyalty = 4;
		static int maxNewLoyalty = 7;

		static int minNewParanoia = 1;
		static int maxNewParanoia = 10;

		public enum MarriageStatus { Unknown, Married, Single };

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

			return (int) ( Rank * Loyalty * r.NextDouble() );

		}

		void initOperative()
		{
			Random r = new Random();

			int randomCodeNumber = r.Next(1, 100);

			agentNumber = randomCodeNumber;
			Rank = r.Next(minNewAgentRank, maxNewAgentRank);
			Loyalty = r.Next(minNewLoyalty, maxNewLoyalty);

			Paranoia = r.Next(minNewParanoia, maxNewParanoia);

		}

		public void printOperativeDetails()
		{
			string[] headers = { "Agent #", "Real Name", "Employer", "Rank", "Marriage Status", "Loyalty", "Paranoia" };
			string[] values = { agentNumber.ToString(), realName, Employer.Name.ToString(), Rank.ToString(), Married.ToString(), Loyalty.ToString(), Paranoia.ToString()};

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

