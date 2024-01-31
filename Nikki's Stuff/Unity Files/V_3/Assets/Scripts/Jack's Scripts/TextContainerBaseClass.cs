using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextContainerBaseClass : MonoBehaviour
{
    public DisplayManager myDisplayManager;

    //textbox assets
    public GameObject textBox;
    public TMP_Text text;

    //text to display
    public string[] lines;

    //dimensions of assets
    private int boxWidth;
    private int boxHeight;
    private const float HEIGHTMULTIPLIER = .2f;
    private const float WIDTHMULTIPLIER = .9f;

    //typing vars
    bool _canType = true;
    private int index = 0;
    public float typeSpeed = .4f;

    public void Start()
    {
        text.text = "";
        SetTextBoxSize();
    }

    public void Update()
    {
        if (gameObject.activeSelf && _canType && index < lines.Length)
        {

            StartCoroutine(DisplayText(lines[index]));

            _canType = false;

        }

        if (Input.GetKeyDown(KeyCode.Space) && _canType == false)
        {
            StopAllCoroutines();
            text.text = "";
            Debug.Log("Hit Space");

            _canType = true;
            if (index >= lines.Length)
            {
                gameObject.SetActive(false);
                index = 0;

            }
        }
    }

    public void ReplayText()
    {
        gameObject.SetActive(true);
        //_canType = true;
    }
    public IEnumerator DisplayText(string line)
    {
        index++;
        //Debug.Log(line);
        //for each line, break it up into characters, add characters one by one to text, loop until no more characters or reach a limit
        List<char> textTyped = new List<char>() { };

        char[] temp = line.ToCharArray();


        //Debug.Log("temp Array length= " + temp.Length);
        foreach (var character in temp)
        {

            textTyped.Add(character);
            //Debug.Log(character.ToString() + " : " + textTyped.Count);

            text.text += textTyped[textTyped.Count - 1].ToString();
            yield return new WaitForSeconds(typeSpeed);

        }



    }

    public void SetTextBoxSize()
    {

        boxWidth = (int)(myDisplayManager.screenSize.Item1 * WIDTHMULTIPLIER);
        boxHeight = (int)(myDisplayManager.screenSize.Item2 * HEIGHTMULTIPLIER);
        Debug.Log(boxWidth + "," + boxHeight);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(boxWidth, boxHeight);
        textBox.GetComponent<RectTransform>().sizeDelta = new Vector2(boxWidth, boxHeight);
        text.GetComponent<RectTransform>().sizeDelta = new Vector2(boxWidth - 30, boxHeight - 20);
        transform.position = new Vector3(transform.position.x, myDisplayManager.screenSize.Item2 * .01f);

    }




}
