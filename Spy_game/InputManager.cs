using System;
using System.Collections;
namespace Spy_game
{
	public class InputManager
	{
		public Hashtable standardActionsHT;
		public enum standardAction { Exit, NextTurn, ListAgents }

		public InputManager()
		{
			initStandardActions();
		}

		public void initStandardActions()
		{
			standardActionsHT = new Hashtable();

			standardActionsHT.Add("X", standardAction.Exit);
			standardActionsHT.Add("null", standardAction.NextTurn);
			standardActionsHT.Add("L", standardAction.ListAgents);
		}

	}
}
