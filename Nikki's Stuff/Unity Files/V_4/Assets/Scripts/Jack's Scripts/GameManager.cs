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
        //set and get intial values
        _playerName = _nameGetter.text;
        
        meter.value = myPlayer.score;
        storage = FindObjectOfType<VariableStorageBehaviour>();
        scoreText.text = myPlayer.score.ToString(); //this still exists technically, but I hid the object it's tied to
        myPanels = myDisplayManager.myPanels.ToArray();
        _meterFill.color = meterGradient.Evaluate(meter.normalizedValue);

        

        //loop through all the images for Jermey and set them to inactive, hiding them from view
        foreach (var exp in jeremyExpressions)
        {
            exp.SetActive(false);
        }
        //load up the first scene/background
        NextScene();

    }

    // Update is called once per frame
    void Update()
    {
        //Checks for input of escape key, and quits application if pressed (doesn't work in editor, only build)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
            //Debug.Log("here");
            
            // continuously get and set values between Unity and Yarnspinner (This works,
            // but it isn't the cleanest option, I just did it for time sake because it
            // was a quick implementation)
            storage.SetValue("$playerName", _playerName);
            storage.TryGetValue("$optionSelected", out _optionSelected);
            storage.TryGetValue("$moveOn", out _moveOn);
            storage.TryGetValue("$expression", out _currentExp);
            storage.SetValue("$score", myPlayer.score);
            //storage.TryGetValue("$atCheck", out _atCheck); //maybe I don't need to check win loss in code?

            //sets correct expression for Jeremy to active 
            SetExpression(_currentExp);

            //checks if an option is selected, and then runs code if it is
            if (_optionSelected)
            {
                //makes sure points are set to 0 to start on the C# end
                points = 0;
                //gets points from yarn and set that value for the C# variable for points
                storage.TryGetValue("$points", out points);
               // Debug.Log("points= " + points);
                //make sure the the overall score doesn't become negative based on the points being subtracted or added
                int scoreToAdd = CheckScoreCap(myPlayer.score + (int)points, (int)points);
                Debug.Log("Adding: " + scoreToAdd);
                myPlayer.score += scoreToAdd;
                Debug.Log(myPlayer.score);
                //scoreText.text = myPlayer.score.ToString();--- This isn't being used in the current build, so I commented it out but left it here incase we decided to incorporate it
                storage.SetValue("$points", 0);
                points = 0;
                storage.SetValue("$optionSelected", false);
                meter.value = myPlayer.score;
                Debug.Log(_meterFill.fillAmount);
                _meterFill.color = meterGradient.Evaluate(meter.normalizedValue);
            }
            else
            {
                //if an option hasn't been selected, we make sure points are set to 0 so the score cannot be changed accidentally
                points = 0;

            }
            if (_moveOn)
            {
                //changes backdrop to the next one
                index++;
                NextScene();
                //resets $moveOn variable to false on the yarn side, which in turn will then reset it on the C# side as well since we are constantly checking for the value
                storage.SetValue("$moveOn", false);

            }

        
    }

    public void NextScene()
    {
        foreach (var item in myPanels)
        {
            //sets the current panel and the overlay (the last panel in the index) as active, and sets all others inactive
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

    //loops through expressions setting a match to active, and all other expressions inactive
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
        //ensures the points being returned won't go above the min or max values- should have variable for max value realistically, but I hard code to save time
        if (score<=0 || score>=13)
        {
            points = 0;
        }
        return points;
    }

    //function that isn't being used with how we ended up handling score at the end
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
    
    //retrieves name from _nameGetter object
    public void GetNameInput()
    {
        _playerName= _nameGetter.text;
    }

    //removes the name entering UI and starts dialogue
    public void NameEditDone()
    {
        myRunner.StartDialogue(myRunner.startNode);
        _nameGetter.gameObject.SetActive(false);
    }
}