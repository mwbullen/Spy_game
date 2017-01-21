using System;


namespace Spy_game
{
	class MainClass
	{
		public static GameState currentGameState = null;

		public static void Main(string[] args)
		{
			initGame();

			string inputStr = "";

			while (inputStr != "x")
			{
			 
				inputStr = getUserInput("Enter action");

				switch (inputStr.ToUpper())
				{
					case "L":
						currentGameState.listCurrentOperatives();
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
