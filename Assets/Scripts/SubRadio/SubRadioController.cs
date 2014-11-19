using UnityEngine;
using System.Collections;

public class SubRadioController : ObservableMonoBehaviour {


	public AudioSource audio_source;
	public AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
    base.OnStart ();
	audio_source = gameObject.GetComponent<AudioSource>();
	}

	private void setAudioClip(int clip_id , float round_time , float delay_time , bool isLoop)
	{
		if(audio_source.isPlaying)
			audio_source.Stop();
		audio_source.clip = audioClips[clip_id];
		if(round_time > 0f)
		{
			audio_source.SetScheduledEndTime(delay_time + round_time );
		}
		audio_source.PlayDelayed(delay_time);
		audio_source.loop = isLoop;
	}
	// Update is called once per frame
	void Update () {
	
	}

	public override void updateMessage(string message,object data, ObservableObject sender){
		if (message == GameMessage.VUA_DARK_CAPTURE || message == GameMessage.VUA_WHITE_CAPTURE) {
			setAudioClip(SubRadioAudioMapping.K_CAPTURE,0f,0f,false);		
		}
	}
}
