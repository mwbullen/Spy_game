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

		DateTime inGameDate = new DateTime(1961, 1, 1);

		public int cash = 100;


		public GameState()
		{
			initializeInstituitions();
			currentOperatives = new List<Operative>();
			currentOperatives.Add(new Operative(this));

			//generateActionList();
		}

		public void printPlayerStatus()
		{
			Console.WriteLine(inGameDate.ToLongDateString());
			Console.WriteLine("Cash:  $" + cash);
		}


		public void enterInvestigationList()
		{
			Console.WriteLine("Select department to investigate: ");

			foreach (Institution i in allInstitutions)
			{
				Console.WriteLine("[" +i.sortNumber + "]  " + i.Name);
			}

			string inputStr = Console.ReadLine();

			Institution targetInstitution = getInstitutionforSortNumber(int.Parse(inputStr));

			if (targetInstitution != null)
			{
				investigateInstitution(targetInstitution);
			}
		}

		public void investigateInstitution(Institution targetInst)
		{
			Random r = new Random();

			int recruitRoll = r.Next(0, 100);

			if (recruitRoll <= targetInst.recruitChance)
			{
				//successful
				Console.WriteLine("You spend the day investigating " + targetInst.Name + " and find a new asset!");
				currentOperatives.Add(new Operative(this, targetInst));
				LoadSave.saveGameState(this);

			}
			else {//fail
				Console.WriteLine("You spend the day investigating " + targetInst.Name + " but do not find any new assets");

			}

		}

		Institution getInstitutionforSortNumber(int sortNumber)
		{
			foreach (Institution i in allInstitutions)
			{
				if (i.sortNumber == sortNumber)
				{
					return i;
				}
			}

			return null;
		}

		public void performTurn()
		{
			

			Console.WriteLine("Select activity for day");

			Console.WriteLine("[1] Investigate organization (to recruit new assets)");
			Console.WriteLine("[2] Shadow assets (to learn more about them)");
			Console.WriteLine("[3] Burglarize assets residence (to learn more about them, once their address is known)");

			string inputStr = Console.ReadLine();

			int inputInt = int.Parse(inputStr);

			switch (inputInt)
			{
				case 1:
					enterInvestigationList();
					break;
				case 2:
					//follow suspect 
					break;
				case 3:
					break;
			}



			//deposit messages
			//perform day's activity
			//gather responses & intelligence
			//generateActionList();

			inGameDate = inGameDate.AddDays(1);

			Console.WriteLine("Delivering messages to dead drops");
			//System.Threading.Thread.Sleep(2000);
			//Console.WriteLine("Investigating Ministry of Defense");
			//System.Threading.Thread.Sleep(2000);
			Console.WriteLine("Retrieving intel");
			//System.Threading.Thread.Sleep(2000);

//			printPlayerStatus();
		}


		public void listCurrentOperatives()
		{
			if (currentOperatives.Count == 0)
			{
				Console.WriteLine("No agents available");
			}
			else {
				string agentStr = "Agent";
				if (currentOperatives.Count > 1)
				{
					agentStr = "Agents";
				}

				Console.WriteLine( currentOperatives.Count + " "+ agentStr + ":");
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
