using UnityEngine;
using System.Collections;

public static class Tot  {
	
	public static bool TotWhiteCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;

		int x = oldPos % 9;
		int y = oldPos / 9;
		
		int next_x = nextPos % 9;
		int next_y = nextPos / 9;

		//chua qua song
		if (y >= 5) 
		{
			if(x != next_x)return false;
			if(y != (next_y + 1))return false;
			if(color[nextPos] == 2)return false;
			return true;
		}
		else
		//qua song
		{
			if((x == next_x) && (y == (next_y + 1)))
			{
				if(color[nextPos] == 2)return false;
				return true;
			}

			if((y == next_y) && Mathf.Abs(next_x - x) == 1)
			{
				if(color[nextPos] == 2)return false;
				return true;
			}
			return false;
		}
	}
	
	
	public  static bool TotDarkCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;
		
		int x = oldPos % 9;
		int y = oldPos / 9;
		
		int next_x = nextPos % 9;
		int next_y = nextPos / 9;
		
		//chua qua song
		if (y < 5) 
		{
			if(x != next_x)return false;
			if(y != (next_y - 1))return false;
			if(color[nextPos] == 1)return false;
			return true;
		}
		else
			//qua song
		{
			if((x == next_x) && (y == (next_y - 1)))
			{
				if(color[nextPos] == 1)return false;
				return true;
			}
			
			if((y == next_y) && Mathf.Abs(next_x - x) == 1)
			{
				if(color[nextPos] == 1)return false;
				return true;
			}
			return false;
		}
	}
}