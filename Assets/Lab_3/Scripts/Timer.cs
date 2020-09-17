using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Transform weight; // груз
    public Transform StartCur, StopCur; // позиции
    public float Tim; // таймер

    public float H_Start, H_Stop; // высоты остановки
    public Slider Start_slider, Stop_slider; // начальные и конечные значения слайдера

    public Text MaxText, MinText, TimeText; // выводные поля значениц

	// Use this for initialization
	void Start () {
        // определение начальных и конечных значений слайдера
        Start_slider.value = Start_slider.maxValue; 
        Stop_slider.value = Stop_slider.minValue;
	}
    // сброс таймера
    public void Reset()
    {
        Tim = 0f;
    }
    //стартовая высота
    public void SetStart(float h)
    {
        H_Start = h;
        Stop_slider.maxValue = h;

        Vector3 pos = StartCur.position; // вектор текущей позиции
        pos.y = h;
        StartCur.position = pos;

        MaxText.text = "Высота старта: " + (int)((h - 1.6f) * 100f) + " см";
    }
   // конечная высота
    public void SetStop(float h)
    {
        H_Stop = h;
        Vector3 pos = StopCur.position;// вектор текущей позиции
        pos.y = h;
        StopCur.position = pos;

        MinText.text = "Высота остановки: " + (int)((h - 1.6f) * 100f) + " см";
    }
	
	// Update is called once per frame
	void Update () {
        //изменение позиции груза от старта до конца
        if (weight.position.y < H_Start && weight.position.y > H_Stop)
            Tim += Time.deltaTime;
        TimeText.text = "Таймер: " + (int)(Tim * 100f) / 100f + " сек"; // работа таймера
	}
}
