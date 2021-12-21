/******************************************************************************
Author: Jordan Yeo Xiang Yu

Name of Class: ChangeScene

Description of Class: This class will change the game scene

Date Created: 18/12/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private int index;

    public void UpdateScene()
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
