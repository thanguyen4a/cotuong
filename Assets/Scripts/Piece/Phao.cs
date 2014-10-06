using UnityEngine;
using System.Collections;

public static class Phao  {
	
	public static bool PhaoWhiteCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;

		if (color [nextPos] != 1) 
		{
			Debug.Log ("di vao vi tri trong");
			return Xe.XeWhiteCanMove(oldPos ,nextPos ,color ,piece);
		}
		else
		{
			// hang doc
			if (oldPos % 9 == nextPos % 9)
			{
				
				if(oldPos < nextPos)
				{
					
					for(int i = oldPos +9 ; i < nextPos ;i+=9 )
					{
						if(piece[i]!=0)return Xe.XeWhiteCanMove(i,nextPos ,color ,piece);
					}

					return false;
				}
				
				if(oldPos > nextPos)
				{
					
					for(int i = oldPos -9 ; i > nextPos ;i-=9 )
					{
						if(piece[i]!=0)return Xe.XeWhiteCanMove(i,nextPos ,color ,piece);
					}

					return false;
				}
			}
			///hang ngang
			
			if (oldPos / 9 == nextPos / 9)
			{
				
				if(oldPos < nextPos)
				{
					
					for(int i = oldPos +1 ; i < nextPos ;i+=1 )
					{
						if(piece[i]!=0)return Xe.XeWhiteCanMove(i,nextPos ,color ,piece);
					}

					return false;
				}
				
				if(oldPos > nextPos)
				{
					
					for(int i = oldPos -1 ; i > nextPos ;i-=1 )
					{
						if(piece[i]!=0)return Xe.XeWhiteCanMove(i,nextPos ,color ,piece);
					}

					return false;
				}
			}

		}

		return false;
	}
	
	
	public  static bool PhaoDarkCanMove(int oldPos , int nextPos ,int[] color ,int[] piece)
	{
		if (oldPos == nextPos)
			return false;
		
		if (color [nextPos] != 2) 
		{
			return Xe.XeDarkCanMove(oldPos ,nextPos ,color ,piece);
		}
		else
		{
			// hang doc
			if (oldPos % 9 == nextPos % 9)
			{
				
				if(oldPos < nextPos)
				{
					
					for(int i = oldPos +9 ; i < nextPos ;i+=9 )
					{
						if(piece[i]!=0)return Xe.XeDarkCanMove(i,nextPos ,color ,piece);
					}
					
					return false;
				}
				
				if(oldPos > nextPos)
				{
					
					for(int i = oldPos -9 ; i > nextPos ;i-=9 )
					{
						if(piece[i]!=0)return Xe.XeDarkCanMove(i,nextPos ,color ,piece);
					}
					
					return false;
				}
			}
			///hang ngang
			
			if (oldPos / 9 == nextPos / 9)
			{
				
				if(oldPos < nextPos)
				{
					
					for(int i = oldPos +1 ; i < nextPos ;i+=1 )
					{
						if(piece[i]!=0)return Xe.XeDarkCanMove(i,nextPos ,color ,piece);
					}
					
					return false;
				}
				
				if(oldPos > nextPos)
				{
					
					for(int i = oldPos -1 ; i > nextPos ;i-=1 )
					{
						if(piece[i]!=0)return Xe.XeDarkCanMove(i,nextPos ,color ,piece);
					}
					
					return false;
				}
			}
			
		}
		
		return false;
	}
	
	
	
}
