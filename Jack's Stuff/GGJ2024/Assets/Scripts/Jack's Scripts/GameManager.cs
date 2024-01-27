using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public DisplayManager myDisplayManager;
    public DialogueRunner myRunner;
    PlayerBaseClass myPlayer = new PlayerBaseClass();
    //Date class = new date class
    public VariableStorageBehaviour storage;
    public static int stageIndex = 0;
    bool _optionSelected=false;
    bool _moveOn = false;
    public float points = 0;
    public TMP_Text scoreText;
    public Slider meter;
    public Image _meterFill;
    public Gradient meterGradient;
    GameObject[] myPanels;

    int index = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        storage = FindObjectOfType<VariableStorageBehaviour>();
        scoreText.text = myPlayer.score.ToString();
        myPanels = myDisplayManager.myPanels.ToArray();
        _meterFill.color = meterGradient.Evaluate(myPlayer.score);

        NextScene();

    }

    // Update is called once per frame
    void Update()
    {
        storage.TryGetValue("$optionSelected", out _optionSelected);
        storage.TryGetValue("$moveOn", out _moveOn);
        Debug.Log(_optionSelected);
        Debug.Log(points);



        if (_optionSelected)
        {
            storage.TryGetValue("$points", out points);
            myPlayer.score += (int)points;
            Debug.Log(myPlayer.score);
            scoreText.text = myPlayer.score.ToString();
            storage.SetValue("$points", 0);
            storage.SetValue("$optionSelected", false);
            meter.value = myPlayer.score;
            _meterFill.color = meterGradient.Evaluate(_meterFill.fillAmount);
        }
        else
        {
            points = 0;

        }
        if (_moveOn)
        {
            index++;
            NextScene();
            storage.SetValue("$moveOn", false);

        }

    }

    public void NextScene()
    {
        foreach (var item in myPanels)
        {
            if (item == myPanels[index]||item==myPanels[myPanels.Length-1])
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }

    
}
