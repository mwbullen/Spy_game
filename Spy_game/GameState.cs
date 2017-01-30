using System;
using System.Collections;
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

			//generateActionList();
		}

		public void generateInvestigationList()
		{
			Console.WriteLine("Select department to investigate: ");

			foreach (Institution i in allInstitutions)
			{
				Console.WriteLine("[" +i.sortNumber + "]  " + i.Name);
			}

			string inputStr = Console.ReadLine();


		}

		public void performTurn()
		{
			Hashtable inputChoices = new Hashtable();

			Console.WriteLine("Select activity for day");

			inputChoices.Add(1, "Investigate organization");
			inputChoices.Add(2, "Burglaries");

			foreach (int k in inputChoices.Keys)
			{
				Console.WriteLine("[" + k + "]" + inputChoices[k]);

			}

			string inputStr = Console.ReadLine();

			int inputInt = int.Parse(inputStr);

			if (inputInt == 1)
			{
				generateInvestigationList();
			}
			else if (inputInt == 2)
			{
				//burglaries
			}
			else {
				//command not found
			}



			//deposit messages
			//perform day's activity
			//gather responses & intelligence
			//generateActionList();

			Console.WriteLine("Delivering messages to dead drops");
			//System.Threading.Thread.Sleep(2000);
			//Console.WriteLine("Investigating Ministry of Defense");
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
