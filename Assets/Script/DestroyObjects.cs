using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class DestroyObjects : MonoBehaviour
{
    public GameObject dustPan;
    public GameObject audioPrefab;
    public void SetSocketActive()
    {
        XRSocketInteractor socket = dustPan.GetComponent<XRSocketInteractor>();
        socket.socketActive = true;
    }
    public void ReleaseSocket()
    {
        XRSocketInteractor socket = dustPan.GetComponent<XRSocketInteractor>();
        socket.socketActive = false;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            if(audioPrefab != null)
            {
                GameObject audioObj = Instantiate(audioPrefab, transform.position, Quaternion.identity, null);
            }
            
            Destroy(collision.gameObject);
            Day1Manager.Instance.cleanDone();
        }
    }

}
