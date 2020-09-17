using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CamerControlor : MonoBehaviour {
    public Camera camer1;
    public Camera camer2;

    public int i = 1;
    // Use this for initialization
    void Start () {
        camer1.enabled = false;
        camer2.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.C)) {
            camer1.enabled = true;
            camer2.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            camer2.enabled = true;
            camer1.enabled = false;
        }
       
    }
   
}
