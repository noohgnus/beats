using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatShrink : MonoBehaviour {

    public bool enableDebugLog = true;
	public float shrinkSpeed;
	public float alphaDecreaseRate;
	public GameObject shell;
	public GameObject hitText;
	public GameObject fx;
	private float touchedTime;
	private bool shrinkFlag;
	private Color sphereColor;


	// Use this for initialization
	void Start () {
		touchedTime = -1.0f;
		shrinkFlag = true;
		sphereColor = this.gameObject.GetComponent<Renderer> ().material.color;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//if(Input.GetKey("space")){
		if (shrinkFlag) {
			shell.transform.localScale *= shrinkSpeed;
            this.gameObject.transform.position -= new Vector3(0f, 0f, 0.05f);
		} else {
			sphereColor.a -= alphaDecreaseRate;
			this.gameObject.GetComponent<Renderer> ().material.color = sphereColor;
		}
		//}


		if (shell.transform.localScale.x < 0.1f) {
			if(enableDebugLog) Debug.Log ("MISS");
			this.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			this.gameObject.GetComponent<SphereCollider> ().enabled = false;
			shell.gameObject.GetComponent<Renderer> ().enabled = false;
			hitText.gameObject.GetComponent<TextMesh> ().text = "MISS";
			hitText.gameObject.GetComponent<Renderer> ().enabled = true;
			//Destroy (this.gameObject);
			Invoke("MissDestroy", 1f);
		}


		if (touchedTime > 0f && Time.time > touchedTime + 1) {
            if (enableDebugLog) Debug.Log ("Decayed");
            if (enableDebugLog) Debug.Log (touchedTime + "/" + Time.time);
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag.Equals ("spear")) {
			shrinkFlag = false;
			fx.SetActive(true);
			touchedTime = Time.time;
			this.gameObject.GetComponent<AudioSource> ().enabled = true;
			shell.gameObject.GetComponent<Renderer>().enabled = false;
			hitText.gameObject.GetComponent<TextMesh> ().text = shell.transform.localScale.x - 1 + "";
			hitText.gameObject.GetComponent<Renderer> ().enabled = true;
		}
	}

	void MissDestroy(){
		Destroy (this.gameObject);
	}
}
