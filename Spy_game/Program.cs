using System;


namespace Spy_game
{
	class MainClass
	{
		public static GameState currentGameState = null;
		public static InputManager inputManager = new InputManager();

		public static void Main(string[] args)
		{
			initGame();

			string inputStr = "";

			while (inputStr != "x")
			{			 
				inputStr = getUserInput("Enter action");

				if (inputStr == "")
				{
					currentGameState.performTurn();
				}
				else
				{
					

					InputManager.standardAction action = (InputManager.standardAction)inputManager.standardActionsHT[inputStr.ToUpper()];

					switch (action)
					{

						case InputManager.standardAction.ListAgents:
							currentGameState.listCurrentOperatives();
							break;

						case InputManager.standardAction.NextTurn:
							currentGameState.performTurn();
							break;
					}
				}


			}
		}

		public static string getUserInput(string prompt)
		{
			Console.WriteLine(prompt);

			return Console.ReadLine();

		}

		public static void initGame()
		{
			currentGameState = LoadSave.loadSavedGame();
			if (currentGameState == null)
			{
				Console.WriteLine("Creating new game");
				currentGameState = new GameState();
				LoadSave.saveGameState(currentGameState);
			}
			else {
				Console.WriteLine("Loading saved game");
			}
		}
	}
}
