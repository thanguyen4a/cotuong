using UnityEngine;
using System.Collections;

public static class Si  {
	
	public static bool SiWhiteCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;
		
		// Si trang co 5 pos: 66,68,76,84,86

		// si o giua
		if(oldPos == 76)
		{
			if((nextPos == 66)||(nextPos == 68)||(nextPos == 84)||(nextPos == 86))
			{
				if(color[nextPos] == 2)return false;
				else return true;
			}
		}

		// so p 4 goc
		if ((oldPos == 66) || (oldPos == 68) || (oldPos == 84) || (oldPos == 86)) 
		{
			if((nextPos == 76) && (color[nextPos]!=2))return true;
		}

		return false;
	}
	
	
	public  static bool SiDarkCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;
		
		// Si trang co 5 pos: 3,5,13,21,23
		
		// si o giua
		if(oldPos == 13)
		{
			if((nextPos == 3)||(nextPos == 5)||(nextPos == 21)||(nextPos == 23))
			{
				if(color[nextPos] == 1)return false;
				else return true;
			}
		}
		
		// so p 4 goc
		if ((oldPos == 3) || (oldPos == 5) || (oldPos == 21) || (oldPos == 23)) 
		{
			if((nextPos == 13) && (color[nextPos]!=1))return true;
		}
		
		return false;
	}
}

