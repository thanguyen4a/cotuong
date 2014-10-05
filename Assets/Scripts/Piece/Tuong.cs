using UnityEngine;
using System.Collections;

public static class Tuong  {
	
	public static bool TuongWhiteCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;
		
		int x = oldPos % 9;
		int y = oldPos / 9;
		
		int next_x = nextPos % 9;
		int next_y = nextPos / 9;
		
		int xCan =-1, yCan=-1;
		
		if((Mathf.Abs(next_y- y) == 2) && (Mathf.Abs(next_x - x) == 2) && next_y>4)
		{
			xCan = (x + next_x)/2;
			yCan = (y + next_y)/2;		
		}

		if (xCan == -1)return false;

		int posCan = 9 * yCan + xCan;
		if (piece[posCan] != 0)return false;
		if (color[nextPos] == 2)return false;
		
		return true;
	}
	
	
	public static bool TuongDarkCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;
		
		int x = oldPos % 9;
		int y = oldPos / 9;
		
		int next_x = nextPos % 9;
		int next_y = nextPos / 9;
		
		int xCan =-1, yCan=-1;
		
		if((Mathf.Abs(next_y- y) == 2) && (Mathf.Abs(next_x - x) == 2) && next_y<5)
		{
			xCan = (x + next_x)/2;
			yCan = (y + next_y)/2;		
		}
		
		if (xCan == -1)return false;
		
		int posCan = 9 * yCan + xCan;
		if (piece[posCan] != 0)return false;
		if (color[nextPos] == 1)return false;
		
		return true;
	}
}
