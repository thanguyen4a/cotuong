using UnityEngine;
using System.Collections;

public class InfoButtonScript : MonoBehaviour {
	public Texture2D pressed;
	public Texture2D released;
	
	// Use this for initialization
	void Start () {
		guiTexture.texture = released;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() {
		guiTexture.texture = pressed;
	}
	
	void OnMouseUp() {
		guiTexture.texture = released;
		Application.LoadLevel ("info");
	}
}