using UnityEngine;
using System.Collections;

public class changeColorOfCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Color tempcolor = gameObject.GetComponent<Renderer>().material.color;
        tempcolor.a = 0.5f;
        tempcolor.r = 0.5f;
        tempcolor.g = 0.5f;
        tempcolor.b = 0.5f;
        gameObject.GetComponent<Renderer>().material.color = tempcolor;

    }

    // Update is called once per frame
    void Update () {
     


    }
}
