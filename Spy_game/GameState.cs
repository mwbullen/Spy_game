using System;
using System.Collections.Generic;

namespace Spy_game
{
	[Serializable]
	public class GameState
	{
		public List<Operative> currentOperatives;


		public GameState()
		{
			currentOperatives = new List<Operative>();
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
	}


}
