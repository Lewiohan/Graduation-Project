using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel_Scrips : MonoBehaviour {

    private float x;
    private float y;

    private int tenper;

    public Button open;
    public Button close;

    public Slider slider;
    private int t_iz;

    public Camera camera1;
    public Camera camera2;

    public Button cameraLine;
    public Button cameraObject;


    Random rnd = new Random();
    // Use this for initialization
    void Start () {
        x = this.gameObject.transform.position.x;
        y = this.gameObject.transform.position.y;

        tenper = (int) Random.Range(20, 26);
        slider.value = (float)tenper;

        camera1.enabled = false;
        camera2.enabled = true;
        cameraObject.enabled = true;
        cameraLine.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        cameraLine.onClick.AddListener(OnCameraLine);
        cameraObject.onClick.AddListener(OnCameraObject);
        close.onClick.AddListener(OnClose);
        open.onClick.AddListener(OnOpen);

        GameObject.Find("T_na").GetComponent<Text>().text = "" + tenper +" C";
        
        GameObject.Find("T_iz").GetComponent<Text>().text = "" + slider.value + " C";
    }
    void OnClose()
    {
        this.gameObject.transform.position = new Vector2(x, y);
    }
    void OnOpen()
    {
        this.gameObject.transform.position = new Vector2(x + 160, y);
    }
    void OnCameraLine()
    {
        camera1.enabled = false;
        camera2.enabled = true;
        cameraObject.enabled = true;
        cameraLine.enabled = false;
    }
    void OnCameraObject()
    {
        camera1.enabled = true;
        camera2.enabled = false;
        cameraObject.enabled = false;
        cameraLine.enabled = true;
    }
}
