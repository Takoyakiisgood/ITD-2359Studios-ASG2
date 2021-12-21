using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day1Manager : MonoBehaviour
{
    public bool feedComplete;
    public bool cleanComplete;
    private int feedNum;
    private int cleanNum;

    public TMP_Text task1Text;
    public TMP_Text task2Text;
    public Button NextDayBtn;

    public static Day1Manager Instance;

    public void FeedDone()
    {
        ++feedNum;
        if (feedNum == 4)
        {
            feedComplete = true;
            if (task1Text != null)
            {
                task1Text.fontStyle = FontStyles.Strikethrough;
            }
        }
    }

    public void cleanDone()
    {
        ++cleanNum;
        if (cleanNum == 2)
        {
            cleanComplete = true;
            if (task2Text != null)
            {
                task2Text.fontStyle = FontStyles.Strikethrough;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (feedComplete && cleanComplete)
        {
            Debug.Log("Day 1 Task Done");
            //display the button to go to nextscene
            //do the nessary updates on database
        }
    }
}
