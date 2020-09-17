using UnityEngine;
using UnityEngine;
using System.Collections;

//[AddComponentMenu("Camera-Control/Mouse drag Orbit with zoom")]
public class rotateonmouse : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float sensitivity = 3; // чувствительность мышки
    public float limit = 30; // ограничение вращения по Y
    public float zoom = 1.9f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 15; // макс. увеличение
    public float zoomMin = 4; // мин. увеличение
    private float X, Y;

    void Start()//задание начальных значение камеры
    {
        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
        transform.position = target.position + offset;
    }

    void Update()
    {
        //изменение положения камеры при вращении колеса или движения 
        if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom; //колесо мыши
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;//колесо мыши
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

        if (Input.GetMouseButton(0))
        {
            X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            Y += Input.GetAxis("Mouse Y") * sensitivity;
            Y = Mathf.Clamp(Y, -limit, limit);
         
        }
        transform.localEulerAngles = new Vector3(-Y, X, 0);
        transform.position = transform.localRotation * offset + target.position;
    }
}