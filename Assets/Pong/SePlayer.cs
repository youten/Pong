using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// http://marupeke296.com/UNI_SND_No3_SoundPlayer.html
public class SePlayer {
	GameObject sePlayerObj;
	AudioSource audioSource;
	Dictionary<string, AudioClipInfo> audioClips = new Dictionary<string, AudioClipInfo>();
	
	// AudioClip information
	class AudioClipInfo {
		public string resourceName;
		public string name;
		public AudioClip clip;
		
		public AudioClipInfo (string resourceName, string name) {
			this.resourceName = resourceName;
			this.name = name;
		}
	}
	public SePlayer() {
		audioClips.Add( "op", new AudioClipInfo( "Pong/se-op", "op" ) );
		audioClips.Add( "mi", new AudioClipInfo( "Pong/se-mi", "mi" ) );
	}
	
	public bool play(string seName) {
		if (audioClips.ContainsKey (seName) == false) {
			return false; // not register
		}
		
		AudioClipInfo info = audioClips[seName];
		
		// Load
		if (info.clip == null) {
			info.clip = (AudioClip)Resources.Load (info.resourceName);
		}
		
		if (sePlayerObj == null) {
			sePlayerObj = new GameObject( "SePlayer" ); 
			audioSource = sePlayerObj.AddComponent<AudioSource>();
		}
		
		// Play SE
		audioSource.PlayOneShot( info.clip );
		
		return true;
	}
}
