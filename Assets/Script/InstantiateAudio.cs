using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAudio : MonoBehaviour
{
    public GameObject audioPrefab;
    public void playAudio()
    {
        if (audioPrefab != null)
        {
            GameObject audioObj = Instantiate(audioPrefab, transform.position, Quaternion.identity, null);
        }
    }
}
