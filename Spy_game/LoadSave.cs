using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Spy_game
{
	public  class LoadSave
	{
		static string saveFilePath = "saveData.dat";


		public static GameState loadSavedGame()
		{
			if (!File.Exists(saveFilePath)) {
				return null;
			}

			BinaryFormatter bf = new BinaryFormatter();
			FileStream fs = new FileStream(saveFilePath, FileMode.Open);

			GameState resultGamestate = (GameState)bf.Deserialize(fs);
			fs.Close();
			return resultGamestate;
		}

		public static void saveGameState(GameState gameState)
		{
			BinaryFormatter bf = new BinaryFormatter();

			FileStream fs = new FileStream(saveFilePath, FileMode.Create);

			bf.Serialize(fs, gameState);

		}
	}
}
