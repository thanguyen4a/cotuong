using UnityEngine;
using System.Collections;

public class PositionController : MonoBehaviour ,UILib.SimpleButtonDelegate {

	// Use this for initialization

	public int pos_id;

	public void setPosID(int pos_id)
	{
		this.pos_id = pos_id;
	}
	void Start () {
		Debug.Log ("khoi tao");
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void onClicked(UnityEngine.GameObject gameobject)
	{
		Debug.Log ("click");
		Debug.Log (this.pos_id);
	}

	public void onClickEnd(UnityEngine.GameObject gameobject)
	{
		Debug.Log ("clickEnd");
	}
}
