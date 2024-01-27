using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerBaseClass 
{
    public int score { set; get; }
    //scenario arrays
    string[] dinnerStages = new string[3] { "Apps", "Main Course", "Desserts" };
    string[] _apps = new string[3] { "Full points", "Half points,", "No points" };
    string[] _mainCourse = new string[3] { "Full points", "Half points,", "No points" };
    string[] _desserts = new string[3] { "Full points", "Half points,", "No points" };
    string[] _currentStage = new string[3];

    //index
    int answerIndex = 0;

    public string[] GetCurrentStage()
    {
        string currentStageName = dinnerStages[GameManager.stageIndex];
        switch (currentStageName)
        {
            case "Apps":
                _currentStage = _apps;
                break;
            case "Main Course":
                _currentStage = _mainCourse;
                break;
            case "Desserts":
                _currentStage = _desserts;
                break;
            default:
                break;
        }
        return _currentStage;
    }
}
