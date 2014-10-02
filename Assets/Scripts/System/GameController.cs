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

public class GameController : MonoBehaviour {

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

	private GameObject loadPosPrefab()
	{
		Debug.Log ("chay load");
		return Instantiate(Resources.Load(Constant.pos_direct)) as GameObject;
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





	// Use this for initialization
	void Start () {
		board = GameObject.FindGameObjectWithTag("board");



		innitPos ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
