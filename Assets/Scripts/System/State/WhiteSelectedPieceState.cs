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
			if(game.checkWhitePieceCanMoveToPos(selectedPiece,nextpos))
			{
				Hashtable hash = new Hashtable();
				if(game.checkExistingDarkPieceAtPos(nextpos))
				{
					game.sendMessage(GameMessage.DESTROY_PIECE,nextpos);
					game.destroyPos(nextpos);
					hash.Add("eat", true);
				}
				else
					hash.Add("eat",false);


				//trang di duoc

				hash.Add("piece",selectedPiece);
				hash.Add("nextPos", nextpos);
				game.sendMessage(GameMessage.MOVE_PIECE,hash);
				game.updatePiecePosition( selectedPiece,nextpos);
				game.setState(new DarkTurnState());
			}
			else if(game.checkExistingWhitePieceAtPos(nextpos))
			{
				game.setState(new WhiteSelectedPieceState(nextpos));
			}

			
			
		}
		
	}
	public void update(IGame game ,float deltaTime)
	{
		
	}
}
