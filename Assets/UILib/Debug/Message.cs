using UnityEngine;
using System.Collections;

public class MessageSFS {
	private int message_type; 	// if message_type == 0 send 
								//else if message_type == 1 receive
	private string message;
	private string content;

	public MessageSFS(int message_type, string message, string content){
		this.message_type = message_type;
		this.message = message;
		this.content = content;
	}

	public int getMessgeType(){
		return this.message_type;
	}

	public string getMessage(){
		return this.message;
	}

	public string getContent(){
		return this.content;
	}

}
