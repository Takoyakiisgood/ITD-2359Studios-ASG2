using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day1Manager : MonoBehaviour
{
    [Header("Check Task Complete")]
    public bool feedComplete;
    public bool cleanComplete;
    [SerializeField]
    private int Chance = 3;

    [Header("Check Animal Fed & Clean Num")]
    public bool fedFox;
    public bool fedWhale;
    public bool fedPeguin;
    public bool fedDeer;
    public int cleanNum;

    [Header("To be Assigned")]
    public TMP_Text task1Text;
    public TMP_Text task2Text;
    public Text ChanceTxt;
    public Button NextDayBtn;
    public GameObject LoseUI;
    public GameObject LosingAudio;
    public GameObject ReduceChanceAudio;

    public static Day1Manager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void loseChance()
    {
        --Chance;

        ChanceTxt.text = Chance.ToString();
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

    public void FedCheck()
    {
        if (fedFox && fedWhale && fedPeguin && fedDeer)
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
        if (NextDayBtn != null)
        {
            NextDayBtn.gameObject.SetActive(false);
        }
        if (LoseUI != null)
        {
            LoseUI.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (feedComplete && cleanComplete)
        {
            Debug.Log("Day 1 Task Done");
            //display the button to go to nextscene
            if (NextDayBtn != null)
            {
                NextDayBtn.gameObject.SetActive(true);
            }
            //do the nessary updates on database
            //get the time taken from Time Manager Instance
        }
    }
}
