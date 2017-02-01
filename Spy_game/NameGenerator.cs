using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
namespace Spy_game
{
	public static  class NameGenerator
	{
		static List<string> LastNames = new List<string>();
		static List<string> FemaleFirstNames = new List<string>();
		static List<string> MaleFirstNames =  new List<string>();

		public static void loadNames()
		{
			loadFiletoList("LastNames.txt", LastNames);
			loadFiletoList("FirstNames_Female.txt", FemaleFirstNames);
			loadFiletoList("FirstNames_Male.txt", MaleFirstNames);
		}

		static void loadFiletoList(string filePath, List<string> targetList)
		{
			targetList.Clear();

			FileStream fs = new FileStream(filePath, FileMode.Open);

			StreamReader r = new StreamReader(fs);

			while (!r.EndOfStream)
			{
				targetList.Add(r.ReadLine());
			}

			r.Close();

		}

	}
}
