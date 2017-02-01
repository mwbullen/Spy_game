using System;
using System.Collections.Generic;

namespace Spy_game
{
	[Serializable]
	public class Institution
	{
		public string Name;
		public int sortNumber;

		public int paranoiaModifier;  //assets at high-security orgs will be more paranoid than lower-security orgs
		public  int recruitChance = 30;

		static string[] institutionNames = { "Security Services", "Housing Authority", "Automotive Registry", "National Bank", "Military Procurement", "Education ", "Information and Press", "Construction", "Prisons" };

		public Institution(string newName)
		{
			Name = newName;
		}


		public static List<Institution> generateInstitutionList()
		{
			List<Institution> resultList = new List<Institution>();

			int x = 1;

			foreach (string instName in institutionNames)
			{
				Institution i = new Institution(instName);
				i.sortNumber = x;

				resultList.Add(i);

				x += 1;
			}

			return resultList;
		}



	}

}