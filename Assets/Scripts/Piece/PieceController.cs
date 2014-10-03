using UnityEngine;
using System.Collections;

public class PieceController : ObservableMonoBehaviour {

	public int pos_id;	
	public void setPosID(int pos_id)
	{
		this.pos_id = pos_id;
	}

	// Use this for initialization
	void Start () {
		base.OnStart ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public override void updateMessage(string message,object data, ObservableObject sender){

		if (message == GameMessage.SELECT_PIECE) 
		{
			if((int)data == pos_id)
			{
				SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
				render.material.color = UnityEngine.Color.red; 
			}

			else{
				SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
				render.material.color = UnityEngine.Color.white;
			}
		}


		if (message == GameMessage.MOVE_PIECE)
		{
			SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
			render.material.color = UnityEngine.Color.white;

			Hashtable hash1 = (Hashtable)data;
			if((int)hash1["piece"] == pos_id)
			{
				Vector3 position = new Vector3();
				position = transform.position;
				Hashtable hash2 = Constant.MappingPosToRealXY((int)hash1["nextPos"]);
				position.x = (float)hash2["X"];
				position.y = (float)hash2["Y"];
				transform.position = position;
				pos_id = (int)hash1["nextPos"];
			}
				
		}

		if (message == GameMessage.DESTROY_PIECE && (int)data == pos_id)
		{
			GameObject.Destroy(gameObject);
		}


		}
}
