using UnityEngine;
using System.Collections;

public class WhiteSelectedPieceState : IGameState {
	private int selectedPiece;

	public WhiteSelectedPieceState(int selectedPiece)
	{
		this.selectedPiece = selectedPiece;
	}



	public void enter(IGame game)
	{
		game.switchWhiteSelectedPieceState ();
	}
	public void handleInput(IGame game,string input ,object data)
	{
		if (input == PositionMessage.CLICKED_POSITION) 
		{
			if(game.checkNullOrDarkPieceAtPos((int)data))
			{
				game.setState(new DarkTurnState());


			}
			else
			{
				game.setState(new WhiteSelectedPieceState((int)data));
			}
			
			
		}
		
	}
	public void update(IGame game ,float deltaTime)
	{
		
	}
}
