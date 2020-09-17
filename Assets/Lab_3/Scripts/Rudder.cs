using UnityEngine;
using System.Collections;

public class Rudder : MonoBehaviour {
    public int Count;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < Count; i++)
        {
            Transform obj = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
            obj.parent = transform;
            obj.localPosition = new Vector3(i % 10 == 0 ? 2f : 1f, i, 0f);
            obj.localRotation = Quaternion.identity;
            obj.localScale = new Vector3(i % 10 == 0 ? 4f : 2f, 0.5f, 0.1f);
        }
	}
}