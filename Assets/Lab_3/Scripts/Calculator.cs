using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Calculator : MonoBehaviour {
    public Transform[] weights; // переменная трансформирования грузов
    public float Radius, RadiusWhell; // радиусы креста и радиусы грузов
    

    public Transform mainWeight; // главный груз
    LineRenderer WeightRope;// нить

    public float[] Gramms;// переменная веса
    public float Mass; 

    public Transform[] points;//точки грузов
    public Transform point;// точка главного груза

    public Transform Whell;// крест

    public Text R_Text; //текст радиуса

    public Slider slider; //слайдер
    public Dropdown d1, d2; // дропдауны
    public float inerc;

    Timer timer;
    // Use this for initialization
    void Start () {
       
        WeightRope = mainWeight.GetComponent<LineRenderer>(); // получение главной нити

        ChangeWeights(10f);//изменение грузов
        ChangeMass(0); //изменение массы
        ChangePoint(0); // изменение точек

        timer = new Timer();
    }
	
    public void ChangeWeights(float Dst) //изменение грузов
    {
        Radius = Dst / 100f; // получение радиуса
       inerc = 4 * 20 * Radius * Radius;
     
        R_Text.text = "Момент инерции: " + inerc.ToString() + "\n" + "R = " + (int)Dst + " см"; //вывод радиуса
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i].localPosition = new Vector3(0f, Radius, 0f); //создание вектора перемещения грузов
        }
    }

    public void ChangeMass(int num) // изменение массы главного груза
    {
        Mass = Gramms[num];
    }

    public void ChangePoint(int num) //изменение точки
    {
        point = points[num];
        RadiusWhell = num == 0 ? 0.05f : 0.1f;

        Vector3 pos = point.position; // вектор позиции
        pos.y = 2.3f;
        mainWeight.position = pos; // позиция главного груза
    }

    public void StartSim() // запуск вращения креста
    {
        Reset();
        rotating = true;
    }

    public void Reset() //остановка креста
    {
        timer.Reset();
        rotating = false;
        Speed = 0f;

        Whell.rotation = Quaternion.identity;

        ChangeWeights(slider.value);
        ChangeMass(d1.value);
        ChangePoint(d2.value);
    }

    public float Speed = 0f;
    public bool rotating = false;
	// Update is called once per frame
	void Update () {
        WeightRope.SetPosition(0, mainWeight.position);
        WeightRope.SetPosition(1, point.position);

        if (rotating) // вращение креста
        {
            float dt2 = Time.deltaTime * Time.deltaTime * 10f;
            float Mom = (Mass * 10f - 0f) * RadiusWhell;
            float J = 0.2f + 4f * 2f * Radius * Radius;
           
            float Eps = Mom / J;
            Speed += Eps * dt2;
            mainWeight.position -= Vector3.up * Speed * RadiusWhell * Time.deltaTime;
            if (mainWeight.position.y < 1.7f)
                rotating = false;

            Whell.Rotate(Vector3.right * Speed);
        }
    }
}
