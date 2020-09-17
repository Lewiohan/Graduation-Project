using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ri : MonoBehaviour {

    // Use this for initialization
    private float drag = 10;
    private float ballScale;
    private float dropTime;
    private float visconsity;
    private float kalibration = 0;
    private bool isCameraFixed = false;
    
	void Start () {
        //добавление обработчиков взаимодействия с панелью
        GameObject.Find("ButtonStart").GetComponentInChildren<Button>().onClick.AddListener(onClickStart);
        GameObject.Find("ButtonRestart").GetComponentInChildren<Button>().onClick.AddListener(onClickRestart); 
        GameObject.Find("ButtonCameraFix").GetComponentInChildren<Button>().onClick.AddListener(onButtonCameraFix);
        GameObject.Find("SliderR").GetComponentInChildren<Slider>().onValueChanged.AddListener(radiusChange);
        GameObject.Find("SliderDensity").GetComponentInChildren<Slider>().onValueChanged.AddListener(densityChange);
        
        gameObject.GetComponent<Rigidbody>().isKinematic = true; //задание физических свойств сфере
        //делаем кнопку отображающую панель невидимой
        Color textColor = GameObject.Find("ButtonShow").GetComponentInChildren<Button>().GetComponentInChildren<Text>().color;
        textColor.a = 0;
       GameObject.Find("ButtonShow").GetComponentInChildren<Button>().GetComponentInChildren<Text>().color = textColor;
        GameObject.Find("ButtonShow").GetComponentInChildren<Button>().GetComponent<Image>().color = new Color(.0f, .0f, .0f, .0f);

     
    }
	
	// Update is called once per frame
	void Update () {
	  
            if (gameObject.GetComponent<Transform>().position.y <= 5.561f)
                gameObject.GetComponent<Rigidbody>().isKinematic = true;

            //в зависимости от типа жидкости будет изменяться скорость движения сферы в ней
        if (GameObject.Find("ToggleWater").GetComponentInChildren<Toggle>().isOn)
        {
            drag = 5;
        }
        if (GameObject.Find("ToggleGlycerin").GetComponentInChildren<Toggle>().isOn)
        {
            drag = 6;
        }
        if (GameObject.Find("ToggleKerosin").GetComponentInChildren<Toggle>().isOn)
        {
            drag = 7;
        }
        //при движениии шарика в воздухе он движется с определенной скоростью
        if (gameObject.GetComponent<Transform>().position.y > 10.0f)
        {
            drag -= 5;
            gameObject.GetComponent<Rigidbody>().drag = drag;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().drag = drag + (kalibration+=0.0001f);
        }
       

        if (gameObject.GetComponent<Transform>().position.y <= 10.981 && gameObject.GetComponent<Transform>().position.y >= 9.800)  
        {
            gameObject.GetComponent<AudioSource>().Play(); //запуск звука соприкосновения сферы с водой 
        }  
    }

    public void onClickRestart() //возвращение в исходную позицию
    {
        Vector3 pos = transform.position;
        pos.y = 11;
        gameObject.GetComponent<Transform>().transform.position = pos;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        kalibration = 0;
    }
    public void onClickStart()//запуск движения сферы
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //считывание параметров движения и вычисление коэффициента  вязкости
        float radius =GameObject.Find("SliderR").GetComponentInChildren<Slider>().value;
        float ballDensity = GameObject.Find("SliderDensity").GetComponentInChildren<Slider>().value * 1.5f;
        float waterVisconcity = (drag / 15);
        dropTime = (radius - ballDensity - waterVisconcity)+3;
        dropTime += (float)new System.Random().NextDouble();

        visconsity =(float)(((System.Math.Pow(radius, 2)/10)) * 9.8f * ((ballDensity - waterVisconcity/100)/1000)*2.15f/1.8f)*1000;
        visconsity +=(float) new System.Random().NextDouble();
        //вывод результатов на панель
        GameObject.Find("TextTime").GetComponentInChildren<Text>().text = dropTime.ToString();
        GameObject.Find("TextVisconsity").GetComponentInChildren<Text>().text = visconsity.ToString();
    }
    public void onButtonCameraFix()//закрепить камеру
    {
        GameObject.Find("Main Camera").GetComponentInChildren<Camera>().GetComponent<rotateonmouse>().enabled = !GameObject.Find("Main Camera").GetComponentInChildren<Camera>().GetComponent<rotateonmouse>().enabled;
        if (!isCameraFixed)
        {
            GameObject.Find("ButtonCameraFix").GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "Открепить камеру";            
        }
        else
        {
            GameObject.Find("ButtonCameraFix").GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "Закрепить камеру";
        }
        isCameraFixed = !isCameraFixed;
    }

    public void radiusChange(float value)//управление камеры
    {
        Vector3 size = gameObject.GetComponent<Transform>().localScale;
        size.x = value;
        size.y = value;
        size.z = value;
        gameObject.GetComponent<Transform>().localScale = size;    
    }
    public void densityChange(float value)// изменение значения плотности жидкости
    {
        Color tempcolor = gameObject.GetComponent<Renderer>().material.color;
        tempcolor.a = value;     
        gameObject.GetComponent<Renderer>().material.color = tempcolor;
    }
}
