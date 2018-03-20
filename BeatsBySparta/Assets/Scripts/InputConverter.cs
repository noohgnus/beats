using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Text;

public class InputConverter : MonoBehaviour {

	public float bpm;
	public List<string> sequence;
	private long i;
	string text;
	XmlReader reader;

	void Awake() {
		//text = "test";
		//text = System.IO.File.ReadAllText (Application.dataPath + "\\Levels\\level1.xml");
        /*
		reader = XmlReader.Create (new StringReader (
			System.IO.File.ReadAllText (Application.dataPath + "\\Levels\\level1.xml")
		));
		reader.MoveToContent();
        */
	}

	// Use this for initialization
	void Start () {
        
		//while (reader.Read ()) {

            /*
			if(reader.NodeType.Equals(XmlNodeType.Element)){
				if(reader.Name.Equals("beats")){
					sequence.Add (reader.Value);
				}
			}
			*/

            //Debug.Log(reader.Name + reader.Value);

			/*
			switch (reader.NodeType) {
				case XmlNodeType.Element:
					Debug.Log (reader.Name);
					break;
				case XmlNodeType.Text:
					Debug.Log (reader.Value);
					break;
			}
			*/
		//}
        
	}
	
	// Update is called once per frame
	void Update () {

	}
}
