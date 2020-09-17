using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform camera; // переменная трансормирования камеры
    public float MaxDst = 10f, MinDst = 1f;// ограничения на дистанцию
    float Dst = 0f; // начальная

    public float MaxRX = 30f, MinRX = -30f; // вращения ограничение
    float RX, RY;// координаты

    public GameObject rect; // окно

    float diff;
	// вычисление угла и дистанции
	void Start () {
        RY = transform.eulerAngles.y;
        diff = (MaxDst - MinDst) / 2f;
        Dst = (MaxDst + MinDst) / 2f;
	}
	
	// перемещение камеры
	void Update () {
        Dst -= Input.GetAxis("Mouse ScrollWheel") * diff;
        Dst = Mathf.Clamp(Dst, MinDst, MaxDst);
        camera.localPosition = Vector3.forward * -Dst;

        if (Input.GetButton("Fire1") && (rect == null || !AreCoordsWithinUiObject(Input.mousePosition, rect)))
        {
            RY += Input.GetAxis("Mouse X");
            RX -= Input.GetAxis("Mouse Y");
            RX = Mathf.Clamp(RX, MinRX, MaxRX);
            transform.localRotation = Quaternion.Euler(RX, RY, 0f);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
    }
    // определение булевской переменной для ограничения возможности управления камерой
    bool AreCoordsWithinUiObject(Vector2 coords, GameObject gameObj)
    {
        Vector2 localPos = gameObj.transform.InverseTransformPoint(coords);
        return ((RectTransform)gameObj.transform).rect.Contains(localPos);
    }
}
