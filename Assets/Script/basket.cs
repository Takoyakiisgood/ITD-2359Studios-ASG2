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
            CheckFood(other.gameObject);
        }
    }
    public void CheckFood(GameObject food)
    {
        if (food.name == AnimalFood)
        {
            //play the animation of the animal eating food
            myanimator.SetTrigger("EatFood");
            //get the animal name
            string animal = myanimator.gameObject.name;
            if (animal == "Whale")
            {
                Day1Manager.Instance.fedWhale = true;
            }
            else if (animal == "Fox")
            {
                Day1Manager.Instance.fedFox = true;
            }
            else if (animal == "Deer")
            {
                Day1Manager.Instance.fedDeer = true;
            }
            else 
            {
                Day1Manager.Instance.fedPeguin = true;
            }
            //check if all the animals have been fed
            Day1Manager.Instance.FedCheck();
            //wait for the animation to be completed before setting the food to be gone
            StartCoroutine(SetFoodDisappear(food, 3));
        }
        else 
        {
            //play the animation of the animal walking away
            myanimator.SetTrigger("WrongFood");
        }
    }
    private IEnumerator SetFoodDisappear(GameObject food, int sec)
    {
        
        if (food.name == "Small Fish" || food.name == "Fish")
        {
            food.GetComponent<Consumer>().eatFood = true;
        }
        else
        {
            yield return new WaitForSeconds(sec);
            //do something when the food is correct
            food.SetActive(false);
        }

        //animal will eat the food
        Debug.Log("Nomm Nommm....");

    }

}
