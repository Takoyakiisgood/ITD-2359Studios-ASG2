using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day2Manager : MonoBehaviour
{
    public bool hasGlove;
    public TMP_Text task1Text;
    public TMP_Text task2Text;
    public Button examDayBtn;
    public bool cleanComplete;
    public bool animalFoundComplete;
    public int cleanNum;
    public static Day2Manager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void cleanDone()
    {
        ++cleanNum;
        if (cleanNum == 3)
        {
            cleanComplete = true;
            if (task2Text != null)
            {
                task2Text.fontStyle = FontStyles.Strikethrough;
            }
        }
    }

    
    public void SetGloves()
    {
        hasGlove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animalFoundComplete && cleanComplete)
        {
            Debug.Log("Day 2 Task Done");
            //display the button to go to nextscene
            if (examDayBtn != null)
            {
                examDayBtn.gameObject.SetActive(true);
            }
            //do the nessary updates on database
        }
    }
}
