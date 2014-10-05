using UnityEngine;
using System.Collections;

public static class Constant  {

	public static string pos_direct = "Prefabs/pos";
	public static string piece_direct = "Prefabs/Pieces/";

	public static string MappingIntToPieceName(int piece ,int color)
	{
		if(color == 2)
		{
		switch (piece) 
		{
			case 1: return "TotDo";
			case 2: return "SiDo";
			case 3: return "TuongDo";
			case 4: return "MaDo";
			case 5: return "PhaoDo";
			case 6: return "XeDo";
			case 7: return "VuaDo";		
		}
		}

		if(color == 1)
		{
			switch (piece) 
			{
			case 1: return "TotDen";
			case 2: return "SiDen";
			case 3: return "TuongDen";
			case 4: return "MaDen";
			case 5: return "PhaoDen";
			case 6: return "XeDen";
			case 7: return "VuaDen";		
			}
		}
		return "";


	}

	public static Hashtable MappingPosToRealXY(int pos)
	{
		Hashtable hash = new Hashtable ();
		float dv = 0.78f;
		float init_x = -3.12f;
		float init_y = 3.51f;


		hash.Add("X", init_x + ((pos)%9)*dv);
		hash.Add("Y",  init_y - ((pos)/9)*dv);
		return hash;

	}

	}

