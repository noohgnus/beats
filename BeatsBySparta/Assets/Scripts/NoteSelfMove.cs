using UnityEngine;
using System.Collections;

public class NoteSelfMove : MonoBehaviour
{
    public float distancePerSecond = 2f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 v = this.transform.localPosition;
        v.z += 0.05f;
        this.transform.localPosition = v;
        */
        this.transform.Translate(0, 0, distancePerSecond * Time.deltaTime);
    }
}
