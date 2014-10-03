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
		game.switchWhiteSelectedPieceState (selectedPiece);

	}
	public void handleInput(IGame game,string input ,object data)
	{
		if (input == PositionMessage.CLICKED_POSITION) 
		{
			int nextpos = (int)data;
			if(game.checkNullOrDarkPieceAtPos(nextpos))
			{
				if(game.checkExistingDarkPieceAtPos(nextpos))
				{
					game.sendMessage(GameMessage.DESTROY_PIECE,nextpos);
					game.destroyPos(nextpos);
				}

				game.setState(new DarkTurnState());
				//trang di duoc
				Hashtable hash = new Hashtable();
				hash.Add("piece",selectedPiece);
				hash.Add("nextPos", nextpos);
				game.sendMessage(GameMessage.MOVE_PIECE,hash);
				game.updatePiecePosition( selectedPiece,nextpos);
			}
			else
			{
				game.setState(new WhiteSelectedPieceState(nextpos));
			}
			
			
		}
		
	}
	public void update(IGame game ,float deltaTime)
	{
		
	}
}
