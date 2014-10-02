using UnityEngine;
using System.Collections;

public interface IGameState {
	void enter(IGame game);
	void handleInput(IGame game,string input ,object data);
	void update(IGame game ,float deltaTime);
}