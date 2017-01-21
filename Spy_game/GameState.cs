using System;
using System.Collections.Generic;

namespace Spy_game
{
	[Serializable]
	public class GameState
	{
		public List<Operative> currentOperatives;
		public List<Institution> allInstitutions;

		string[] institutionNames = { "Security Services", "Housing Authority", "Automotive Registry", "National Bank", "Military Procurement", "Education Ministry", "Information and Press", "Construction", "Department of Prisons" };


		public GameState()
		{
			currentOperatives = new List<Operative>();
		}

		public void performTurn()
		{
			//deposit messages
			//perform day's activity
			//gather responses & intelligence

			Console.WriteLine("Delivering messages to dead drops");
			System.Threading.Thread.Sleep(2000);
			Console.WriteLine("Investigating Ministry of Defense");
			System.Threading.Thread.Sleep(2000);
			Console.WriteLine("Retrieving dead drop responses");
			System.Threading.Thread.Sleep(2000);

		}

		public void listCurrentOperatives()
		{
			if (currentOperatives.Count == 0)
			{
				Console.WriteLine("No agents available");
			}
			else {
				foreach (Operative agent in currentOperatives)
				{
					Console.WriteLine(agent.Info.Name);
				}
			}
		}

		public Operative generateNewRandomOperative()
		{
			return null;
		}

		public void initializeInstituitions()
		{
			List<Institution> newInstList = new List<Institution>();

			foreach (string instName in institutionNames)
			{
				Institution i = new Institution(instName);

				newInstList.Add(i);
			}

			allInstitutions = newInstList;
		}
	}


}
