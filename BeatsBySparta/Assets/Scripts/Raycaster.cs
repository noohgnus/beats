using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour {

	public GameObject leftHand;
	public GameObject rightHand;
    public GameObject catcherCube;
    public GameObject box;
    //public GameObject roleModel;

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public float factor = 1.0f;

    public float widthMultiplier;
    private Vector3[] positionArray = new Vector3[2];


    void Start()
    {
        /*
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.widthMultiplier = widthMultiplier;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineRenderer.colorGradient = gradient;
        */

        //set cube to follow hands
        //catcherCube = this.gameObject.AddComponent<BoxCollider>();
    }

    void Update()
    {
        
        //LineRenderer lineRenderer = GetComponent<LineRenderer>();


        positionArray[0] = leftHand.transform.position;
        positionArray[1] = rightHand.transform.position;
        /*
        lineRenderer.widthMultiplier = widthMultiplier;
        lineRenderer.SetPositions(positionArray);
        */

        //reshaping the cube
        //roleModel.transform.position = ((positionArray[0] + positionArray[1]) / 2) + new Vector3(0f, 0f, 3f);
        //roleModel.transform.position = new Vector3(-1 * (positionArray[0].z - positionArray[1].z), (positionArray[0].y + positionArray[1].y) / 2, positionArray[0].x - positionArray[1].x) * 2;
        


        //catcherCube.transform.position = (positionArray[0] + positionArray[1]) / 2;
        /*
        box.transform.position = (positionArray[0] + positionArray[1]) / 2;
        Quaternion rot = Quaternion.LookRotation(positionArray[1], positionArray[0]);
        Quaternion roto = new Quaternion(
            (leftHand.transform.rotation.x + rightHand.transform.rotation.x) / 2,
            (leftHand.transform.rotation.y + rightHand.transform.rotation.y) / 2,
            (leftHand.transform.rotation.z + rightHand.transform.rotation.z) / 2,
            (leftHand.transform.rotation.w + rightHand.transform.rotation.w) / 2
            );
        box.transform.LookAt(roleModel.transform);
        */
        SetLinePosition(catcherCube, positionArray[0], positionArray[1]);
        SetLinePosition(box, positionArray[0], positionArray[1]);
        Scale(box, positionArray[0], positionArray[1]);


    }

    void SetFacePosition(GameObject obj, Vector3 start, Vector3 end)
    {
        var dir = end - start;
        var mid = (dir) / 2.0f + start;
        obj.transform.position = mid;
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, dir);
        rot.y = 90f;
        obj.transform.rotation = rot;
    }

    void SetLinePosition(GameObject obj, Vector3 start, Vector3 end)
    {
        var dir = end - start;
        var mid = (dir) / 2.0f + start;
        obj.transform.position = mid;        
        obj.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
    }

    void Scale(GameObject obj, Vector3 start, Vector3 end)
    {
        var dir = end - start;
        Vector3 scale = obj.transform.localScale;
        scale.y = dir.magnitude * factor;
        obj.transform.localScale = scale;

    }

}
