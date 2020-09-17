using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit _hit;
            if(Physics.Raycast(ray, out _hit, Mathf.Infinity)) {
            if(_hit.transform.name == "dwer1")
            {
                    Destroy( _hit.transform.gameObject);
            }
            }
    }
	}
}
