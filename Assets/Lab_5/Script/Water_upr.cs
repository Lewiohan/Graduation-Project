using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Water_upr : MonoBehaviour {
   public bool controller = false;
    public int distance = 520;
    private int speed = 250;

    public int Min = 0;
    public int mins = 170;
    private int perem;  

    private bool pleas = false;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        controller = (bool) GameObject.Find("Toggle").GetComponent<Toggle>().isOn;
        perem = (int)GameObject.Find("Slider").GetComponent<Slider>().value;

        if (perem >= 20 && perem < 30) { Min = 200; }
        if (perem >= 30 && perem < 40) { Min = 264; }
        if (perem >= 40 && perem < 50) { Min = 328; }
        if (perem >= 50 && perem < 60) { Min = 392; }
        if (perem >= 60 && perem < 70) { Min = 456; }
        if (perem >= 70 && perem < 80) { Min = 520; }
        if (perem >= 80 && perem < 90) { Min = 584; }
        if (perem >= 90 && perem < 100) { Min = 620; }

        if (controller) {

            if (!pleas)
            {
                if (distance != 700)
                {
                    speed = 1;
                    distance++;
                    if (distance == 690) pleas = true;
                }
            }
            if (pleas && distance != Min)
            {
                speed = -1;
                distance--;
                if (distance == Min) pleas = false;
            }
            transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime / 10);
        }
    }
}
