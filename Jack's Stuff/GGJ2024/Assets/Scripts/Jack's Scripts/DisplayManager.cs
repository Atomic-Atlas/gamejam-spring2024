using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    private int _height;
    private int _width;
    public (int, int) screenSize;
    public List<GameObject> myPanels = new();
    // Start is called before the first frame update
    void Awake()
    {
        screenSize = GetScreenSize();
        int max= gameObject.transform.childCount;
        for (int i = 0; i < max; i++)
        {
            GameObject currentChild = gameObject.transform.GetChild(i).gameObject;
            if (currentChild.CompareTag("Panel"))
            {
                myPanels.Add(currentChild);
            }
        }

        foreach (var obj in myPanels)
        {
            SetPanelSize(screenSize, obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPanelSize((int, int) size, GameObject panel)
    {
        /* Debug.Log(gameObject.name + " Before Size: " + gameObject.GetComponent<RectTransform>().sizeDelta);
         Debug.Log(size.Item1);
         Debug.Log(size.Item2); */
        panel.GetComponent<RectTransform>().sizeDelta = new Vector2(size.Item1, size.Item2);
        //Debug.Log(gameObject.name + " After Size: " + gameObject.GetComponent<RectTransform>().sizeDelta);

    }

    public (int, int) GetScreenSize()
    {
        return (Screen.currentResolution.width, Screen.currentResolution.height);
    }
}
