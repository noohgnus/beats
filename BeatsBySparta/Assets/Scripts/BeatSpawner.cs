using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour {

	public GameObject anchorSphere;
	public GameObject sphereBeatPrefab;
	public float spawnInterval;
	public int spawnCount;

	private float previousFrameTime;
	private Vector3 anchorPosition;
	private int counter;

	// Use this for initialization
	void Start () {
		previousFrameTime = Mathf.Floor(Time.time);
		anchorPosition = anchorSphere.transform.position;
		counter = 1;
		InvokeRepeating ("SpawnSphere", 3f, spawnInterval);
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (counter < spawnCount && previousFrameTime != Mathf.Floor (Time.time)) {
			Instantiate (sphereBeatPrefab, anchorPosition + new Vector3(counter++, 0, 0), Quaternion.identity);
		}
		*/
	}

	void SpawnSphere(){
		Instantiate (sphereBeatPrefab, 
			anchorPosition + new Vector3(Random.Range(-0.5f,0.5f), Random.Range(-0.5f,0.5f), 0), 
			Quaternion.identity);
	}

}
