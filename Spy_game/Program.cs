using System;


namespace Spy_game
{
	class MainClass
	{
		public GameState currentGameState = new GameState();

		public static void Main(string[] args)
		{
			string inputStr = "";

			while (inputStr != "x")
			{
			 inputStr = getUserInput("Enter action");
			}
		}

		public static string getUserInput(string prompt)
		{
			Console.WriteLine(prompt);

			return Console.ReadLine();

		}
	}
}
