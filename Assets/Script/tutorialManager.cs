using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class tutorialManager : MonoBehaviour
{
    public bool teleportTaskDone;
    public bool grabTaskDone;
    public TMP_Text task1Text;
    public TMP_Text task2Text;

    public void Teleported()
    {
        Debug.Log("I have teleported");
        //set the teleportTask to be done
        teleportTaskDone = true;
        if(task1Text != null)
        {
            task1Text.fontStyle = FontStyles.Strikethrough;
        }
    }

    public void SetGrabTask()
    {
        Debug.Log("grab task done");
        //set the teleportTask to be done
        grabTaskDone = true;
        if (task2Text != null)
        {
            task2Text.fontStyle = FontStyles.Strikethrough;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (teleportTaskDone && grabTaskDone)
        {
            Debug.Log("Tutorial Task Complete!");
            //display the tutorial Task Done
        }
    }
}
