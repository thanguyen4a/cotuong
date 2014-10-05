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
		for (i = 0; i<90; i++) 
		{
			game_object = loadPosPrefab();
			PositionController pos_controller = game_object.GetComponent<PositionController>();
			pos_controller.setPosID(i);
			float new_x =  init_x + ((i)%9)*dv;
			float new_y =  init_y - ((i)/9)*dv;
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
		for (i = 0; i<90; i++) 
		{
			piece_name = Constant.MappingIntToPieceName(piece[i],color[i]);
			Debug.Log ("piece_name ="+piece_name);
			if(piece_name!="")
			{
				game_object = loadPiecePrefab(piece_name);
				PieceController piece_controller = game_object.GetComponent<PieceController>();
				piece_controller.setPosID(i);
				float new_x =  init_x + ((i)%9)*dv;
				float new_y =  init_y - ((i)/9)*dv;
				game_object.transform.position = new Vector3(new_x,new_y,0);
				game_object.transform.parent = board.transform;
			}
		}

	}

	// Use this for initialization
	void Start () {
		base.OnStart ();
		setState (new WhiteTurnState ());
		board = GameObject.FindGameObjectWithTag("board");
		innitPos ();
		innitPiece ();

	}
	
	// Update is called once per frame
	void Update () {
		_state.update(this,Time.deltaTime);
	
	}
	public void switchWhiteTurnState()
	{
		Debug.Log ("switchWhiteTurnState");

	}
	public void switchDarkTurnState()
	{
		Debug.Log ("switchDarkTurnState");
	}
	public void switchWhiteSelectedPieceState(int select_piece)
	{
		Debug.Log ("switchWhiteSelectedPieceState");
		sendMessage(GameMessage.SELECT_PIECE,select_piece);
	}
	public void switchDarkSelectedPieceState(int select_piece)
	{
		Debug.Log ("switchDarkSelectedPieceState");
		sendMessage (GameMessage.SELECT_PIECE, select_piece);
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

	public bool checkExistingDarkPieceAtPos(int pos)
	{
		if (color [pos] == 1)return true;
		return false;
	}

	public bool checkWhitePieceCanMoveToPos(int oldPos , int nextPos)
	{
		if (piece[oldPos] == 6) {				
			return Xe.XeWhiteCanMove (oldPos, nextPos, this.color, this.piece);
		}

		if (piece [oldPos] == 5) 
		{
			return Phao.PhaoWhiteCanMove(oldPos, nextPos, this.color, this.piece);
		}

		if (piece [oldPos] == 4) 
		{
			return Ma.MaWhiteCanMove(oldPos, nextPos, this.color, this.piece);
	    }

		if (piece [oldPos] == 3) 
		{
			return Tuong.TuongWhiteCanMove(oldPos, nextPos, this.color, this.piece);
		}

		if (piece [oldPos] == 2) 
		{
			return Si.SiWhiteCanMove(oldPos, nextPos, this.color, this.piece);
		}

		if (piece [oldPos] == 1) 
		{
			return Tot.TotWhiteCanMove(oldPos, nextPos, this.color, this.piece);
		}
		
		if (color[nextPos] == 1 || color [nextPos] == 0)
			return true;
		return false;



	}

	public bool checkDarkPieceCanMoveToPos(int oldPos , int nextPos)
	{
		if (piece[oldPos] == 6) {				
			return Xe.XeDarkCanMove (oldPos, nextPos, this.color, this.piece);
		}

		if (piece [oldPos] == 5) 
		{
			return Phao.PhaoDarkCanMove(oldPos, nextPos, this.color, this.piece);
		}

		if (piece [oldPos] == 4) 
		{
			return Ma.MaDarkCanMove(oldPos, nextPos, this.color, this.piece);
		}

		if (piece [oldPos] == 3) 
		{
			return Tuong.TuongDarkCanMove(oldPos, nextPos, this.color, this.piece);
		}

		if (piece [oldPos] == 2) 
		{
			return Si.SiDarkCanMove(oldPos, nextPos, this.color, this.piece);
		}

		if (piece [oldPos] == 1) 
		{
			return Tot.TotDarkCanMove(oldPos, nextPos, this.color, this.piece);
		}

		if (color[nextPos] == 2 || color [nextPos] == 0)
			return true;
		return false;
		

	}

	public void updatePiecePosition(int oldPos , int newPos)
	{

		color[newPos] = color[oldPos];
		piece[newPos] = piece[oldPos];
		color[oldPos] = 0;
		piece[oldPos] = 0;
	}

	public void destroyPos(int pos)
	{

		color[pos] = piece[pos] = 0;
	}

	public override void updateMessage(string message,object data, ObservableObject sender){
		firedEvent(message,data);
	}



}
