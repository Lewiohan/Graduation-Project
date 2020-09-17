using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Ball2 : MonoBehaviour {
    private GameObject Gruz;
    private PhisicGruz Phisic;
    private GameObject Gruz2;
    private bool Move;
    public Text textL;

    public bool controll = false;
 
    // Use this for initialization
    void Start () {
        Gruz = this.gameObject;
        Phisic = new PhisicGruz(Gruz,Math3D.MassGruz1);
        Move = false;
        Phisic.SetMagnite(true);   
	}
    public GameObject gruz_reset;
    public void OnReset()
    {
        Phisic.Restart();
        Move = false;
        Phisic.SetMagnite(true);
        Gruz.transform.rotation = gruz_reset.transform.rotation;
        Gruz.transform.position = gruz_reset.transform.position;
    }
    // Update is called once per frame
    void Update ()
    {
        Gruz.transform.Rotate(Phisic.NewCoord());
        Math3D.Speed1 = Phisic.NewCoord();
        
        if (Move)
        {
            Phisic.PayOnForce();
        }  
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Grus2")
        {    
            Phisic.SetSpeed(Math3D.Speed2,Math3D.MassGrus2,false);
            textL.text += Convert.ToString(Math.Round(Phisic.AngleFi(), 2)) + '\n';
            Move = true;
            Phisic.SetMagnite(false);
            Phisic.HitTest();
        }       
    }   
}
