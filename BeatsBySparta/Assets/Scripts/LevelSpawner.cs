using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelSpawner : MonoBehaviour {

    public struct SpawnInfo
    {
        public char type;
        public float x;
        public float y;
        public float z;

        public SpawnInfo(char type, float x, float y, float z)
        {
            this.type = type;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Convenience constructor for empty '0' beat? idontthink its needed.
        public SpawnInfo(int emptyFlag)
        {
            this.type = '0';
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        override
        public string ToString()
        {
            return this.type + "(" + this.x + "," + this.y + "," + this.z + ")";

        }
    }

    public GameObject shortLeft;
    public GameObject shortCenter;
    public GameObject shortRight;

    public GameObject longLeftBegin;
    public GameObject longLeftSustain;
    public GameObject longLeftEnd;

    public GameObject longCenterBegin;
    public GameObject longCenterSustain;
    public GameObject longCenterEnd;

    public GameObject longRightBegin;
    public GameObject longRightSustain;
    public GameObject longRightEnd;

    SongTxtLoader loader;

    string text;
    float bpm = 120f;
    float timeSignature = 4;

    private void Awake()
    {
        loader = new SongTxtLoader("bpmtest.txt");
        loader.ParseBeats();
        
    }
    // Use this for initialization
    void Start () {
        //text = System.IO.File.ReadAllText (Application.dataPath + "\\Levels\\bpmtest.txt");
        foreach (SpawnInfo i in loader.GetSpawnList())
        {
            GameObject g;
            switch (i.type)
            {
                case 'a': g = Instantiate(shortLeft, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                case 'b': g = Instantiate(shortCenter, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                case 'c': g = Instantiate(shortRight, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                case 'd': g = Instantiate(longLeftBegin, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                case 'e': g = Instantiate(longLeftSustain, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                case 'f': g = Instantiate(longLeftEnd, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                case 'g': g = Instantiate(longCenterBegin, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                case 'h': g = Instantiate(longCenterSustain, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                case 'i': g = Instantiate(longCenterEnd, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                case 'j': g = Instantiate(longRightBegin, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                case 'k': g = Instantiate(longRightSustain, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                case 'l': g = Instantiate(longRightEnd, new Vector3(i.x, i.y, i.z), Quaternion.identity); break;
                default: g = null;  break;


            }
            g.transform.parent = GameObject.Find("HeadSetReference").transform;

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
    
    public class SongTxtLoader
    {
        private StreamReader sr;
        public string title;
        public string artist;
        public float bpm;
        public int timeSignatureTop;
        public int timeSignatureBottom;
        public string[] beatInfo;
        public List<SpawnInfo> spawnList = new List<SpawnInfo>();

        public SongTxtLoader(string fileName)
        {
            Debug.Log("constructor here");
            //System.IO.StreamReader sr = System.IO.File.OpenText(Application.dataPath + "\\Levels\\bpmtest.txt");
            sr = System.IO.File.OpenText(Application.dataPath + "\\Levels\\" + fileName);
        }

        public bool ParseInfoLine(string s)
        {
            bool isValidText = true;
            string[] lineTokens;

            try
            {
                lineTokens = s.Substring(1).Split('=');
                //Debug.Log(s + "%%%%" + lineTokens[0] + "=" + lineTokens[1]);
                switch (lineTokens[0].ToLower())
                {
                    case "bpm":
                        bpm = float.Parse(lineTokens[1]);
                        break;
                    case "title":
                        title = lineTokens[1];
                        break;
                    case "artist":
                        artist = lineTokens[1];
                        break;
                    case "timesignature":
                        string[] timeSig = lineTokens[1].Split('/');
                        timeSignatureTop = int.Parse(timeSig[0]);
                        timeSignatureBottom = int.Parse(timeSig[1]);
                        break;
                    default:
                        Debug.Log("Invalid song prefix found.");
                        isValidText = false;
                        throw new Exception("Invalid song prefix");
                }
            }
            catch (Exception e)
            {
                isValidText = false;
                Debug.Log(e);
            }

            return isValidText;
        }

        public bool ParseBeats()
        {
            bool isValidText = true;
            string s;
            string[] beatTokens;
            int beatCount = 0;
            float zMultiplier = 1f;

            try
            {
                //while ((s = sr.ReadLine()) != null && s[0] == '#')
                //{ /* bypassing song prefix, moving SteamReader cursor to beats */ }

                //Loop parsing a whole line, which signifies one bar
                while ((s = sr.ReadLine()) != null)
                {
                    //if the line is an info line starting with '#', parse info
                    if (s[0] == '#')
                    {
                        ParseInfoLine(s);
                    }
                    else
                    {
                        beatTokens = s.Split('/');
                        //Loop parsing a beat inside a bar. One beat might contain multiple notes
                        foreach (string str in beatTokens)
                        {
                            Debug.Log(str);
                            //If empty beat, don't spawn anything in its beat
                            if (str[0] != '0')
                            {
                                string[] noteArray = str.Split('*');

                                //Loop parsing a note inside a beat.
                                foreach (string note in noteArray)
                                {
                                    SpawnInfo spawnNote;
                                    //Debug.Log("note*" + note + "*");
                                    char[] delimiters = { '(', ',', ')' };
                                    string[] noteTokens = note.Split(delimiters);
                                    spawnNote = new SpawnInfo(
                                        noteTokens[0][0], float.Parse(noteTokens[1]),
                                        float.Parse(noteTokens[2]), zMultiplier * beatCount);
                                    spawnList.Add(spawnNote);
                                    //Debug.Log(spawnNote);
                                }
                            }
                            beatCount++;
                        }
                        //throw new Exception("Invalid song prefix");
                    }
                }
            }
            catch (Exception e)
            {
                isValidText = false;
                Debug.Log(e);
            }

            foreach(SpawnInfo i in spawnList)
            {
                Debug.Log(i);
            }

            return isValidText;
        }

        public List<SpawnInfo> GetSpawnList()
        {
            return spawnList;
        }
    }
}
