using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour {
    public GameObject panelSetting;
    public GameObject panelLeft;
    public GameObject panelRicht;

    public Button setting;
    public Button yes;
    public Button no;
    public bool controll;

    private AsyncOperation Async;
	// Use this for initialization
	void Start () {
        Async = Application.LoadLevelAsync(0);
        Async.allowSceneActivation = false;
        panelSetting.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        yes.onClick.AddListener(OnYes);
        no.onClick.AddListener(OnNO);
        setting.onClick.AddListener(OnSetting);

        //
    }
    void OnNO()
    {
        panelSetting.SetActive(false);
        panelLeft.SetActive(true);
        if (panelRicht != null)
            panelRicht.SetActive(true);
    }
    void OnYes()
    {
        //Application.LoadLevel(6);
        Async.allowSceneActivation = true;
    }

    public void OnSetting()
    {
        panelLeft.SetActive(false);
        if (panelRicht != null)
            panelRicht.SetActive(false);
        panelSetting.SetActive(true);
    }
}
