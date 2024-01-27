using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    PlayerBaseClass myPlayer = new PlayerBaseClass();
    //Date class = new date class
    public VariableStorageBehaviour storage;
    public static int stageIndex = 0;
    bool _optionSelected=false;
    public float points = 0;
    public TMP_Text scoreText;
    public Slider meter;
    

    // Start is called before the first frame update
    void Start()
    {
        storage = FindObjectOfType<VariableStorageBehaviour>();
        scoreText.text = myPlayer.score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        storage.TryGetValue("$optionSelected", out _optionSelected);
        Debug.Log(_optionSelected);
        Debug.Log(points);



        if (_optionSelected)
        {
            storage.TryGetValue("$points", out points);
            myPlayer.score +=(int) points;
            Debug.Log(myPlayer.score);
            scoreText.text = myPlayer.score.ToString();
            storage.SetValue("$points", 0);
            storage.SetValue("$optionSelected", false);
            meter.value = myPlayer.score / 100;
        }
        else
        {
            points = 0;

        }
    }



    
}
