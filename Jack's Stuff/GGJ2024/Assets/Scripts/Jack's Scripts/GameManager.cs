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
        //myPlayer.score = 5;
        meter.value = myPlayer.score;
        storage = FindObjectOfType<VariableStorageBehaviour>();
        scoreText.text = myPlayer.score.ToString();
        myPanels = myDisplayManager.myPanels.ToArray();
        _meterFill.color = meterGradient.Evaluate(meter.normalizedValue);

        


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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
            Debug.Log("here");

            storage.SetValue("$playerName", _playerName);
            storage.TryGetValue("$optionSelected", out _optionSelected);
            storage.TryGetValue("$moveOn", out _moveOn);
            storage.TryGetValue("$expression", out _currentExp);
            storage.SetValue("$score", myPlayer.score);
            //storage.TryGetValue("$atCheck", out _atCheck); //maybe I don't need to check win loss in code?

            SetExpression(_currentExp);

            if (_optionSelected)
            {
                points = 0;
                storage.TryGetValue("$points", out points);
                Debug.Log("points= " + points);
                int scoreToAdd = CheckScoreCap(myPlayer.score + (int)points, (int)points);
                Debug.Log("Adding: " + scoreToAdd);
                myPlayer.score += scoreToAdd;
                Debug.Log(myPlayer.score);
                //scoreText.text = myPlayer.score.ToString();
                storage.SetValue("$points", 0);
                points = 0;
                storage.SetValue("$optionSelected", false);
                meter.value = myPlayer.score;
                Debug.Log(_meterFill.fillAmount);
                _meterFill.color = meterGradient.Evaluate(meter.normalizedValue);
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

    private int CheckScoreCap(int score, int points)
    {

        if (score<0)
        {
            points = 0;
        }
        return points;
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
