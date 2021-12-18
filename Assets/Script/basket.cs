using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    public string AnimalFood;
    public Animator myanimator;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag + " is inside the basket");
        //Check if the Object inside is a food if not do something
        if (other.gameObject.tag == "Food")
        {
            Debug.Log("Animation of animal walking to the food....");
            //set the animation of the animal coming towards the food
            myanimator.SetBool("Moving", true);

            //wait for the animation to be completed before playing the others
            StartCoroutine(CheckFood(other.gameObject));           
        }
        else
        {
            //do something if the game object is not food
            //Show a UI to Display the Time left to Destory the food
            //add a timer to destroy the game object? 
        }
    }

    private IEnumerator CheckFood(GameObject food)
    {
        yield return new WaitForSeconds(3);
        //Check if the food is the correct food
        if (food.name == AnimalFood)
        {
            //do something when the food is correct
            Consumer.Instance.foodConsumed = true;
            food.SetActive(false);
            //animal will eat the food
            Debug.Log("Nomm Nommm....");
        }
        else
        {
            //the animal will turn back
            myanimator.SetBool("Moving", false);
        }
    }

}
