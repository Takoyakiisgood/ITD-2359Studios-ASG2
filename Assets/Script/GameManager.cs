using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int dayCount;
    private int taskCount;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //Get the player progress from the database: players path
        //if the currentDay is 1 switch the scene to day1 otherwise switch to day2 or 3
        dayCount = 1;
    }

}
