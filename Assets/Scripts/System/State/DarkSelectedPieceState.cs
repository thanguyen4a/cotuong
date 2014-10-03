using UnityEngine;
using System.Collections;

public class DarkSelectedPieceState : IGameState {

	private int selectedPiece;
	
	public DarkSelectedPieceState(int selectedPiece)
	{
		this.selectedPiece = selectedPiece;
	}

	public void enter(IGame game)
	{
		game.switchDarkSelectedPieceState (selectedPiece);
	}
	public void handleInput(IGame game,string input ,object data)
	{
		if (input == PositionMessage.CLICKED_POSITION) 
		{
			int nextpos = (int)data;
			if(game.checkNullOrWhitePieceAtPos(nextpos))
			{
				if(game.checkExistingWhitePieceAtPos(nextpos))
				{
					game.sendMessage(GameMessage.DESTROY_PIECE,nextpos);
					game.destroyPos(nextpos);
				}


				game.setState(new WhiteTurnState());
				//den di duoc
				Hashtable hash = new Hashtable();
				hash.Add("piece",selectedPiece);
				hash.Add("nextPos", nextpos);
				game.sendMessage(GameMessage.MOVE_PIECE,hash);
				game.updatePiecePosition( selectedPiece,nextpos);


				
			}
			else
			{
				game.setState(new DarkSelectedPieceState((int)data));
			}
			
			
		}
		
	}
	public void update(IGame game ,float deltaTime)
	{
		
	}
}
