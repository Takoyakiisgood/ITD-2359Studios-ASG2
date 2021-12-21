using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class DestroyObjects : MonoBehaviour
{
    public GameObject dustPan;

    public void SetSocketActive()
    {
        XRSocketInteractor socket = dustPan.GetComponent<XRSocketInteractor>();
        socket.socketActive = true;
        Debug.Log(socket.gameObject.name);
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
            Destroy(collision.gameObject);
            Day1Manager.Instance.cleanDone();
        }
    }

}
