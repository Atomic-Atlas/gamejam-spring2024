using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneClassBase : MonoBehaviour
{
    TextContainerBaseClass textContainer = new();
    GameObject textDisplayObject;

    // Start is called before the first frame update
    void Start()
    {
        textDisplayObject = transform.GetChild(0).gameObject;
        textContainer.text = textDisplayObject.GetComponentInChildren<TMP_Text>();
        textContainer.textBox = textDisplayObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
