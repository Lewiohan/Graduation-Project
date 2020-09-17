using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class panel_setting : MonoBehaviour {
    public GameObject panelMenu;
    public GameObject panelLab;
    //public GameObject panelSetting;
    public GameObject canvas;

    public GameObject buttonMenu;
    public GameObject buttonLab;

    public Text nameText;
    private string[] nameLab = {
        "Изучение закона сохранения энергии",
        "Измерение коэффициента динамической вязкости жидкости методом Стокса",
        "Изучение закона сохранения энергии",
        "Изучение Упругого и неупругого ударов",
        "Изучение температурной зависимости коэффициента поверхностного натяжения воды методом Pебиндера"
    };
    public Text targetText;
    private string[] target =
    {
        "изучить закон сохранения механической энергии и освоить метод его проверки с помощью маятника Максв",
        "ознакомиться с явлениями переноса в веществе; изучить закономерности внутреннего трения; измерить коэффициент динамической вязкости глицерина методом Стокса",
        "изучить закон сохранения механической энергии и освоить метод его проверки с помощью маятника Максвелла",
        "проверить закон сохранения импульса, определить коэффициенты восстановления скорости и энергии соударяющихся тел.",
        "изучить явления, обусловленные поверхностным натяжением жидкостей; освоить метод измерения коэффициента поверхностного натяжения жидкостей и установить зависимость коэффициента поверхностного натяжения воды от температ"
    };
    private int lab = 0;

    public Camera[] labCam;
    public Camera origin;
    void Start()
    {
        CameraReset();
        origin.enabled = true;
        
        panelMenu.SetActive(true);
        //panelSetting.SetActive(false);
        panelLab.SetActive(false);

        buttonMenu.SetActive(true);
        buttonLab.SetActive(false);
    }
    
	public void ExitPanel()
    {
        Application.Quit();
    }
    public void Next()
    {
        buttonMenu.SetActive(false);
        buttonLab.SetActive(true);
        //panelSetting.SetActive(false);
    }
    public void Prev()
    {
        origin.enabled = true;
        buttonMenu.SetActive(true);
        buttonLab.SetActive(false);
        panelLab.SetActive(false);
        CameraReset();
        lab = 0;
    }
    /*public void SettingPanel()
    {
        panelMenu.SetActive(true);
        panelSetting.SetActive(true);
    }*/
    /*public void SaveSetting()
    {
        panelSetting.SetActive(false);
    }*/
    public void Lab1()
    {
        OnLevelStarting(1);
    }
    public void Lab2()
    {
        OnLevelStarting(2);
    }
    public void Lab3()
    {
        OnLevelStarting(3);
    }
    public void Lab4()
    {
        OnLevelStarting(4);
    }
    public void Lab5()
    {
        OnLevelStarting(5);
    }
    void OnLevelStarting(int index)
    {
        panelLab.SetActive(true);
        nameText.text = nameLab[index - 1];
        targetText.text = "Цель работы: " + target[index - 1];
        CameraReset(index);
        lab = index;
    }
    void CameraReset()
    {
        for (int i = 0; i < 5; i++)
            labCam[i].enabled = false;
    }
    void CameraReset(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            labCam[i].enabled = false;
            if (index - 1 == i)
                labCam[i].enabled = true ;
        }
        
    }
    public void OnStart()
    {
        if(lab != 0)
        Application.LoadLevel(lab);
    }
}
