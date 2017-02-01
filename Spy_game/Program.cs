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
				currentGameState.printPlayerStatus();

				//inputStr = getUserInput(inputManager.getActionPrompts);

				//InputManager.standardAction action =  inputManager.processInput(inputStr);

				inputStr = getUserInput("List assets, [NextTurn]");


				switch (inputStr.ToUpper())
					{
					//case InputManager.standardAction.ListAssets:
					case "L":
							currentGameState.listCurrentOperatives();
							break;

					case "":
					case "N":
							currentGameState.performTurn();
							break;
					case "NEW":
							Console.Clear();
							LoadSave.newGame();
							break;
					default:
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
			NameGenerator.loadNames();
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
