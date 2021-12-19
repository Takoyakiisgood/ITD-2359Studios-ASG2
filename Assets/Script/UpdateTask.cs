using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateTask : MonoBehaviour
{
    public static UpdateTask Instance;

    private TMP_Text taskStatus;

    public AudioClip completeQuestClip;
    private AudioSource taskSource;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //Get quest audio source
        taskSource = GetComponent<AudioSource>();
    }
    public void TaskComplete(int num)
    {
        string taskName = "Task" + num;
        taskStatus = GameObject.Find(taskName).GetComponent<TMP_Text>();
        taskStatus.fontStyle = FontStyles.Strikethrough;
        taskSource.PlayOneShot(completeQuestClip);
    }
}
