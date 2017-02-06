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

		public int totalIntelGenerated;
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
//			Console.WriteLine("Cash:  $" + cash);
			Console.WriteLine("Intelligence gathered: " + totalIntelGenerated);
		}

		public Operative selectAsset(string prompt)
		{
			Console.WriteLine(prompt);

			foreach (Operative o in currentOperatives)
			{
				Console.WriteLine("[" + o.agentNumber + "]  " + o.realName);
			}

			return null;
		}

		public Institution selectInstitution(string prompt)
		{
			Console.WriteLine(prompt);

			foreach (Institution i in allInstitutions)
			{
				Console.WriteLine("[" +i.sortNumber + "]  " + i.Name);
			}

			string inputStr = Console.ReadLine();
			int inputInt;

			if (int.TryParse(inputStr, out inputInt)) {
				Institution targetInstitution = getInstitutionforSortNumber(int.Parse(inputStr));

				if (targetInstitution != null)
				{
					//investigateInstitution(targetInstitution);
					return targetInstitution;
				}
				else {
					return null;
				}
			}

			return null;
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

		public bool enterSelectActionChoice()
		{
			Console.WriteLine("Select action");

			Console.WriteLine("[1] Investigate organization (attempt to find new assets)");
			Console.WriteLine("[2] Shadow assets (get more information about assets)");
			Console.WriteLine("[3] Burglarize assets residence (learn more about them, once their address is known)");

			string inputStr = Console.ReadLine();
			int inputInt;

			if (int.TryParse(inputStr, out inputInt))
			{
				switch (inputInt)
				{
					case 1:
						//if (enterInvestigationList() == true)

						Institution targetInstitution = selectInstitution("Select institution to investigate");
						if (targetInstitution != null)
						{
							investigateInstitution(targetInstitution);
							return true;
						}

						Console.WriteLine("Command not found");
						return false;
						
					case 2:
						//follow suspect 
						Operative targetAsset = selectAsset("Select asset to shadow");

						return true;
					case 3:
						return true;
				}

			}
			else {
				Console.WriteLine("Command not found");
				return false;
			}

			return false;
		}

		public void performTurn()
		{

			if (enterSelectActionChoice())
			{

				//deposit messages
				//perform day's activity
				//gather responses & intelligence
				//generateActionList();

				inGameDate = inGameDate.AddDays(1);

				//Console.WriteLine("Delivering messages to dead drops");
				//System.Threading.Thread.Sleep(2000);
				//Console.WriteLine("Investigating Ministry of Defense");
				//System.Threading.Thread.Sleep(2000);
				Console.WriteLine("Collecting intel");
				//generateDailyIntel();

				Console.WriteLine("-------------------------------");

				//System.Threading.Thread.Sleep(2000);

				//			printPlayerStatus();
			}
			else {//reset
			}

		}

		void generateDailyIntel()
		{
			//calculate daily intel product for each operative
			foreach (Operative agent in currentOperatives)
			{
				if (agent.currentTask == Operative.assetTask.gatheringIntel)
				{
					int intelQuantity = agent.getDailyIntelProduct();
					totalIntelGenerated += intelQuantity;

					Console.WriteLine("Asset " + agent.realName.ToString() + " delivered " + intelQuantity + " documents");
				}
			}
		}

		public void listCurrentOperatives()
		{
			Console.WriteLine("-------------------------------");
			if (currentOperatives.Count == 0)
			{
				Console.WriteLine("No assets available");
			}
			else {
				string agentStr = "Asset";
				if (currentOperatives.Count > 1)
				{
					agentStr = "Assets";
				}

				Console.WriteLine( currentOperatives.Count + " "+ agentStr + ":");
				foreach (Operative agent in currentOperatives)
				{
					//Console.WriteLine(agent.Name);
					agent.printOperativeDetails();
				}
			}
			Console.WriteLine("-------------------------------");
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
