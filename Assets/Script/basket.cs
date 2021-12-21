using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    public string AnimalFood;
    public Animator myanimator;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag + " is inside the basket");
        //Check if the Object inside is a food if not do something
        if (other.gameObject.tag == "Food")
        {
            Debug.Log("Animation of animal walking to the food....");
            //set the animation of the animal coming towards the food
            myanimator.SetTrigger("EatFood");

            //wait for the animation to be completed before playing the others
            StartCoroutine(CheckFood(other.gameObject));           
        }
    }

    private IEnumerator CheckFood(GameObject food)
    {
        yield return new WaitForSeconds(3);
        //Check if the food is the correct food
        if (food.name == AnimalFood)
        {
            if (food.name == "SmallFish" || food.name == "Fish")
            {
                food.GetComponent<Consumer>().eatFood = true;
            }            
            //do something when the food is correct
            food.SetActive(false);
            //animal will eat the food
            Debug.Log("Nomm Nommm....");
        }
        else
        {
            //the animal will turn back
            myanimator.SetTrigger("WrongFood");
        }
    }

}
