﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    public static Consumer Instance;
    GameObject[] portions;
    int currentIndex;
    float lastChange;
    float interval = 1f;

    public bool foodConsumed;
    void Start()
    {
        foodConsumed = false;
        bool skipFirst = transform.childCount > 4;
        portions = new GameObject[skipFirst ? transform.childCount-1 : transform.childCount];
        for (int i = 0; i < portions.Length; i++)
        {
            portions[i] = transform.GetChild(skipFirst ? i + 1 : i).gameObject;
            if (portions[i].activeInHierarchy)
                currentIndex = i;
        }
    }
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Time.time - lastChange > interval)
        {
            if (!foodConsumed)
            {
                Consume();
                if(currentIndex == 4)
                {
                    foodConsumed = true;
                }
                
            }

            lastChange = Time.time;
        }
    }

    void Consume()
    {
        if (currentIndex != portions.Length)
            portions[currentIndex].SetActive(false);
        currentIndex++;
        if (currentIndex > portions.Length)
            currentIndex = 0;
        else if (currentIndex == portions.Length)
            return;
        portions[currentIndex].SetActive(true);
    }

}
