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
				inputStr = getUserInput(inputManager.getActionPrompts);

				InputManager.standardAction action =  inputManager.processInput(inputStr);

				switch (action)
					{
						case InputManager.standardAction.ListAgents:
							currentGameState.listCurrentOperatives();
							break;

						case InputManager.standardAction.NextTurn:
							currentGameState.performTurn();
							break;
						case InputManager.standardAction.NewGame:
							LoadSave.newGame();
							break;
						case InputManager.standardAction.CommandNotFound:
							Console.WriteLine("Command not found: " + inputStr);
							break;
						
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
