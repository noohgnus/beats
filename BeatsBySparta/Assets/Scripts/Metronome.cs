using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Metronome : MonoBehaviour {

	public AudioSource drum;

	public double bpm;
	private double bps;
	private double spb; //seconds per beat

	private double currentTime;
	private double nextBeatTime;

	void Start() {
		bps = bpm / 60.0d;
		spb = 1.0d / bps;
		currentTime = AudioSettings.dspTime;
		nextBeatTime = AudioSettings.dspTime + spb;
	}

	void FixedUpdate(){
		//Debug.Log (AudioSettings.dspTime);
		if (AudioSettings.dspTime > nextBeatTime) {
			drum.PlayOneShot(drum.clip);
			nextBeatTime = AudioSettings.dspTime + spb;
		}
	}
}