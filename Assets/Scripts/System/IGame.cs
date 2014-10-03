using UnityEngine;
using System.Collections;

public interface IGame  {

	void switchWhiteTurnState();
	void switchDarkTurnState();
	void switchWhiteSelectedPieceState( int select_piece);
	void switchDarkSelectedPieceState( int select_piece);


	void setState(IGameState new_state);
	void firedEvent(string event_name ,object data);

	bool checkExistingWhitePieceAtPos(int pos);
	bool checkNullOrDarkPieceAtPos(int pos);
	bool checkExistingDarkPieceAtPos(int pos);
	bool checkNullOrWhitePieceAtPos(int pos);

	void destroyPos(int pos);
	

	void updatePiecePosition(int oldPos , int newPos);

	void sendMessage(string message,object data);
}
