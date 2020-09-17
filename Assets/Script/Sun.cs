using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    Light sum;
    public float rotation;
    // Update is called once per frame
    public int hour;
    public int minute;

    void Update()
    {
        minute = DateTime.Now.Minute;
        hour = DateTime.Now.Hour;
        sum = GetComponent<Light>();
        sum.transform.rotation = Quaternion.Euler(((hour % 24 * 60) + minute % 60) * 0.25f - 90, 0, 0);
    }
    
}
