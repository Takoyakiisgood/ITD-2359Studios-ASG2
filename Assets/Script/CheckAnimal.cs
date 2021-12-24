using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnimal : MonoBehaviour
{
    public string AnimalName;
    private Renderer render;
    [Header("Color for Wrong Animal")]
    public Color color;
    [Header("Color for Start")]
    public Color colorStart;

    private void Awake()
    {
        render = this.GetComponent<Renderer>();
    }

    public void SetBackColor()
    {
        render.material.color = colorStart;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        //Check if the collidered object is the same as the AnimalName
        if (other.name == AnimalName)
        {
            if (AnimalName == "Fox")
            {
                Day2Manager.Instance.setfoxFound();
            }

            if (AnimalName == "Deer")
            {
                Day2Manager.Instance.setdeerFound();
            }

            this.render.enabled = false;
        }
        else
        {
            //set the render of the trigger to red
            render.material.color = color;
            //minus chance
            Day2Manager.Instance.loseChance();
        }

    }

}
