using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMover : MonoBehaviour {

    public GameObject[] notes;

	// Use this for initialization
	void Start () {
        //notes = GameObject.FindGameObjectsWithTag("note");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        notes = GameObject.FindGameObjectsWithTag("note");

        foreach (GameObject o in notes)
        {
            //Debug.Log(o.name);
            
            Vector3 v = o.transform.position;
            //o.transform.localScale *= .3f;
            v.z -= 0.1f;
            o.transform.position = v;
        }
	}
}
