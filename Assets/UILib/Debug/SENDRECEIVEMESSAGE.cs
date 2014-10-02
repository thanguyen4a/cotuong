using UnityEngine;
//using System.Collections;
using System.Collections.Generic;
using System.Text;

[ExecuteInEditMode ()]
public class SENDRECEIVEMESSAGE : MonoBehaviour {

	private static bool is_debug = true;
	private static List<MessageSFS> message_list = new List<MessageSFS>(); 
	private static MessageSFS current_message = new MessageSFS(1, "Empty", "Empty");
	private static int position = 0;
	public Vector2 scrollPosition = Vector2.zero;

	// Use this for initialization
	void Start () {
		useGUILayout = false;
	}

	public static bool isDebug(){
		return is_debug;
	}

	public static void changeDebugState(){
		if (is_debug == true)
			is_debug = false;
		else 
			is_debug = true;
	}

	public static void addMessage(MessageSFS  message){
		message_list.Add (message);
		current_message = message;
		position = message_list.Count;
	}

	// Use this for initialization
	public void OnGUI () {
		if (SENDRECEIVEMESSAGE.isDebug ()) {
			StringBuilder text = new StringBuilder ();
			/*foreach(MessageSFS temp in SENDRECEIVEMESSAGE.message_list ){
				if(temp.getMessgeType() == 0){
					text.Append("SEND>>>>>>>>>\n");
					text.Append("Message: " + temp.getMessage());
					text.Append("\n");
					text.Append("Content: " + temp.getContent());
					text.Append("\n");
				}else if(temp.getMessgeType() == 1){
					text.Append("RECEIVE<<<<<<<<\n");
					text.Append("Message: " + temp.getMessage());
					text.Append("\n");
					text.Append("Content: " + temp.getContent());
					text.Append("\n");
				}
			}*/
			if (current_message.getMessgeType () == 0) {
				text.Append ("SEND>>>>>>>>>\n");
				text.Append ("Message: " + current_message.getMessage ());
				text.Append ("\n");
				text.Append ("Content: " + current_message.getContent ());
				text.Append ("\n");
			} else if (current_message.getMessgeType () == 1) {
				text.Append ("RECEIVE<<<<<<<<\n");
				text.Append ("Message: " + current_message.getMessage ());
				text.Append ("\n");
				text.Append ("Content: " + current_message.getContent ());
				text.Append ("\n");
			}
			GUI.Box (new Rect (Screen.width - 315, 35, 300, Screen.height - 30), "");
			GUI.Label (new Rect (Screen.width - 315, 35, 300, Screen.height - 30), text.ToString ());
			if (GUI.Button (new Rect (Screen.width - 315 + 300/2, 35 + Screen.height - 60, 300/2, 30), "Next")) {
				if (position < message_list.Count)
					position++;
				current_message = this.searchMessage(position);

			}

			if (GUI.Button (new Rect (Screen.width - 315, 35 + Screen.height - 60, 300/2, 30), "Previous")) {
				if (position > 1)
					position--;
				current_message = this.searchMessage(position);
			}

		}
	}

	public MessageSFS searchMessage(int position)
	{
		int i = 1;
		foreach (MessageSFS temp in SENDRECEIVEMESSAGE.message_list) {
			if(i == position){
				return temp;
			}
			i++;
		}
		return new MessageSFS(0, "Message Not found", "Message Not found");
	}
}
