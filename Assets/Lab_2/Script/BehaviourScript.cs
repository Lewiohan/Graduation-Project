using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine;

public class BehaviourScript : MonoBehaviour {

    public static GameObject model;
    private Transform cylinder;
    private Transform water;

    public static float ballSpeed = 50;
    // Use this for initialization
    void Start () {
        model = this.gameObject;

        Color tempcolor = gameObject.GetComponent<Renderer>().material.color;
   
        tempcolor.r = 0.1f;
        tempcolor.g = 1f;
        tempcolor.b = 1f;
        tempcolor.a = .4f;
        gameObject.GetComponent<Renderer>().material.color = tempcolor;

        
    }
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("ToggleWater").GetComponentInChildren<Toggle>().isOn)
        {
            Color tempcolor = gameObject.GetComponent<Renderer>().material.color;
            tempcolor.r = .0f;
            tempcolor.g = .0f;
            tempcolor.b = .8f;
            tempcolor.a = .4f;
            gameObject.GetComponent<Renderer>().material.color = tempcolor;
        }
        if (GameObject.Find("ToggleKerosin").GetComponentInChildren<Toggle>().isOn)
        {
            Color tempcolor = gameObject.GetComponent<Renderer>().material.color;
            tempcolor.r = .0f;
            tempcolor.g = .0f;
            tempcolor.b = .0f;
            tempcolor.a = .2f;
            gameObject.GetComponent<Renderer>().material.color = tempcolor;
        }
        if (GameObject.Find("ToggleGlycerin").GetComponentInChildren<Toggle>().isOn)
        {
            Color tempcolor = gameObject.GetComponent<Renderer>().material.color;
            tempcolor.r = .8f;
            tempcolor.g = .8f;
            tempcolor.b = .0f;
            tempcolor.a = .5f;
            gameObject.GetComponent<Renderer>().material.color = tempcolor;
        }
              
        
    }

   
}
