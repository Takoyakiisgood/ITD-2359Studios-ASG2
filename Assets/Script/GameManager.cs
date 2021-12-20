using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int dayCount;
    private int taskCount;

    private bool hasGlove;

    private TMP_Text currentTask;

    public List<string> Day1TaskList = new List<string>();
    public List<string> Day2TaskList = new List<string>();
    public List<string> Day3TaskList = new List<string>();

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        dayCount = 1;
    }

    public void SetGloves()
    {
        hasGlove = true;
    }
    void DisplayTaskList(string dayCount)
    {
        if (dayCount == "1")
        {
            for (int i = 0; i <Day1TaskList.Count; i++)
            {
                string taskName = "task" + i;
                currentTask = GameObject.Find(taskName).GetComponent<TMP_Text>();
                currentTask.text = "Task " + i + ": " + Day1TaskList[i];
            }
        }

        else if (dayCount == "2")
        {
            for (int i = 0; i < Day2TaskList.Count; i++)
            {
                string taskName = "task" + i;
                currentTask = GameObject.Find(taskName).GetComponent<TMP_Text>();
                currentTask.text = "Task " + i + ": " + Day2TaskList[i];
            }
        }

        else if (dayCount == "3")
        {
            for (int i = 0; i < Day3TaskList.Count; i++)
            {
                string taskName = "task" + i;
                currentTask = GameObject.Find(taskName).GetComponent<TMP_Text>();
                currentTask.text = "Task " + i + ": " + Day3TaskList[i];
            }
        }
    }
}
