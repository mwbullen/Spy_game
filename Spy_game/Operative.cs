using System;
using System.Collections;

[Serializable]

public class Operative  {
	public OperativeInfo Info = new OperativeInfo();

	public Operative(string name)
	{
		Info.Name = name;
	}
}
