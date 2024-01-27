using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseClass 
{
    public int score { private set; get; }

    //scenario arrays
    string[] dinnerStages = new string[3] { "Apps", "Main Course", "Desserts" };
    string[] _apps = new string[3] { "Full points", "Half points,", "No points" };
    string[] _mainCourse = new string[3] { "Full points", "Half points,", "No points" };
    string[] _desserts = new string[3] { "Full points", "Half points,", "No points" };
    string[] _currentStage = new string[3];

    //index
    int index = 0;
    public string[] GetCurrentStage()
    {
        string currentStageName = dinnerStages[index];
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
