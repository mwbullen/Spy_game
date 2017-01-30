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

		public enum MarriageStatus { Unknown, Married, Single };

		//biographic info
		public MarriageStatus Married = MarriageStatus.Unknown;
		public int NumberChildren;
		public float BankBalance;

		//secrets (blackmail info)
		public List<PersonalSecret> secrets;

		//personality traits
		public float Loyalty;
		public float Greed;
		public float Paranoia;

		public Operative(GameState gameState)
		{
			Random r = new Random();

			int randomCodeNumber = r.Next(1, 100);

			agentNumber = randomCodeNumber;
			Rank = r.Next(minNewAgentRank, maxNewAgentRank);

			Employer = gameState.getRandomInstitution();
			Loyalty = r.Next(minNewLoyalty, maxNewLoyalty);
		}

		public void printOperativeDetails()
		{
			string[] headers = { "Agent #", "Real Name","Employer", "Rank", "Marriage Status", "Loyalty" };
			string[] values = { agentNumber.ToString(), realName, Employer.Name.ToString(),Rank.ToString(),  Married.ToString(), Loyalty.ToString()};

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

