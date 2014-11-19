using UnityEngine;
using System.Collections;

public class WhiteTurnState : IGameState {


	public void enter(IGame game)
	{
		game.switchWhiteTurnState ();

	}
	public void handleInput(IGame game,string input ,object data)
	{
		if (input == PositionMessage.CLICKED_POSITION) 
		{
			if(game.checkExistingWhitePieceAtPos((int)data)){
				game.setState(new WhiteSelectedPieceState((int)data));


			}
		}

	}
	public void update(IGame game ,float deltaTime)
	{

	}
}
