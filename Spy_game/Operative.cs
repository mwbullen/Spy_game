using System;
using System.Collections.Generic;


namespace Spy_game
{
	[Serializable]
	public class Operative
	{
		//personal info
		public string Name;

		//employment info
		public Institution Employer;
		public int Rank;
		public Operative Boss;

		static int minNewAgentRank = 1;
		static int maxNewAgentRank = 3;

		static int minNewLoyalty = 4;
		static int maxNewLoyalty = 7;

		//biographic info
		public bool Married;
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

			Name = randomCodeNumber.ToString();
			Rank = r.Next(minNewAgentRank, maxNewAgentRank);

			Employer = gameState.getRandomInstitution();
			Loyalty = r.Next(minNewLoyalty, maxNewLoyalty);
		}

		public void printOperativeDetails()
		{
			Console.WriteLine();
			Console.WriteLine("Name: " + Name);
			Console.WriteLine("Rank: " + Rank);
			Console.WriteLine("Employer: " + Employer.Name);
			Console.WriteLine("Loyalty: " + Loyalty);
			Console.WriteLine();
		}

	}
}

