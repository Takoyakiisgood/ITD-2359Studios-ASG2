using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAudio : MonoBehaviour
{
    public GameObject[] audioPrefabList;

    public void playAudio(int num)
    {
        if (audioPrefabList.Length != 0)
        {
            GameObject audioObj = Instantiate(audioPrefabList[num], transform.position, Quaternion.identity, null);
        }
    }
}
