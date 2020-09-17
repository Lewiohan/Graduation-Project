using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Panels_2 : MonoBehaviour {

    string z1, z2, z3, z4, z;
    public Text i1, i2, i3, i4 , i;

    private float x;
    private float y;

    public Button open;
    public Button close;
    public Button butt2;

    // Use this for initialization
    void Start () {
        x = this.gameObject.transform.position.x;
        y = this.gameObject.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        close.onClick.AddListener(OnClose);
        open.onClick.AddListener(OnOpen);
        butt2.onClick.AddListener(OnClicks);

        z1 = (i1.text); 
        z2 = (i2.text);
        z3 = (i3.text); 
        z4 = (i4.text);
        z = (i.text);
        if(i1.text == "" || i2.text == "" || i3.text == "" || i4.text == "" || i.text == "")
        {
            butt2.enabled = false;
        }
        else butt2.enabled = true;
    }
    public void OnClose()
    {
        this.gameObject.transform.position = new Vector2(x, y);
    }
    void OnOpen()
    {
        this.gameObject.transform.position = new Vector2(x - 220, y);
    }
    void OnClicks() {
        int sred = Int32.Parse(z1) + Int32.Parse(z2) + Int32.Parse(z3)+ Int32.Parse(z4);
        double sped = sred / 4;
        double razn = (Int32.Parse(z) + sped);
        if (razn < 0) {
            razn *= -1;
        }
        double koff =(0.3 * razn);
        GameObject.Find("T").GetComponent<Text>().text = "Ср зн = " + sped + " мм";
        GameObject.Find("T2").GetComponent<Text>().text = "Коэфф = " + koff + " Н/мм";
        GameObject.Find("T1").GetComponent<Text>().text = "Разность = " + razn + " мм";
    }
}
