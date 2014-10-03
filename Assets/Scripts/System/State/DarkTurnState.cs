using UnityEngine;
using System.Collections;

public class DarkTurnState :IGameState {
	
	public void enter(IGame game)
	{
		game.switchDarkTurnState ();
	}
	public void handleInput(IGame game,string input ,object data)
	{
		if (input == PositionMessage.CLICKED_POSITION) 
		{
			if(game.checkExistingDarkPieceAtPos((int)data)){
				game.setState(new DarkSelectedPieceState((int)data));
				
				
			}
		}
		
	}
	public void update(IGame game ,float deltaTime)
	{
		
	}
}
