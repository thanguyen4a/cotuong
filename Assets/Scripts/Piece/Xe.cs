using UnityEngine;
using System.Collections;

public static class Xe  {

	public static bool XeWhiteCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
						return false;

		// hang doc
		if (oldPos % 9 == nextPos % 9)
		{

			if(oldPos < nextPos)
			{

				for(int i = oldPos +9 ; i < nextPos ;i+=9 )
				{
					if(piece[i]!=0)return false;
				}
				if(color[nextPos] == 2)return false;
				return true;
			}

			if(oldPos > nextPos)
			{
				
				for(int i = oldPos -9 ; i > nextPos ;i-=9 )
				{
					if(piece[i]!=0)return false;
				}
				if(color[nextPos] == 2)return false;
				return true;
			}
		}
		///hang ngang

		if (oldPos / 9 == nextPos / 9)
		{
			
			if(oldPos < nextPos)
			{
				
				for(int i = oldPos +1 ; i < nextPos ;i+=1 )
				{
					if(piece[i]!=0)return false;
				}
				if(color[nextPos] == 2)return false;
				return true;
			}
			
			if(oldPos > nextPos)
			{
				
				for(int i = oldPos -1 ; i > nextPos ;i-=1 )
				{
					if(piece[i]!=0)return false;
				}
				if(color[nextPos] == 2)return false;
				return true;
			}
		}

		return false;
	}


	public  static bool XeDarkCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;
		
		// hang doc
		if (oldPos % 9 == nextPos % 9)
		{
			
			if(oldPos < nextPos)
			{
				
				for(int i = oldPos +9 ; i < nextPos ;i+=9 )
				{
					if(piece[i]!=0)return false;
				}
				if(color[nextPos] == 1)return false;
				return true;
			}
			
			if(oldPos > nextPos)
			{
				
				for(int i = oldPos -9 ; i > nextPos ;i-=9 )
				{
					if(piece[i]!=0)return false;
				}
				if(color[nextPos] == 1)return false;
				return true;
			}
		}
		///hang ngang
		
		if (oldPos / 9 == nextPos / 9)
		{
			
			if(oldPos < nextPos)
			{
				
				for(int i = oldPos +1 ; i < nextPos ;i+=1 )
				{
					if(piece[i]!=0)return false;
				}
				if(color[nextPos] == 1)return false;
				return true;
			}
			
			if(oldPos > nextPos)
			{
				
				for(int i = oldPos -1 ; i > nextPos ;i-=1 )
				{
					if(piece[i]!=0)return false;
				}
				if(color[nextPos] == 1)return false;
				return true;
			}
		}
		
		return false;
	}



}
