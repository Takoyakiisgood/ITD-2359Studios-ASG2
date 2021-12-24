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
    public Text ChanceTxt;
    public Button examDayBtn;
    public GameObject OuchAudioPrefab;
    public SkinnedMeshRenderer rightHand;
    public SkinnedMeshRenderer leftHand;
    public Material handMat;
    public GameObject LoseUI;
    public GameObject LosingAudio;
    public GameObject ReduceChanceAudio;

    [Header("Edit the blinking effect")]
    public Color startColor;
    public Color endColor;
    [Range(0, 10)]
    public float Speed = 1;

    [Header("Check Task Done")]
    public bool cleanComplete;
    public bool animalFoundComplete;

    [Header("Check Animal Found & Clean Num")]
    [SerializeField]
    private bool foxFound;
    [SerializeField]
    private bool deerFound;
    [SerializeField]
    private int Chance = 3;
    public bool hasGlove;
    public bool hurtHand;
    public int cleanNum;
    public static Day2Manager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void loseChance()
    {
        --Chance;
        ChanceTxt.text = Chance.ToString();
        if (ReduceChanceAudio != null)
        {
            GameObject audioObj = Instantiate(ReduceChanceAudio, transform.position, Quaternion.identity, null);
        }

        if (Chance == 0)
        {
            //display UI showing you have been fired
            if (LoseUI != null && LosingAudio != null)
            {
                //wait for 1 sec before showing the UI and losing audio
                StartCoroutine(waitfor(1));
            }
            //restart the game
        }
    }

    private IEnumerator waitfor(int sec)
    {
        yield return new WaitForSeconds(sec);
        //play losing sound
        GameObject audioObj = Instantiate(LosingAudio, transform.position, Quaternion.identity, null);
        //show UI
        LoseUI.gameObject.SetActive(false);
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
            loseChance();
            //change the material of the hand to red
            if (!hurtHand && rightHand != null && leftHand != null) 
            {
                if (OuchAudioPrefab != null)
                {
                    GameObject audioObj = Instantiate(OuchAudioPrefab, transform.position, Quaternion.identity, null);
                }
                //play the blinking effect at update
                hurtHand = true;
                //wait for 3 seconds to blink color before changing back the colors
                StartCoroutine(BlinkColor(3));
            }
        }
    }

    private IEnumerator BlinkColor(int sec)
    {
        yield return new WaitForSeconds(sec);
        hurtHand = false;
        leftHand.material = handMat;
        rightHand.material = handMat;
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
        if (examDayBtn != null)
        {
            examDayBtn.gameObject.SetActive(false);
        }

        if (LoseUI != null)
        {
            LoseUI.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hurtHand && rightHand!= null && leftHand != null)
        {
            rightHand.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * Speed, 1));
            leftHand.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * Speed, 1));
        }
        
        if (animalFoundComplete && cleanComplete)
        {
            Debug.Log("Day 2 Task Done");
            //display the button to go to nextscene
            if (examDayBtn != null)
            {
                examDayBtn.gameObject.SetActive(true);
            }
            //do the nessary updates on database
            //get the time taken from Time Manager Instance
        }
    }
}
