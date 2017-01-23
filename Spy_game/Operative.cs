using System;
using System.Collections.Generic;

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


		//biographic info
		public bool Married;
		public int NumberChildren;
		public float BankBalance;

		//secrets (blackmail info)
		public List<PersonalSecret> secrets;

		//personality traits
		public float Cooperation;
		public float Greed;
		public float Paranoia;

		public Operative ()
		{
			Random r = new Random();

			int randomCodeNumber = r.Next(1, 100);

		Name = randomCodeNumber.ToString();
		Rank = r.Next(minNewAgentRank, maxNewAgentRank);

		}

		public void printOperativeDetails()
		{
		Console.WriteLine("Name: " + Name);
		Console.WriteLine("Rank: " + Rank);
		//Console.WriteLine("Employer: " + Employer.Name);
		                  
		}


	}


