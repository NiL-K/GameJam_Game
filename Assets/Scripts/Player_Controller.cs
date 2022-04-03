using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        InteractWithSmth();
        GrabObj();
        DragObj();
    //    DropObj();
    }


    
    public LayerMask interactiveLayer;

    private GameObject interactAim = null;

    private bool grabbed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("interactive"))
        {
            interactAim = other.gameObject;
            interactAim.GetComponent<Outline>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == interactAim)
        {
            interactAim.GetComponent<Outline>().enabled = false;
            interactAim = null;
        }
    }

    private void InteractWithSmth() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactAim != null)
            {
                Debug.Log(interactAim.name);
            }
        }

    }
    private void GrabObj()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactAim != null && grabbed == false)
        {
            interactAim.GetComponent<Rigidbody>().useGravity = false;
            interactAim.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            interactAim.transform.position = GameObject.Find("Grabb_zone").transform.position;
            GetComponentInChildren<SphereCollider>().enabled = false;
            grabbed = !grabbed;
            Debug.Log("Grabbed!");
        }
        else if (Input.GetKeyDown(KeyCode.E) && grabbed == true)
            {
                interactAim.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                interactAim.GetComponent<Rigidbody>().useGravity = true;
                interactAim.transform.position = GameObject.Find("Grabb_zone").transform.position;
                GetComponentInChildren<SphereCollider>().enabled = true;
                grabbed = !grabbed;
                Debug.Log("Dropped!");
            }
    }
    private void DragObj()
    {
      if (grabbed && interactAim != null)
            interactAim.transform.position = GameObject.Find("Grabb_zone").transform.position;
    }

}
    



