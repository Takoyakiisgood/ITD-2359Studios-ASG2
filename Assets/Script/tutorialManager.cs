using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{
    public bool teleportTaskDone;
    public bool grabTaskDone;
    public void Teleported()
    {
        Debug.Log("I have teleported");
        //set the teleportTask to be done
        teleportTaskDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (teleportTaskDone && grabTaskDone)
        {
            Debug.Log("Tutorial Task Complete!");
        }
    }
}
