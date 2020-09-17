using UnityEngine;
using UnityEngine.UI;

public class HideShow : MonoBehaviour {

    public Vector2 offset;

    Vector2 p1, p2;
    RectTransform rt;

    public bool Hiden = false;
	// Use this for initialization
	void Start () {
        rt = GetComponent<RectTransform>();
        p1 = rt.anchoredPosition;
        p2 = rt.anchoredPosition + offset;
	}

    public void Switch()
    {
        Hiden = !Hiden;
    }
	
	// Update is called once per frame
	void Update () {
        if (Hiden)
            rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, p2, Time.deltaTime * 8f);
        else
            rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, p1, Time.deltaTime * 8f);
	}
}
