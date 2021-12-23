using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Day2DestroyObjects : MonoBehaviour
{
    public GameObject dustPan;
    private XRSocketInteractor socket;
    private void Awake()
    {
        socket = dustPan.GetComponent<XRSocketInteractor>();
    }
    public void SetSocketActive()
    {
        socket.socketActive = true;
    }
    public void ReleaseSocket()
    {
        socket.socketActive = false;       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            //set the socket back to active
            socket.socketActive = true;
            Destroy(collision.gameObject);
            Day2Manager.Instance.cleanDone();
        }
    }

}
