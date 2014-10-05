using UnityEngine;
using System.Collections;

public static class Ma  {
	
	public static bool MaWhiteCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;

		int x = oldPos % 9;
		int y = oldPos / 9;

		int next_x = nextPos % 9;
		int next_y = nextPos / 9;

		int xCan =-1, yCan=-1;

		if(next_x - x == 2 && Mathf.Abs(next_y- y) == 1)
		{
			xCan = x+1;
			yCan = y;

		}

		if(next_x - x == -2 && Mathf.Abs(next_y- y) == 1)
		{
			xCan = x-1;
			yCan = y;
			
		}

		if(Mathf.Abs(next_x - x) == 1 && next_y- y == 2)
		{
			xCan = x;
			yCan = y+1;
			
		}

		if(Mathf.Abs(next_x - x) == 1 && next_y- y == -2)
		{
			xCan = x;
			yCan = y-1;
			
		}

		if(xCan == -1) return false;

		int posCan = yCan * 9 + xCan;

		if (piece[posCan] != 0)
						return false;

		if (color [nextPos] == 2)
						return false;

		return true;
	}
	
	
	public static bool MaDarkCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;
		
		int x = oldPos % 9;
		int y = oldPos / 9;
		
		int next_x = nextPos % 9;
		int next_y = nextPos / 9;
		
		int xCan =-1, yCan=-1;
		
		if(next_x - x == 2 && Mathf.Abs(next_y- y) == 1)
		{
			xCan = x+1;
			yCan = y;
			
		}
		
		if(next_x - x == -2 && Mathf.Abs(next_y- y) == 1)
		{
			xCan = x-1;
			yCan = y;
			
		}
		
		if(Mathf.Abs(next_x - x) == 1 && next_y- y == 2)
		{
			xCan = x;
			yCan = y+1;
			
		}
		
		if(Mathf.Abs(next_x - x) == 1 && next_y- y == -2)
		{
			xCan = x;
			yCan = y-1;
			
		}
		
		if(xCan == -1) return false;
		
		int posCan = yCan * 9 + xCan;
		
		if (piece[posCan] != 0)
			return false;
		
		if (color [nextPos] == 1)
			return false;
		
		return true;
	}

	
	
	
}
