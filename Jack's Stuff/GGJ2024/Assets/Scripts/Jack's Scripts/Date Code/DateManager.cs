using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class DateManager : MonoBehaviour
{
    public YarnProject yarnProject;
    public DialogueRunner dialogueRunner;

    void Awake()
    {
        dialogueRunner.yarnProject = yarnProject;

    }
    void Start()
    {
        // Assign the Yarn project to the Dialogue Runner
        foreach (var node in dialogueRunner.Dialogue.NodeNames)
        {
            Debug.Log(node);  
        }
        // Start the dialogue from a specific node
        dialogueRunner.StartDialogue("Date1");
    }
}
