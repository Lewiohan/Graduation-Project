using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine.UI;

public class gowork : MonoBehaviour
{
    public GameObject niz;

    public GameObject disk;
    public GameObject cyl;
    public GameObject StartPosition;

    public GameObject position1;
    public GameObject position2;

    LineRenderer WeightRope;// нить
    LineRenderer WeightRope1;// нить
    public Transform[] points;//точки грузов
    public Transform[] point;// точка главного груза

    // Use this for initialization
    private bool nizpoz = false;
    private bool run = false;
    private bool level = true;

    public int g = 20;//расстояние от верха вниз
    private int nizz = -20;

    private float firnit;
    private double speed = 0.05;

    private DateTime t1, t2;
    private int s1, s2;

    private int h0 = 0;
    //private float firstfornit = 0;

    void Start()
    {
        WeightRope = disk.transform.GetComponent<LineRenderer>(); // получение главной нити
        WeightRope1 = cyl.transform.GetComponent<LineRenderer>(); // получение главной нити
        h0 = Convert.ToInt32(disk.transform.position.y);
    }

    public Text Ttime;
    public Text Tspeed;
    public Text Tdelta;

    public Toggle one;
    public Toggle two;
    public void ToggleGroup()
    {
        if(one.isOn == true)
        {
            UnityEngine.Debug.Log("True");
        }
        else UnityEngine.Debug.Log("False");
    }

    void OnToggle()
    {
        if (one.isOn)
        {
            niz.transform.position = position1.transform.position;
        }
        if (two.isOn)
        {
            niz.transform.position = position2.transform.position;
        }

    }
    void Update()
    {
        OnToggle();

        WeightRope.SetPosition(0, point[0].transform.position);
        WeightRope.SetPosition(1, points[0].position);

        WeightRope1.SetPosition(0, point[1].transform.position);
        WeightRope1.SetPosition(1, points[1].position);

        if (run == true)
        {
            t2 = DateTime.Now;
        }

        int h = Convert.ToInt32(disk.transform.position.y);
        Ttime.text = (t2 - t1).ToString();
        Tspeed.text = (speed * 50).ToString();
        Tdelta.text = (h0 - h).ToString();
        
        /*if (Input.GetKey(KeyCode.C))
        {
            run = false;
            s1 = s1 + DateTime.Now.Second;
            s2 += DateTime.Now.Second;
        }*/
        if (run == true)
        {

            if ((disk.transform.position.y <= ((niz.transform.position.y) + 10)) && level)
            {
                level = false;
            }
            if ((!level) && (speed < 0))
            {
                level = true;
                g = g - 1;
            }
            if (g == 0)
            {
                run = false;
            }
            if (level) //подение вниз
            {
                s2 = DateTime.Now.Second;//показывает текущую дату( в секундах)
                speed = speed + (((s2 - s1) * 9.8) / 500);//новая скорость

                disk.transform.localPosition -= (disk.transform.right + new Vector3(0, 20, 0)) * (float)speed;//изменения позиции диска
            }
            if (!level) //подъем вверх
            {
                s2 = DateTime.Now.Second;
                speed = speed - (((s2 - s1) * 9.8) / 500);
                disk.transform.localPosition += (disk.transform.right + new Vector3(0, 20, 0)) * (float)speed;
            }
        }
    }
    public void OnStart()
    {
        run = true;
        t1 = DateTime.Now;
        s1 = DateTime.Now.Second;
        level = true;
        g = 10;
    }
    public void OnReset()
    {
        disk.transform.localPosition = StartPosition.transform.localPosition;

        speed = 0.000;
        s2 = 0;
        h0 = Convert.ToInt32(disk.transform.position.y);

        run = true;
        t1 = DateTime.Now;
        s1 = DateTime.Now.Second;
        level = true;
    }   
}
