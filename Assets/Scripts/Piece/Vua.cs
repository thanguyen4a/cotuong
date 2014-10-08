using UnityEngine;
using System.Collections;

public static class Vua  {
	
	public static bool VuaWhiteCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;

		if (color [nextPos] == 2)
			return false;
		
		int x = oldPos % 9;
		int y = oldPos / 9;
		
		int next_x = nextPos % 9;
		int next_y = nextPos / 9;

		//constant pos: 66,67,68, 75,76,77, 84,85,86

		int[] cungWhitePos = {66,67,68,75,76,77,84,85,86};
		foreach (int cungPos in cungWhitePos) 
		{
			if (cungPos.Equals(nextPos))
			{
				if((Mathf.Abs(next_x - x) + Mathf.Abs(next_y - y)) == 1)return true;
				return false;
			}
		}
		return false;
	
	}
	
	
	public static bool VuaDarkCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;

		if (color [nextPos] == 1)
			return false;
		
		int x = oldPos % 9;
		int y = oldPos / 9;
		
		int next_x = nextPos % 9;
		int next_y = nextPos / 9;

		//constant pos: 3,4,5 ,12,13,14 ,21,22,23
		
		int[] cungDarkPos = {3,4,5,12,13,14,21,22,23};
		foreach (int cungPos in cungDarkPos) 
		{
			if (cungPos.Equals(nextPos))
			{
				if((Mathf.Abs(next_x - x) + Mathf.Abs(next_y - y)) == 1)return true;
				return false;
			}
		}
		return false;

	}
}
