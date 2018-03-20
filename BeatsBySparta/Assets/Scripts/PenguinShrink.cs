using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinShrink : MonoBehaviour {

	public float shrinkSpeed;
	public float alphaDecreaseRate;
	public GameObject shell;
	public GameObject hitText;
	public GameObject fx;
	private float touchedTime;
	private bool shrinkFlag;


	// Use this for initialization
	void Start () {
		touchedTime = -1.0f;
		shrinkFlag = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (shrinkFlag) {
			shell.transform.localScale *= shrinkSpeed;
            this.gameObject.transform.position -= new Vector3(0f, 0f, 0.05f);
		}
    
		if (shell.transform.localScale.x < 0.1f) {
			Debug.Log ("MISS");
			shell.gameObject.GetComponent<Renderer> ().enabled = false;
			hitText.gameObject.GetComponent<TextMesh> ().text = "MISS";
			hitText.gameObject.GetComponent<Renderer> ().enabled = true;
			//Destroy (this.gameObject);
			Invoke("MissDestroy", 1f);
		}


		if (touchedTime > 0f && Time.time > touchedTime + 1) {
			Debug.Log ("Decayed");
			Debug.Log (touchedTime + "/" + Time.time);
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
        Debug.Log("hit");
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
