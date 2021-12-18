/******************************************************************************
Author: Jordan Yeo Xiang Yu, Celest Goh Zi Xuan, Theng Sun Yu, Esther Ho Enqi, Pan ZiAn, Ng Hui Ling

Name of Class: ChangeScene

Description of Class: This class will controls the changing of every scene.

Date Created: 18/12/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeAppScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
