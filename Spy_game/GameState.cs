using System;
using System.Collections.Generic;

namespace Spy_game
{
	[Serializable]
	public class GameState
	{
		public List<Operative> currentOperatives;
		public List<Institution> allInstitutions;

		public GameState()
		{
			initializeInstituitions();
			currentOperatives = new List<Operative>();
			currentOperatives.Add(new Operative(this));

		}


		public void performTurn()
		{
			//deposit messages
			//perform day's activity
			//gather responses & intelligence

			Console.WriteLine("Delivering messages to dead drops");
			//System.Threading.Thread.Sleep(2000);
			Console.WriteLine("Investigating Ministry of Defense");
			//System.Threading.Thread.Sleep(2000);
			Console.WriteLine("Retrieving dead drop responses");
			//System.Threading.Thread.Sleep(2000);

		}

		public void listCurrentOperatives()
		{
			if (currentOperatives.Count == 0)
			{
				Console.WriteLine("No agents available");
			}
			else {
				Console.WriteLine("Current agents:");
				foreach (Operative agent in currentOperatives)
				{
					//Console.WriteLine(agent.Name);
					agent.printOperativeDetails();
				}
			}
		}

		public void initializeInstituitions()
		{
			allInstitutions = Institution.generateInstitutionList();
		}

		public Institution getRandomInstitution()
		{
			Random r = new Random();

			return allInstitutions[r.Next(0, allInstitutions.Count - 1)];

		}
	}


}
