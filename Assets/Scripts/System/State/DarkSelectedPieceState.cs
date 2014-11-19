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
			if(game.checkDarkPieceCanMoveToPos(selectedPiece,nextpos))
			{
				Hashtable hash = new Hashtable();
				if(game.checkExistingWhitePieceAtPos(nextpos))
				{
					game.sendMessage(GameMessage.DESTROY_PIECE,nextpos);
					game.destroyPos(nextpos);
					hash.Add("eat", true);
				}
				else
					hash.Add("eat",false);



				//den di duoc

				hash.Add("piece",selectedPiece);
				hash.Add("nextPos", nextpos);
				game.sendMessage(GameMessage.MOVE_PIECE,hash);
				game.updatePiecePosition( selectedPiece,nextpos);
				game.setState(new WhiteTurnState());


				
			}
			else if(game.checkExistingDarkPieceAtPos(nextpos))
			{
				game.setState(new DarkSelectedPieceState(nextpos));
			}

			
			
		}
		
	}
	public void update(IGame game ,float deltaTime)
	{
		
	}
}
