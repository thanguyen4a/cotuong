using UnityEngine;
using System.Collections;

public class PieceController : ObservableMonoBehaviour {

    public AudioSource audio_source;
    public AudioClip[] audioClips;

	public int pos_id;	
	public int piece_id;
	public int color_id;
	public void setPosID(int pos_id)
	{
		this.pos_id = pos_id;
	}

	public void setInfo(int pos_id,int piece_id,int color_id)
	{
		this.pos_id = pos_id;
		this.piece_id = piece_id;
		this.color_id = color_id;
	}

	// Use this for initialization
	void Start () {
		base.OnStart ();
        audio_source = gameObject.GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private int getAudioIdOfPiece(int piece_id)
	{
        switch (piece_id)
		{
		case 7: return PieceAudioMapping.KING_EAT;
		case 6: return PieceAudioMapping.ROOK_EAT;
		case 5: return PieceAudioMapping.CATAPULT_EAT;
		case 4: return PieceAudioMapping.CAVARLY_EAT;
		case 3: return PieceAudioMapping.ELEPHANT_EAT;
		case 2: return PieceAudioMapping.GUARD_EAT;
		case 1: return PieceAudioMapping.SOLDIER_EAT;
		}
		return -1;
	}

    public void setAudioClip(int clip_id, float round_time, float delay_time)
    {
        if (audio_source.isPlaying)
            audio_source.Stop();
        audio_source.clip = audioClips[clip_id];
        if (round_time > 0f)
        {
            audio_source.SetScheduledEndTime(delay_time + round_time);
        }
        audio_source.PlayDelayed(delay_time);
    }


	public override void updateMessage(string message,object data, ObservableObject sender){

		if (message == GameMessage.SELECT_PIECE) 
		{
			if((int)data == pos_id)
			{
				SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
				render.material.color = UnityEngine.Color.red; 
				this.setAudioClip (PieceAudioMapping.HOVER,0f,0f);
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
				//cap nhat toa do thuc te ci tri can toi
				Hashtable hash2 = Constant.MappingPosToRealXY((int)hash1["nextPos"]);
				Vector3 position = new Vector3();
				position = transform.position;

				//cap nhat vij tri tren ban co
				position.x = (float)hash2["X"];
				position.y = (float)hash2["Y"];
				transform.position = position;
				//cap nhat pos_id
				pos_id = (int)hash1["nextPos"];


				if((bool)hash1["eat"] == true)
				{
					this.setAudioClip(getAudioIdOfPiece(this.piece_id),0f,0f);
				}
				else
				{
					this.setAudioClip(PieceAudioMapping.MOVE_FINISH,0f,0f);
				}
			}


				
		}

		if (message == GameMessage.DESTROY_PIECE && (int)data == pos_id)
		{
			GameObject.Destroy(gameObject);
		}


		}
}
