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
    public GameObject DialogueSystem;
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
    public GameObject[] jeremyExpressions;
    string _currentExp = "Neutral";
    bool _atCheck = false;
    int index = 0;
    string _playerName;
    public TMP_InputField _nameGetter;
    

    // Start is called before the first frame update
    void Start()
    {
        
        _playerName = _nameGetter.text;
        storage = FindObjectOfType<VariableStorageBehaviour>();
        scoreText.text = myPlayer.score.ToString();
        myPanels = myDisplayManager.myPanels.ToArray();
        _meterFill.color = meterGradient.Evaluate(myPlayer.score);
        foreach (var exp in jeremyExpressions)
        {
            exp.SetActive(false);
        }
        //DialogueSystem.SetActive(false);
        NextScene();

    }

    // Update is called once per frame
    void Update()
    {
        
        
            Debug.Log("here");

            storage.SetValue("$playerName", _playerName);
            storage.TryGetValue("$optionSelected", out _optionSelected);
            storage.TryGetValue("$moveOn", out _moveOn);
            storage.TryGetValue("$expression", out _currentExp);
            //storage.TryGetValue("$atCheck", out _atCheck); //maybe I don't need to check win loss in code?

            SetExpression(_currentExp);

            if (_optionSelected)
            {
                storage.TryGetValue("$points", out points);
                int scoreToAdd = CheckScoreCap(myPlayer.score + (int)points);
                myPlayer.score += scoreToAdd;
                Debug.Log(myPlayer.score);
                //scoreText.text = myPlayer.score.ToString();
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
           /* if (_atCheck)
            {
                EndGameCheck();
            } */
        
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

    public void SetExpression(string expression)
    {
        foreach (var exp in jeremyExpressions)
        {
            if (exp.name.Equals(expression))
            {
                exp.SetActive(true);
            }
            else
            {
                exp.SetActive(false);
            }
        }
    }

    private int CheckScoreCap(int score)
    {
        if (score<0)
        {
            score = 0;
        }
        return score;
    }

    private void EndGameCheck()
    {
        switch (myPlayer.score)
        {
            case > 75:
                Debug.Log("Passed");
                break;
            case >=50:
                Debug.Log("Average");
                break;
            case <50:
                Debug.Log("Failed");
                break;
            default:
                Debug.Log("default");
                break;
        }
    }
    
    public void GetNameInput()
    {
        _playerName= _nameGetter.text;
    }

    public void NameEditDone()
    {
        myRunner.StartDialogue(myRunner.startNode);
        _nameGetter.gameObject.SetActive(false);
    }
}
