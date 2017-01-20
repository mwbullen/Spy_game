using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class OperativeInfo
	{
		//personal info
		public string Name;

		//biographic info
		public bool Married;
		public int NumberChildren;
		public float BankBalance;

		//secrets (blackmail info)
		public List<PersonalSecret> secrets;

		//employment info
		public Institution Employer;
		public int Rank;
		public Operative Boss;

		//personality traits
		public float Cooperation;
		public float Greed;
		public float Paranoia;

		public OperativeInfo ()
		{
		}
	}
}

