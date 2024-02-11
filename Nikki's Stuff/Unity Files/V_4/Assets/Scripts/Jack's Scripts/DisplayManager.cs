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
        //get the resolution of the screen
        screenSize = GetScreenSize();
        //determine how many times we loop for 
        int max= gameObject.transform.childCount;
        //loop through all the children objects
        for (int i = 0; i < max; i++)
        {
            //get child at the current index
            GameObject currentChild = gameObject.transform.GetChild(i).gameObject;
            //check that the child is a panel (which is set in the Unity editor in the inspector)
            if (currentChild.CompareTag("Panel"))
            {
                //after confirming it's a Panel, add it to our list of panels
                myPanels.Add(currentChild);
            }
        }

        foreach (var obj in myPanels)
        {
            //set the dimensions of all the panels to match the resolution of the screen
            SetPanelSize(screenSize, obj);
        }
    }

    public void SetPanelSize((int, int) size, GameObject panel)
    {
        /*for testing 
         Debug.Log(gameObject.name + " Before Size: " + gameObject.GetComponent<RectTransform>().sizeDelta);
         Debug.Log(size.Item1);
         Debug.Log(size.Item2); 
        */
        //set the size of a game object using the RectTransform component. the sizeDelta requires a Vector2 to set the size, so we make a new Vector2 from the values passed for size
        panel.GetComponent<RectTransform>().sizeDelta = new Vector2(size.Item1, size.Item2);
        //Debug.Log(gameObject.name + " After Size: " + gameObject.GetComponent<RectTransform>().sizeDelta);

    }

    public (int, int) GetScreenSize()
    {
        //returns an int tuple with the width, height of the screen
        return (Screen.currentResolution.width, Screen.currentResolution.height);
    }
}
