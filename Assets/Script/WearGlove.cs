using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearGlove : MonoBehaviour
{
    public Material gloveMat;

    public void wearGlove()
    {
        //set the player is wearing glove to be true
        
        //change the material of the hands to glove mat

        //get all the mesh renderers
        SkinnedMeshRenderer[] meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

        //go through all the renderers and turn on the emission property in each material
        foreach (SkinnedMeshRenderer renderer in meshRenderers)
        {
            renderer.material = gloveMat;
        }
    }
}
