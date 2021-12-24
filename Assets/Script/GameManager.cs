using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// reference to play an animation to fade audio to another
    /// </summary>
    public Animator audioTransition;

    /// <summary>
    /// The time to wait before it transit to another scene
    /// </summary>
    private float transitionTime = 1f;

    [SerializeField]
    private int index;

    public static GameManager Instance;

    public int dayCount;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //Get the player progress from the database: players path
        dayCount = 1;
    }

    /// <summary>
    /// Restart the game when the player chance is all gone
    /// </summary>
    public void Restart()
    {
        //Update to Database user Current Day progress is back to 1
        //Update to Databse Day 1 -> playerID is true
        //Update to numFailed +1
        //Switch Scene to Day1 Scene
    }

    //index 0 is splash page, index 1 is sign in, index 2 is menu and index 3 is main game
    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        //get the current Day progress and use if else statement to switch to different scene
        //StartCoroutine(LoadLevel(3));
    }

    public void MainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void UpdateScene()
    {
        StartCoroutine(LoadLevel(index));
    }

    IEnumerator LoadLevel(int levelindex)
    {
        //play BGM music
        if (audioTransition != null)
        {
            audioTransition.SetTrigger("fadeOut");
        }
        //wait
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene(levelindex);
    }
}
