using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day2Manager : MonoBehaviour
{   
    [Header("To be Assigned")]
    public TMP_Text task1Text;
    public TMP_Text task2Text;
    public Button examDayBtn;
    public SkinnedMeshRenderer rightHand;
    public SkinnedMeshRenderer leftHand;
    public Material materialToChange;

    [Header("Check Task Done")]
    public bool cleanComplete;
    public bool animalFoundComplete;

    [Header("Check Animal Found")]
    [SerializeField]
    private bool foxFound;
    [SerializeField]
    private bool deerFound;

    public bool hasGlove;
    public int cleanNum;
    public static Day2Manager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void setfoxFound() {
        foxFound = true;
        animalCaptureCheck();
    }

    public void setdeerFound()
    {
        deerFound = true;
        animalCaptureCheck();
    }

    public void checkWornGlove()
    { 
        if(hasGlove == false)
        {
            //if the player does not have glove on, do something
            //minus the chance point

            //change the material of the hand to red
            if (materialToChange != null && rightHand != null && leftHand != null) 
            {
                rightHand.material = materialToChange;
                leftHand.material = materialToChange;
            }
        }
    }

    public void animalCaptureCheck() 
    {
        if (foxFound && deerFound)
        {
            animalFoundComplete = true;
            if (task1Text != null)
            {
                task1Text.fontStyle = FontStyles.Strikethrough;
            }
        }
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
