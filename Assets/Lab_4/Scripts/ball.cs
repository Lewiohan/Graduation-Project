using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ball : MonoBehaviour {
    //Глобальные переменные
    private PhisicGruz Phisica;
    private GameObject Gruz;
    private bool Relog;
    private double time;
    private Text text;
    private GameObject canvas;
    public Text textInfo;
    public Text textTimes;
    private bool stop;//равно замедлено действие

    // Use this for initialization
    void Start () {

        Gruz = this.gameObject;
        Gruz.AddComponent<Rigidbody>();
        Gruz.GetComponent<Rigidbody>().useGravity = false;
        Gruz.GetComponent<Rigidbody>().angularDrag = 0;
        //==================================
        Relog = false; 
        Phisica = new PhisicGruz(Gruz,Math3D.MassGrus2);// Создания экземпляра класса
        time = 0;
        stop = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Движения грузика
        if(Relog)
        {
            Gruz.transform.Rotate((Phisica.NewCoord()));
            Math3D.Speed2 = Phisica.NewCoord();
        }
        if(stop)
        {
            Phisica.PayOnForce();
        }
        if (Math3D.OnTime)
            time += Time.deltaTime * 5;

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Grus1")
        {
            Math3D.OnTime = false;//Выключить таймер
            Phisica.SetSpeed(Math3D.Speed2,Math3D.MassGruz1,true);//Передача скорости
            textInfo.text += Convert.ToString(Math.Round(Phisica.AngleFi(), 2)) + '\n';
            textTimes.text += Convert.ToString(Math.Round(time + 1))+ '\n';
            Phisica.HitTest();//Удар
            stop = true;
        }
        if (collision.gameObject.name == "Datchik")
        {
            Phisica.SetMagnite(true);
        }
    }
    public void OnStart()
    {
        Relog = true;
        Phisica.SetLocation(Gruz.transform.rotation);
        Math3D.OnTime = true;
        Phisica.SetMagnite(false);
    }
    public GameObject gruz_reset;
    public void OnReset()
    {
        Relog = false;
        Math3D.OnTime = false;
        time = 0;
        Phisica.SetMagnite(true);
        stop = false;
        Phisica.Restart();
        Gruz.transform.rotation = gruz_reset.transform.rotation;
        Gruz.transform.position = gruz_reset.transform.position;
    }
}
