using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("dddd");
        
        Destroy(other.gameObject);
    }
}
