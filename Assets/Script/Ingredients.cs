using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    public string AnimalFood;
    public Animator myanimator;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag + " is inside the basket");
        //Check if the Object inside is a food if not do something
        if (other.gameObject.tag == "Fish")
        {


            //wait for the animation to be completed before playing the others
            StartCoroutine(CheckIngredients(other.gameObject));
        }
        else
        {

        }
    }

    private IEnumerator CheckIngredients(GameObject food)
    {
        yield return new WaitForSeconds(3);
        //Check if the ingredients is in the correct recipe
        if (food.name == AnimalFood)
        {
            // "correct" effect particles will appear
        }
        else
        {
            // "wrong" effect particles will appear
        }
    }

}
