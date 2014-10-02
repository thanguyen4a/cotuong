using UnityEngine;
using System.Collections;

public interface IGame  {

	void switchWhiteTurnState();
	void switchDarkTurnState();
	void switchWhiteSelectedPieceState();
	void switchDarkSelectedPieceState();
	void switchWhiteSelectedPosState();
	void switchDarkSelectedPosState();
	void setState(IGameState new_state);
	void firedEvent(string event_name ,object data);
	bool checkExistingWhitePieceAtPos(int pos);
	bool checkNullOrDarkPieceAtPos(int pos);
}
