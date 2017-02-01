using System;
namespace Spy_game
{
	[Serializable]
	public class Name
	{
		public string LastName;
		public string FirstName;

		public Name()
		{
		}

		public override string ToString()
		{
			return FirstName + " " + LastName;
		}
	}
}
