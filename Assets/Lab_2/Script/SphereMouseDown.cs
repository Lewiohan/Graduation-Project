using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SphereMouseDown : MonoBehaviour, IPointerClickHandler {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("SliderDensity").GetComponentInChildren<Slider>().value == 0.7f)
        {
            MakeSphereTtransparent();
        }
        else
        {
            MakeSphereVisible();
        }
	    
	}
    public void OnPointerClick(PointerEventData p)
    {
        MakeSphereTtransparent();
    } 
    public void MakeSphereTtransparent()
    {
        var color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 0;
        gameObject.GetComponent<Renderer>().material.color = color;
    }
    public void MakeSphereVisible()
    {
        var color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 1;
        gameObject.GetComponent<Renderer>().material.color = color;
    }
}
