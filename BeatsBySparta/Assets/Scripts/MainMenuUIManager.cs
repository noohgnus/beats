using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;
using Valve.VR;

public class MainMenuUIManager : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayGame()
    {
        Debug.Log("Pressed");
        /*
        VRTK_SDKManager.instance.UnloadSDKSetup();
        SceneManager.LoadScene("Play");
        */
        SteamVR_LoadLevel.Begin("Play");
        
    }
}
