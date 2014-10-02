using UnityEngine;
using System.Collections;

public enum Color {

	DARK = 1,
	LIGHT =2 ,
	EMPTY =0,
}

public enum PIECE {
	PAWN = 1 ,
	BISHOP = 2 ,
	ELEPHANT = 3,
	KNIGHT = 4,
	CANNON = 5,
	ROOK = 6,
	KING = 7,
	EMPTY = 0

}

public class GameController : ObservableMonoBehaviour,IGame {

	public GameObject board;

	private int side = 2 , xside = 1 ;

	private int[] piece =
		{6, 4, 3, 2, 7, 2, 3, 4, 6,
		 0, 0, 0, 0, 0, 0, 0, 0, 0,
		 0, 5, 0, 0, 0, 0, 0, 5, 0,
		 1, 0, 1, 0, 1, 0, 1, 0, 1,
		 0, 0, 0, 0, 0, 0, 0, 0, 0,
		 0, 0, 0, 0, 0, 0, 0, 0, 0,
		 1, 0, 1, 0, 1, 0, 1, 0, 1,
		 0, 5, 0, 0, 0, 0, 0, 5, 0,
		 0, 0, 0, 0, 0, 0, 0, 0, 0,
		 6, 4, 3, 2, 7, 2, 3, 4, 6};
	private int[] color =
		{1, 1, 1, 1, 1, 1, 1, 1, 1,
		 0, 0, 0, 0, 0, 0, 0, 0, 0,
		 0, 1, 0, 0, 0, 0, 0, 1, 0,
		 1, 0, 1, 0, 1, 0, 1, 0, 1,
		 0, 0, 0, 0, 0, 0, 0, 0, 0,
		 0, 0, 0, 0, 0, 0, 0, 0, 0,
		 2, 0, 2, 0, 2, 0, 2, 0, 2,
		 0, 2, 0, 0, 0, 0, 0, 2, 0,
		 0, 0, 0, 0, 0, 0, 0, 0, 0,
		 2, 2, 2, 2, 2, 2, 2, 2, 2};

	private IGameState _state;






	private GameObject loadPosPrefab()
	{
		Debug.Log ("chay load");
		return Instantiate(Resources.Load(Constant.pos_direct)) as GameObject;
	}

	private GameObject loadPiecePrefab(string piece_name)
	{
		Debug.Log ("chay load");
		return Instantiate(Resources.Load(Constant.piece_direct+piece_name)) as GameObject;
	}

	private void innitPos()
	{
		GameObject game_object;
		float dv = 0.78f;
		float init_x = -3.12f;
		float init_y = 3.51f;
		int i;
		for (i = 1; i<=90; i++) 
		{
			game_object = loadPosPrefab();
			PositionController pos_controller = game_object.GetComponent<PositionController>();
			pos_controller.setPosID(i);
			float new_x =  init_x + ((i-1)%9)*dv;
			float new_y =  init_y - ((i-1)/9)*dv;
			game_object.transform.position = new Vector3(new_x,new_y,0);
			game_object.transform.parent = board.transform;

	    }

	}

	private void innitPiece()
	{
		GameObject game_object;
		float dv = 0.78f;
		float init_x = -3.12f;
		float init_y = 3.51f;

		int i;
		string piece_name;
		for (i = 1; i<=90; i++) 
		{
			piece_name = Constant.MappingIntToPieceName(piece[i-1],color[i-1]);
			Debug.Log ("piece_name ="+piece_name);
			if(piece_name!="")
			{
				game_object = loadPiecePrefab(piece_name);
				float new_x =  init_x + ((i-1)%9)*dv;
				float new_y =  init_y - ((i-1)/9)*dv;
				game_object.transform.position = new Vector3(new_x,new_y,0);
				game_object.transform.parent = board.transform;
			}
		}

	}

	// Use this for initialization
	void Start () {
		base.OnStart ();
		board = GameObject.FindGameObjectWithTag("board");
		innitPos ();
		innitPiece ();
		setState (new WhiteTurnState ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void switchWhiteTurnState()
	{
		Debug.Log ("switchWhiteTurnState");

	}
	public void switchDarkTurnState()
	{
		Debug.Log ("switchDarkTurnState");
	}
	public void switchWhiteSelectedPieceState()
	{
		Debug.Log ("switchWhiteSelectedPieceState");
	}
	public void switchDarkSelectedPieceState()
	{
		Debug.Log ("switchDarkSelectedPieceState");
	}
	public void switchWhiteSelectedPosState()
	{
		Debug.Log ("switchWhiteSelectedPosState");
	}
	public void switchDarkSelectedPosState()
	{
		Debug.Log ("switchDarkSelectedPosState");
	}
	public void setState(IGameState new_state)
	{
		this._state = new_state;
		this._state.enter (this);
	}
	public void firedEvent(string event_name ,object data)
	{
		_state.handleInput (this, event_name, data);
	}

	public bool checkExistingWhitePieceAtPos(int pos)
	{
		if (color [pos] == 2)return true;
		return false;
	}

	public bool checkNullOrDarkPieceAtPos(int pos)
	{
		if (color [pos] == 1 || color [pos] == 0)return true;
		return false;
	}


	public override void updateMessage(string message,object data, ObservableObject sender){
		firedEvent(message,data);
	}



}
