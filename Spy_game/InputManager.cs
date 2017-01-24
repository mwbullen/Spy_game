using System;
using System.Collections;
namespace Spy_game
{
	public class InputManager
	{
		 Hashtable standardActionsHT;
		public enum standardAction { Exit, NextTurn, ListAgents, NewGame,CommandNotFound }

		public InputManager()
		{
			initStandardActions();
		}

		public standardAction processInput(string inputStr)
		{
			if (inputStr == null ||inputStr == "") { return standardAction.NextTurn;}
				
			if (standardActionsHT.ContainsKey(inputStr.ToUpper())) {
				return (standardAction)standardActionsHT[inputStr.ToUpper()];
			}

			    return standardAction.CommandNotFound;
		}
		
		public void initStandardActions()
		{
			standardActionsHT = new Hashtable();

			standardActionsHT.Add("X", standardAction.Exit);
			standardActionsHT.Add("null", standardAction.NextTurn);
			standardActionsHT.Add("L", standardAction.ListAgents);
			standardActionsHT.Add("NEW", standardAction.NewGame);
		}

		public string getActionPrompts
		{
			get {
				string result = "";
				foreach (standardAction action in standardActionsHT.Values)
				{
					result += action.ToString() + ", ";

				}
				return result.Trim(',');

			}
		}
	}
}
