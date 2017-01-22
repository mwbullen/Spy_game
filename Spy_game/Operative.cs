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

		public Operative (string newName)
		{
		Name = newName;
		}
	}


